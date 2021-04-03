using System;
using System.Collections.Generic;
using System.Text;

namespace SKAPIHandler
{
    public class RequestContent
    {
        public string Body { get; set; }
        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; set; }

        public RequestContent(string Body, Encoding ContentEncoding, string ContentType)
        {
            this.Body = Body;
            this.ContentEncoding = ContentEncoding;
            this.ContentType = ContentType;
        }
    }
}
