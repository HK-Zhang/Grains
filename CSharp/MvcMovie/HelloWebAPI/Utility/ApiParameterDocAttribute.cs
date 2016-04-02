using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWebAPI.Utility
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiParameterDocAttribute : Attribute 
    {
        public ApiParameterDocAttribute(string param, string doc)
        {
            Parameter = param;
            Documentation = doc;
        }
        public string Parameter { get; set; }
        public string Documentation { get; set; } 
    }
}