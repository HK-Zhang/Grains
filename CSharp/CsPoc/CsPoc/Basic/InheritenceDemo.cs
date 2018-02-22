using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    class InheritenceDemo
    {
        public static void Execute() 
        {

            //CClass c = new CClass();
            //c.Print();

            //Console.WriteLine("----");
            //BClass bc = new BClass();
            //bc.Print();

            //Console.WriteLine("----");


            var newObj = new NewClass();
            newObj.integer = "I'm a string";
            Console.WriteLine(newObj.integer);

            PClass pobj = newObj;
            Console.WriteLine(pobj.integer);

        }

        private static void Foo1()
        {
            ParentDef pdf = new ParentDef();
            ParentDef pc = new ChildDef();
            ChildDef cdf = new ChildDef();


            Console.WriteLine("V1");
            Console.WriteLine(pdf.value);


            Console.WriteLine("V2");
            Console.WriteLine(pc.value);

            Console.WriteLine("V3");
            Console.WriteLine(cdf.value);
            Console.WriteLine(cdf.READONLYSTRING);
        }
    }

    class ParentDef
    {
        public const string Const_String = "Parent Const Varialbe";
        public static string STATICVALUE_STRING = "Parent Static Variable";
        public string value = "Parent Instant Variable";
    }

    class ChildDef:ParentDef
    {
        public readonly string READONLYSTRING="Child readonly variable";
        public readonly static string READONLYSTATICSTRING = "Child readonly  static variable";
        public static string STATICVALUE_STRING = "Child Static Variable";
        public string value = "Child Instant Variable";

        public ChildDef() 
        {
            READONLYSTRING = "NEW Child readonly variable";
            //READONLYSTATICSTRING = "NEW Child readonly  static variable"; ERROR as satatic readonly variable can not be reassianged in instant constructor
        }
    }

    public class AClass
    {
        public virtual void Print() 
        {
            Console.WriteLine("AClass");
        }

        public AClass()
        {
            Print();
        }
    }

    public class CClass:AClass
    {
        int y = 1;
        public override void Print()
        {
            base.Print();
            Console.WriteLine(y);
        }

        public CClass() 
        {
            y = 2;
        }
    }

    public class BClass : AClass
    {
        int y = 1;
        public new void Print()
        {
            base.Print();
            Console.WriteLine(y);
        }

        public BClass()
        {
            y = 2;
        }
    }

    public class PClass
    {
        public virtual int integer { get; set; }
    }


    public class OverrideClass:PClass
    {
        //public override string integer { get; set; }
    }

    public class NewClass : PClass
    {
        public new string integer { get; set; }
    }
}
