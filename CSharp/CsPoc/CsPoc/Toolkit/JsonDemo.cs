using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using CSDemo;
using Newtonsoft.Json.Linq;

namespace CsPoc.Toolkit
{
    public class JsonDemo
    {
        public void Execute()
        {
//            foo3();
            //var ae = new AggregateException(new Exception[] {new NotImplementedException()});
            //Console.WriteLine(JsonConvert.SerializeObject(ae));
            zipped();
        }

        private void zipped()
        {
            var value =
                "W0VudGl0eURlc2NyaXB0aW9uOkNvbnRhaW5zIHVzZXIgc2V0dGluZ3MgZm9yIHVzZXIgIGluIGNsaWVudCBzdmNXZXN0RXVyb3BlXSBbR2xvYmFsVXNlclByb3BlcnRpZXM6W11dIFtEZWZhdWx0Q291bnRyeTpERV0gW09yZ2FuaXphdGlvbklkOjE3MjNdIFtDcmVkZW50aWFsczpIYXNWYWx1ZTp0cnVlXSBbQ3JlZGVudGlhbHM6VmFsdWU6ODh1c3lpTU1IWkUwbk9waWs5ZzlGN0ZxaWR5dmtBQWw5Q1Z2WFE3TUx0Wm4zUUJIdDM3MGJJZU9oMGttclFzanNubE5oRzNsOFdWSTZmMUZXOWszWnNra01KYUYyQXNLTVBxTGNoK3FjTnJqaGcvcGErcG5yZDdyeUVPQ2grU29dIFtGYXZvcml0ZVByb2plY3RzOltdXSBbRmF2b3JpdGVIb3VyVHlwZXM6W11dIFtQcml2YXRlVXNlclByb3BlcnRpZXM6W11dIFtEZXZpY2VUeXBlOjBdIFtQZXJzb25JZDoxNjg0MS4wXSBbRXJwVXNlcklkOjQ2NDU3XSBbRGVwYXJ0bWVudElkOjQ3MTldIFtJZDpGUkFTQ0hNXSBbUmVjb3JkSWQ6RlJBU0NITS1zdmNXZXN0RXVyb3BlXSBbQ2xpZW50SWQ6c3ZjV2VzdEV1cm9wZV0gW0RlbGV0ZWQ6ZmFsc2VdIFtSZWNvcmRWZXJzaW9uOkNsaWVudDoxXSBbUmVjb3JkVmVyc2lvbjpTdGFnbmluZzoxXSBbUmVjb3JkVmVyc2lvbjpNYXN0ZXI6MV0gW0NyZWF0ZWREYXRlOjIwMTgtMDctMTZUMTY6MDk6MzEuNDkxMzIzNFpdIFtMYXN0Q29vcmRpbmF0ZWREYXRlOjIwMTgtMDctMTZUMTY6Dk6MzEuNTA3MjI1Wl0gW0xhc3RJbm5ib3VuZEFuZE91dGJvdW5kQ2hhbmdlczpLZXk6MF0gW0xhc3RJbm5ib3VuZEFuZE91dGJvdW5kQ2hhbmdlczpWYWx1ZTowXSBbQWN0aW9uOkNyZWF0ZV0gW0FjdGlvbkRhdGU6MjAxOC0wNy0xNlQxNjowOTozMS41MDcyMjVaXSBbSXNQdWJsaWM6ZmFsc2VdCg==";

            Console.WriteLine(Zip(value));
        }

        private string Zip(string value)
        {
            //Transform string into byte[]
            byte[] byteArray = new byte[value.Length];
            int indexBA = 0;
            foreach (char item in value.ToCharArray())
            {
                byteArray[indexBA++] = (byte)item;
            }

            //Prepare for compress
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.Compression.GZipStream sw = new System.IO.Compression.GZipStream(ms,
                System.IO.Compression.CompressionMode.Compress);

            //Compress
            sw.Write(byteArray, 0, byteArray.Length);
            //Close, DO NOT FLUSH cause bytes will go missing...
            sw.Close();

            //Transform byte[] zip data to string
            byteArray = ms.ToArray();
            System.Text.StringBuilder sB = new System.Text.StringBuilder(byteArray.Length);
            foreach (byte item in byteArray)
            {
                sB.Append((char)item);
            }
            ms.Close();
            sw.Dispose();
            ms.Dispose();
            return sB.ToString();
        }


        private void foo3()
        {

            var msg = new YourMessage { SuportCode = "abc", MessageBody = "body" };
            msg["ServerID"] = "abc";
            var s = JsonConvert.SerializeObject(msg);

            JObject jo = JObject.FromObject(msg);
            jo.Add(new JProperty("ServerID", "abc"));

            Console.WriteLine(jo.ToString());

            Console.WriteLine(s);

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
