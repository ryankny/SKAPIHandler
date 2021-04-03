using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SKAPIHandler
{
    public class ServiceResponse
    {
        public HttpResponseMessage ResponseMessage { get; set; }
        public Exception ErrorException { get; set; }

        public bool HasErrorOccured() { return (ErrorException != null || ResponseMessage == null); }

        public ServiceResponse(HttpResponseMessage Response)
        {
            ResponseMessage = Response;
        }

        public ServiceResponse(Exception Error)
        {
            ErrorException = Error;
        }
    }
}
