using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLibrary
{
    public abstract class Pet
    {
        public abstract string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }



    public class Cat : Pet
    {
        public override string Name { get; set; }
    }



    public class Dog : Pet
    {
        public override string Name { get; set; }
    }



    public class Person
    {
        public string Name { get; set; }
        public int Salary { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
