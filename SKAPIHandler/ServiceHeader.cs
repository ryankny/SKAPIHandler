using System;
using System.Collections.Generic;
using System.Text;

namespace SKAPIHandler
{
    public class ServiceHeader
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public ServiceHeader(string Name, string Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
    }
}
