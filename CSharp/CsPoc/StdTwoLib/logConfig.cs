using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace StdTwoLib
{
    public class logConfig : ConfigurationSection
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string name
        {
            get { return this["name"].ToString(); }
            set { this["name"] = value; }
        }


        [ConfigurationProperty("key", IsRequired = true)]
        public string key
        {
            get { return this["key"].ToString(); }
            set { this["key"] = value; }
        }

    }

    public class logMod
    {
        public string name { get; set; }
        public string key { get; set; }

    }
}
