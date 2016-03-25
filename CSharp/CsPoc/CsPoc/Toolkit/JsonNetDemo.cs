using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc.Toolkit
{
    public class JsonNetDemo
    {
        private DataTable dt = new DataTable();

        public JsonNetDemo()
        {
            dt.Columns.Add("Age", Type.GetType("System.Int32"));
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Sex", Type.GetType("System.String"));
            dt.Columns.Add("IsMarry", Type.GetType("System.Boolean"));
            for (int i = 0; i < 4; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Age"] = i + 1;
                dr["Name"] = "Name" + i;
                dr["Sex"] = i % 2 == 0 ? "男" : "女";
                dr["IsMarry"] = i % 2 > 0 ? true : false;
                dt.Rows.Add(dr);
            }
        }

        public void Execute()
        {
            BasicFoo1();
            //BasicFoo2();
            //Foo3();
            //Foo4();
            //Foo5();
            //Foo6();
        }

        private void BasicFoo1()
        {
            Console.WriteLine(JsonConvert.SerializeObject(dt));
        }

        private void BasicFoo2()
        {
            string json = JsonConvert.SerializeObject(dt);
            dt = JsonConvert.DeserializeObject<DataTable>(json);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t", dr[0], dr[1], dr[2], dr[3]);
            }

        }

        private void Foo3()
        {
            Person p = new Person { Age = 10, Name = "张三丰", Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
            JsonSerializerSettings js = new JsonSerializerSettings();
            js.DefaultValueHandling = DefaultValueHandling.Ignore;
            Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, js));
        }

        private void Foo4()
        {
            Person p = new Person { Age = 10, Name = null, Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
            JsonSerializerSettings jsetting = new JsonSerializerSettings();
            jsetting.NullValueHandling = NullValueHandling.Ignore;
            Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, jsetting));
        }

        private void Foo5()
        {
            Person p = new Person { Age = 10, Name = null, Sex = "男", IsMarry = false, Birthday = new DateTime(1991, 1, 2) };
            JsonSerializerSettings jsetting = new JsonSerializerSettings();

            string[] propNames = null;
            if (p.Age > 10)
            {
                propNames = new string[] { "Age", "IsMarry" };
            }
            else
            {
                propNames = new string[] { "Age", "Sex" };
            }
            jsetting.ContractResolver = new LimitPropsContractResolver(propNames);
            Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, jsetting));

            //jsetting.ContractResolver = new LimitPropsContractResolver(new string[] { "Age", "IsMarry" });
            //Console.WriteLine(JsonConvert.SerializeObject(p, Formatting.Indented, jsetting));
        }

        private void Foo6()
        {
            Console.WriteLine(JsonConvert.SerializeObject(new TestEnmu()));
        }

    }

    [JsonObject(MemberSerialization.OptOut)]
    public class Person
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string room { get; set; }

        [DefaultValue(10)]
        public int Age { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        [JsonConverter(typeof(BoolConvert))]
        public bool IsMarry { get; set; }

        [JsonConverter(typeof(ChinaDateTimeConverter))]
        public DateTime Birthday { get; set; }
    }

    public class ChinaDateTimeConverter : DateTimeConverterBase
    {
        private static IsoDateTimeConverter dtConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" };

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return dtConverter.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            dtConverter.WriteJson(writer, value, serializer);
        }
    }

    public class LimitPropsContractResolver : DefaultContractResolver
    {
        string[] props = null;

        bool retain;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="props">传入的属性数组</param>
        /// <param name="retain">true:表示props是需要保留的字段  false：表示props是要排除的字段</param>
        public LimitPropsContractResolver(string[] props, bool retain = true)
        {
            //指定要序列化属性的清单
            this.props = props;

            this.retain = retain;
        }

        protected override IList<JsonProperty> CreateProperties(Type type,

        MemberSerialization memberSerialization)
        {
            IList<JsonProperty> list =
            base.CreateProperties(type, memberSerialization);
            //只保留清单有列出的属性
            return list.Where(p =>
            {
                if (retain)
                {
                    return props.Contains(p.PropertyName);
                }
                else
                {
                    return !props.Contains(p.PropertyName);
                }
            }).ToList();
        }
    }

        public enum NotifyType
    {
        /// <summary>
        /// Emil发送
        /// </summary>
        Mail=0,

        /// <summary>
        /// 短信发送
        /// </summary>
        SMS=1
    }

    public class TestEnmu
    {
        /// <summary>
        /// 消息发送类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public NotifyType Type { get; set; }
    }

    public class BoolConvert : JsonConverter
    {
        private string[] arrBString { get; set; }

        public BoolConvert()
        {
            arrBString = "是,否".Split(',');
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="BooleanString">将bool值转换成的字符串值</param>
        public BoolConvert(string BooleanString)
        {
            if (string.IsNullOrEmpty(BooleanString))
            {
                throw new ArgumentNullException();
            }
            arrBString = BooleanString.Split(',');
            if (arrBString.Length != 2)
            {
                throw new ArgumentException("BooleanString格式不符合规定");
            }
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool isNullable = IsNullableType(objectType);
            Type t = isNullable ? Nullable.GetUnderlyingType(objectType) : objectType;

            if (reader.TokenType == JsonToken.Null)
            {
                if (!IsNullableType(objectType))
                {
                    throw new Exception(string.Format("不能转换null value to {0}.", objectType));
                }

                return null;
            }

            try
            {
                if (reader.TokenType == JsonToken.String)
                {
                    string boolText = reader.Value.ToString();
                    if (boolText.Equals(arrBString[0], StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                    else if (boolText.Equals(arrBString[1], StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }

                if (reader.TokenType == JsonToken.Integer)
                {
                    //数值
                    return Convert.ToInt32(reader.Value) == 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error converting value {0} to type '{1}'", reader.Value, objectType));
            }
            throw new Exception(string.Format("Unexpected token {0} when parsing enum", reader.TokenType));
        }

        /// <summary>
        /// 判断是否为Bool类型
        /// </summary>
        /// <param name="objectType">类型</param>
        /// <returns>为bool类型则可以进行转换</returns>
        public override bool CanConvert(Type objectType)
        {
            return true;
        }


        public bool IsNullableType(Type t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }
            return (t.BaseType.FullName == "System.ValueType" && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            bool bValue = (bool)value;

            if (bValue)
            {
                writer.WriteValue(arrBString[0]);
            }
            else
            {
                writer.WriteValue(arrBString[1]);
            }
        }
    }
    
}
