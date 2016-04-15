using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace CsPoc.Advanced
{
    public class SerializeDemo
    {
        public void Execute()
        {
            TestSerialization();
        }
        private string Serialize<T>(MediaTypeFormatter formatter, T value)
        {
            // Create a dummy HTTP Content.
            // 创建一个HTTP内容的哑元
            Stream stream = new MemoryStream();
            var content = new StreamContent(stream);

            // Serialize the object.
            // 序列化对象
            formatter.WriteToStreamAsync(typeof(T), value, stream, content, null).Wait();

            // Read the serialized string.
            // 读取序列化的字符串
            stream.Position = 0;
            return content.ReadAsStringAsync().Result;
        }

        private T Deserialize<T>(MediaTypeFormatter formatter, string str) where T : class
        {
            // Write the serialized string to a memory stream.
            // 将序列化的字符器写入内在流
            Stream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;

            // Deserialize to an object of type T
            // 解序列化成类型为T的对象
            return formatter.ReadFromStreamAsync(typeof(T), stream, null, null).Result as T;
        }

        private void TestSerialization()
        {
            var value = new Person() { Name = "Alice", Birthday = DateTime.Now };

            var xml = new XmlMediaTypeFormatter();
            string str = Serialize(xml, value);

            var json = new JsonMediaTypeFormatter();
            json.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            str = Serialize(json, value);
            Console.WriteLine(str);
            // Round trip
            // 反向操作（解序列化）
            Person person2 = Deserialize<Person>(json, str);
            Console.WriteLine(person2.Birthday);
        }
    }
}
