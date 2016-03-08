using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CSDemo
{
    public class SearializerDemo
    {
        public void Run()
        {
            //TestXmlSerializer();
            //TestXmlDeserializer();
            //TestBinaryFormatter();
            //TestDeBinaryFormatter();
            TestISerializable();
            TestDeISerializable();
            Console.WriteLine("Done");
        }

        private void TestXmlSerializer()
        {
            Student std = new Student() { Name="Mark",Age=20};
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            using (Stream stream = new FileStream(@"Student.xml", FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                xs.Serialize(stream, std);
            }
        }

        private void TestXmlDeserializer()
        {
            Student std = null;
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            using (FileStream fs =new FileStream(@"Student.xml",FileMode.Open,FileAccess.Read))
            {
                std = (Student)xs.Deserialize(fs);
            }

            Console.WriteLine(std.Name);
        }

        private void TestBinaryFormatter() 
        {
            Student std = new Student() { Name = "Mark", Age = 20 };
            Teacher ter = new Teacher() { Name = "Jim", Age = 21 };

            using (FileStream  fs =new FileStream(@"Student.dat", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs,std);
                bf.Serialize(fs,ter);
            }
        }

        private void TestDeBinaryFormatter()
        {
            Student std = null;
            Teacher ter = null;

            using (FileStream fs = new FileStream(@"Student.dat", FileMode.Open,FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                std = (Student)bf.Deserialize(fs);
                ter = (Teacher)bf.Deserialize(fs);
            }

            Console.WriteLine(ter.Name);
        }

        private void TestISerializable()
        {
            People std = new People() { Name = "Mark", Age = 20 };

            using (FileStream fs = new FileStream(@"People.dat", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, std);
            }
        }

        private void TestDeISerializable()
        {
            People std = null;

            using (FileStream fs = new FileStream(@"People.dat", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                std = (People)bf.Deserialize(fs);
            }

            Console.WriteLine(std.Name);
        }
    }

    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [Serializable]
    public class Teacher
    {
        public string Name { get; set; }
        public int Age { get; set; }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            if (this.Age < 7)
            {
                this.Age = 7;
            }
        }

        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {

        }
        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {

        }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            if (this.Age < 7)
            {
                this.Age = 7;
            }
        }

    }

    [Serializable]
    public class People : ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Age", Age);
        }

        public People()
        { }

        protected People(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("Name");
            Age = info.GetInt32("Age");
        }

    }
}
