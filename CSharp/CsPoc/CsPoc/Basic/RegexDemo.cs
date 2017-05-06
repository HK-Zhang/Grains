using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CSDemo
{
    public class RegexDemo
    {
        public void Execute()
        {
            //FooMatch();
            //FooReplace();
            //Foo();
            //Foo2();
            //Foo3();
            //Foo1();
            //FooSplit();
            Foo1();
        }


        private void FooMatch()
        {
            Match m = Regex.Match("abracadabra", "(a|b|r)+");
            Console.WriteLine("Match=" + m.ToString()); //Match=abra
        }

        private void Foo1()
        {
            //bool t = Regex.IsMatch("abracadabra", "(a|b|r)+");
            bool t = Regex.IsMatch("1241243", @"[^\d]");

            Console.WriteLine(t);

            t = Regex.IsMatch("12adf", @"[^\d]");

            Console.WriteLine(t);
        }

        private void FooSplit() 
        {

            string str = "ajaajsbbbjsccsc";
            string[] sArray = Regex.Split(str, "js", RegexOptions.IgnoreCase);
            foreach (string i in sArray)
                Console.WriteLine(i);

            sArray = Regex.Split(str, "js|j|s", RegexOptions.IgnoreCase);
            foreach (string i in sArray)
                Console.WriteLine(i);

            sArray = Regex.Split(str, "j|s", RegexOptions.IgnorePatternWhitespace);
            foreach (string i in sArray)
                Console.WriteLine(i);

            IEnumerable<string> se = Regex.Split(str, "j|s|js", RegexOptions.IgnoreCase).Where(x => x.Length > 0);
            foreach (string i in se)
                Console.WriteLine(i);

            //string[] s =Regex.Split("abracadabra", "(a|b|r)+");
            //foreach (string t in s)
            //{
            //    Console.WriteLine(t);
            //}
        }

        private void FooReplace()
        {
            string s = Regex.Replace("abracadabra", "abra", "zzzz");
            Console.WriteLine(s);//zzzzcadzzzz
            s = Regex.Replace(" abra ", @"^\s*(.*?)\s*$", "$1");
            Console.WriteLine(s);//abra

            string str = "window NT, window CE";
            s = Regex.Replace(str, "^(.*?)(NT)(.*?)(CE)$", "$1$4$3$2");
            Console.WriteLine(s); //window CE, window NT 
        }

        private void Foo()
        {
            string text = "abracadabra1abracadabra2abracadabra3";
            string pat = @"(abra(cad)?)+";

            Regex r = new Regex(pat);

            //获得组号码的清单 
            int[] gnums = r.GetGroupNumbers();

            //首次匹配 
            Match m = r.Match(text);

            while (m.Success)
            {
                //从组1开始 
                for (int i = 1; i < gnums.Length; i++)
                {
                    Group g = m.Groups[gnums[i]];

                    //获得这次匹配的组 
                    Console.WriteLine("Group" + gnums[i] + "=[" + g.ToString() + "]");

                    //计算这个组的起始位置和长度 
                    CaptureCollection cc = g.Captures;

                    for (int j = 0; j < cc.Count; j++)
                    {
                        Capture c = cc[j];
                        Console.WriteLine(" Capture" + j + "=[" + c.ToString()+ "] Index=" + c.Index + " Length=" + c.Length);
                    }
                }
                //下一个匹配 
                m = m.NextMatch();
            }
        }

        private void Foo2()
        {
            string text = "the quick red fox jumped over the lazy brown dog.";

            System.Console.WriteLine("text=[" + text + "]");

            string result = "";

            string pattern = @"\w+|\W+";
            //string pattern = @"\w+";


            foreach (Match m in Regex.Matches(text, pattern))
            {

                // 取得匹配的字符串 

                string x = m.ToString();

                // 如果第一个字符是小写 

                if (char.IsLower(x[0]))

                    // 变成大写 

                    x = char.ToUpper(x[0]) + x.Substring(1, x.Length - 1);

                // 收集所有的字符 

                result += x;

            }

            System.Console.WriteLine("result=[" + result + "]");
        }

        private void Foo3()
        {
            string text = "the quick red fox jumped over the lazy brown dog.";
            System.Console.WriteLine("text=[" + text + "]");
            string pattern = @"\w+";
            string result = Regex.Replace(text, pattern, new MatchEvaluator(CapText));
            System.Console.WriteLine("result=[" + result + "]"); 
        }

        private static string CapText(Match m)
        {
            //取得匹配的字符串 
            string x = m.ToString();

            // 如果第一个字符是小写 
            if (char.IsLower(x[0]))
                // 转换为大写 
                return char.ToUpper(x[0]) + x.Substring(1, x.Length - 1);

            return x;
        } 
    }
}
