using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SKAPIHandler
{
    public static class SKAPIHandler
    {
        public static async Task<ServiceResponse> SendRequestAsync(ServiceClient Client, string URI, HttpMethod Method, ServiceHeader[] Headers, RequestContent Content)
        {
            HttpClient RequestClient = Client.GetClient();
            HttpResponseMessage RequestResponse = null;

            try
            {
                using (HttpRequestMessage Request = BuildRequestMessage(URI, Method, Headers, Content))
                {
                    RequestResponse = await RequestClient.SendAsync(Request);
                }

                return new ServiceResponse(RequestResponse);
            }
            catch (Exception ex)
            {
                // Error has occured, return error exception
                return new ServiceResponse(ex);
            }
        }

        private static HttpRequestMessage BuildRequestMessage(string URI, HttpMethod Method, ServiceHeader[] Headers, RequestContent Content)
        {
            HttpRequestMessage Message = new HttpRequestMessage();

            Message.Method = Method;
            Message.RequestUri = new Uri(URI);

            foreach (ServiceHeader Header in Headers)
            {
                Message.Headers.Add(Header.Name, Header.Value);
            }

            if (Content != null)
            {
                Message.Content = new StringContent(Content.Body, Content.ContentEncoding, Content.ContentType);
            }

            return Message;
        }
    }
}
