using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPoc
{
    public class DelegateDemo
    {
        public string myName;
        Action<string> myAction;
        Func<string, string> myFunc;
        Predicate<int> myPredicate;

        public DelegateDemo() 
        {
            //myAction = delegate(string name) { myName = name; };
            //myAction = new Action<string>(SetAction);
            myAction = s => { myName = s; };

            //FuncDemo fd=new FuncDemo();
            //myFunc = delegate(string curName) { return curName.ToUpper(); };
            //myFunc = new Func<string, string>(fd.Fun);
            myFunc = name => { return name.ToUpper(); };

            myPredicate = delegate(int p){
                if(p % 2 ==0) 
                    return true; 
                else 
                    return false;
            };

        }

        public void Execute() 
        {
            myAction("Hello Action");
            Console.WriteLine(myName);
            Console.WriteLine(myFunc("Hello func"));

            int[] myNum = new int[8] { 12, 3, 5, 7, 4, 2, 10, 9 };
            int[] result;
            result = Array.FindAll(myNum, myPredicate);

            Array.ForEach(result, x => Console.WriteLine(x));

        }


        private void SetAction(string name) 
        {
            myName = name;
        }
    }

    public class FuncDemo
    {
        public string Fun(string s) 
        {
            return s.ToUpper();
        }

    }
}
