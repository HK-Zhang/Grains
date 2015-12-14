using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class InitializerDemo
    {
        public void Execute()
        {
            Rectangle r2 = new Rectangle() { P1 = new Point { X = 3, Y = 3 }, P2 = new Point { X = 2, Y = 2 } };
            List<int> digits = new List<int> { 1,2,3,4,5,6,7,8,9,10};
        }
    }

    class AnonymousDemo
    {
        
        public void Execute() 
        {
            var p1 = new { Name = "ABC", Age = 21 };
            var p2 = new { Name = "DEF", Age =32};

        }
    }

    class ImplictArrayDemo
    {
        public void Execute()
        {
            var a = new[] {1,2,3,4,5 };

            var contacts = new[] { new { Name = "Chris Smith", PhoneNumbers = new[] { "206-555-0101", "425-882-8080" } }, 
                new { Name = "Bob Harris", PhoneNumbers = new[] { "650-555-0199" } } };

        }
    }

    class ExtensionDemo
    {
        public static void Execute() 
        {
            string s = "1234";
            int a=3+s.ToInt32();
            Console.WriteLine(a);
        }
    }

    class PartialDemo
    {
        partial void OnSomethingHappend(string s);
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Rectangle
    {
        Point p1 = new Point { X = 0, Y = 0 };
        Point p2 = new Point { X = 1, Y = 1 };

        public Point P1 { get { return p1; } set { p1 = value; } }
        public Point P2 { get { return p2; } set { p2 = value; } }
    }

    public class Contact
    {
        string name;
        List<string> phoneNumbers = new List<string>();

        public string Name {get{return name;} set{name=value;}}
        public List<string> PhoneNumbers { get { return phoneNumbers; } }
    }
}
