using System;
using System.Configuration;

namespace StdTwoLib
{
    public class ConfigReader
    {
        public void ReadConfig()
        {
            var b = ConfigurationManager.AppSettings["StorageConnectionString"];
            var a = ConfigurationManager.GetSection("logConfig");
        }
    }
}
