using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SKAPIHandler
{
    public static class APIHandler
    {
        /// <summary>
        /// Function to send a REST HTTP request with custom headers and content (dynamic depending on if its XML or JSON)
        /// </summary>
        /// <param name="Client">HttpClient wrapper class</param>
        /// <param name="URI">Service endpoint for the request</param>
        /// <param name="Method">REST method (GET, POST, DELETE, PUT)</param>
        /// <param name="Headers">Custom headers in an array to be pushed into the HttpRequestMessage</param>
        /// <param name="Content">Content wrapper class for the request content</param>
        public static async Task<ServiceResponse> SendRequestAsync(ServiceClient Client, string URI, HttpMethod Method, ServiceHeader[] Headers = null, RequestContent Content = null)
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

        /// <summary>
        /// Function to create a new instance of HttpRequestMessage using provided parameters and returning this newly created object
        /// </summary>
        private static HttpRequestMessage BuildRequestMessage(string URI, HttpMethod Method, ServiceHeader[] Headers, RequestContent Content)
        {
            HttpRequestMessage Message = new HttpRequestMessage();

            if(Method == null) { throw new Exception("Request method cannot be null"); }
            Message.Method = Method;

            if (URI == null) { throw new Exception("Request URI cannot be null"); }
            if (string.IsNullOrEmpty(URI)) { throw new Exception("Request URI cannot be empty"); }
            Message.RequestUri = new Uri(URI);

            if(Headers != null)
            {
                foreach (ServiceHeader Header in Headers)
                {
                    Message.Headers.Add(Header.Name, Header.Value);
                }
            }

            if (Content != null)
            {
                Message.Content = new StringContent(Content.Body, Content.ContentEncoding, Content.ContentType);
            }

            return Message;
        }
    }
}
