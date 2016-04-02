using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWebAPI.Utility
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ApiControllerDocAttribute : Attribute 
    {

        public ApiControllerDocAttribute(string doc)
        {
            Documentation = doc;
        }
        public string Documentation { get; set; }


    }
}