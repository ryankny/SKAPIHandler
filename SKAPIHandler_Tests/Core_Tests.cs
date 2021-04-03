using NUnit.Framework;
using SKAPIHandler;
using System;

namespace SKAPIHandler_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Create_HttpClient_Wrapper()
        {
            ServiceClient Client = new ServiceClient();
            Assert.Pass();
        }

        [Test]
        public async System.Threading.Tasks.Task Send_GET_RequestAsync()
        {
            // This test uses https://jsonplaceholder.typicode.com/ to mock an API service to demonstrate the functionality
            ServiceResponse Response = await APIHandler.SendRequestAsync(new ServiceClient(), "https://jsonplaceholder.typicode.com/posts", System.Net.Http.HttpMethod.Get);

            if(Response.HasErrorOccured() == false)
            {
                // Outputting the response from the API we received back
                Console.Write(await Response.ResponseMessage.Content.ReadAsStringAsync());
                Assert.Pass();
            }
            else
            {
                Assert.Fail("Failed to send request, error: " + (Response.ErrorException != null ? Response.ErrorException.ToString() : "ErrorException object is null"));
            }
        }
    }
}