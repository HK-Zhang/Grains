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
}
