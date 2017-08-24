using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CsPoc.Toolkit
{
    public class JsonDemo
    {
        public void Execute()
        {
            var ae = new AggregateException(new Exception[] {new NotImplementedException()});
            Console.WriteLine(JsonConvert.SerializeObject(ae));
        }


        private void foo2()
        {
            var one = new DepthPoc
            {
                Name = "one"
            };

            var two = new DepthPoc
            {
                obj = one,
                Name = "two"
            };

            var three = new DepthPoc
            {
                obj = two,
                Name = "three"
            };

            var four = new DepthPoc
            {
                obj = three,
                Name = "four"
            };

            var five = new DepthPoc
            {
                obj = four,
                Name = "five"
            };

            var a = JsonConvert.DeserializeObject<DepthPoc>(JsonConvert.SerializeObject(five));
            Console.WriteLine(JsonConvert.SerializeObject(five));
        }

        private void foo1()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                //DateFormatString = "yyyy-MM-dd HH:mm:ss"
            };


            JSONC a = new JSONC
            {
                P1 = "abv",
                P2 = DateTime.UtcNow
            };

            Console.WriteLine(JsonConvert.SerializeObject(a));

            Console.WriteLine(JsonConvert.SerializeObject(a, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" }));
        }

        internal static JsonSerializer PrepareSerializer()
        {
            return JsonSerializer.CreateDefault(new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                Culture = CultureInfo.InvariantCulture
            });
        }

        public class JSONC
        {
            public string P1 { get; set; }
            public DateTime P2 { get; set; }
        }

        public class DepthPoc
        {
            public DepthPoc obj { get; set; }
            public string Name { get; set; }
        }
    }
}
