using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SKAPIHandler
{
    public class ServiceClient
    {
        private HttpClient Client { get; set; }

        public HttpClient GetClient() { return Client; }

        /// <summary>
        /// Initialise a new instance of SKAPI.Handler.ServiceClient which in turn initialises a new instance of
        /// HttpClient with no set handler
        /// </summary>
        public ServiceClient()
        {
            Client = new HttpClient();
        }

        /// <summary>
        /// Initialise a new instance of SKAPI.Handler.ServiceClient which in turn initialises a new instance of
        /// HttpClient with a pre-defined client handler
        /// </summary>
        /// <param name="Handler">Pre-defined client handler to use when creating the HttpClient</param>
        public ServiceClient(HttpClientHandler Handler)
        {
            Client = new HttpClient(Handler);
        }

        /// <summary>
        /// Initialise a new instance of SKAPI.Handler.ServiceClient which in turn initialises a new instance of
        /// HttpClient with a created client handler from the provided client certificate and SSL protocols
        /// </summary>
        /// <param name="ClientCertificate">Client certificate to be used when sending HTTP requests</param>
        /// <param name="Protocols">Supported SSL protocols for sending HTTP requests</param>
        public ServiceClient(X509Certificate2 ClientCertificate, SslProtocols Protocols)
        {
            HttpClientHandler Handler = new HttpClientHandler();
            Handler.ClientCertificates.Add(ClientCertificate);
            Handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            Handler.SslProtocols = Protocols;

            Client = new HttpClient(Handler);
        }
    }
}
