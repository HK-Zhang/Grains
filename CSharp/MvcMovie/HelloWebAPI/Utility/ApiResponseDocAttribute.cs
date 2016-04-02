using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWebAPI.Utility
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiResponseDocAttribute : Attribute 
    {
        public ApiResponseDocAttribute(string doc)
        {
            Documentation = doc;
        }
        public string Documentation { get; set; } 
    }
}