using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace StdTwoLib
{
    public class ConfigReader
    {
        public string ReadConfig()
        {
            //var b = ConfigurationManager.AppSettings["StorageConnectionString"];
            //var a = ConfigurationManager.GetSection("logConfig") as logConfig;

            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("log.json", optional: true, reloadOnChange: true)
                .AddXmlFile("App.config", optional: true, reloadOnChange: true)
                //.AddXmlFile("CsPoc.exe.config", optional: true, reloadOnChange: true)
                .AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>("the-key", "the-value"),
                });

            var configuration = builder.Build();

            IndexMod f = new IndexMod();
            configuration.Bind("serConfig", f);
            var configValue = configuration["serConfig"];

            var b = configuration["option2"];
            var c = configuration["logConfig:name"];
            logMod e = new logMod();
            e= configuration.GetSection("logconfig").Get<logMod>();
            configuration.Bind("logconfig", e);
            //var d = configuration.GetValue<logMod>("logconfig");
            //var a = configuration.GetSection("logConfig");

            return b;


        }
    }
}
