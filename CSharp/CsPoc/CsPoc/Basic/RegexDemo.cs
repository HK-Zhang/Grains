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
            //BasicFoo();
            //PickOneFoo();
            //SpecialCharacterFoo();
            //GroupFoo();
            GreedyFoo();
        }

        private void BasicFoo() 
        {
            string i = "\n";
            string m = "3";
            Regex r = new Regex(@"\D");
            Console.WriteLine(r.IsMatch(i));//ture
            Console.WriteLine(r.IsMatch(m));//flase

            r = new Regex("[a-z0-9]");
            Console.WriteLine(r.IsMatch(i));//false
            Console.WriteLine(r.IsMatch(m));//true

            i = "Live for nothing,die for something";
            r = new Regex("^Live for nothing,die for something$");//true
            Console.WriteLine(r.IsMatch(i));
            r = new Regex("^Live for nothing,die for some$");//false
            Console.WriteLine(r.IsMatch(i));
            r = new Regex("^Live for nothing,die for some");//true
            Console.WriteLine(r.IsMatch(i));

            i = @"Live for nothing,
die for something";//mutiple lines

            r = new Regex("^Live for nothing,die for something$");
            Console.WriteLine("r match count:" + r.Matches(i).Count);//0

            r = new Regex("^Live for nothing,die for something$", RegexOptions.Multiline);
            Console.WriteLine("r match count:" + r.Matches(i).Count);//0

            r = new Regex("^Live for nothing,\r\ndie for something$");
            Console.WriteLine("r match count:" + r.Matches(i).Count);//1

            r = new Regex("^Live for nothing,$");
            Console.WriteLine("r match count:" + r.Matches(i).Count);//0

            r = new Regex("^Live for nothing,$", RegexOptions.Multiline);
            Console.WriteLine("r match count:" + r.Matches(i).Count);//0

            r = new Regex("^Live for nothing,\r\n$");
            Console.WriteLine("r match count:" + r.Matches(i).Count);//0

            r = new Regex("^Live for nothing,\r$");
            Console.WriteLine("r match count:" + r.Matches(i).Count);//0

            r = new Regex("^Live for nothing,\r$", RegexOptions.Multiline);
            Console.WriteLine("r match count:" + r.Matches(i).Count);//1

            r = new Regex("^die for something$");
            Console.WriteLine("r match count:" + r.Matches(i).Count);//0

            r = new Regex("^die for something$", RegexOptions.Multiline);
            Console.WriteLine("r match count:" + r.Matches(i).Count);//1

            r = new Regex("^");
            Console.WriteLine("r match count:" + r.Matches(i).Count);//1

            r = new Regex("$");
            Console.WriteLine("r match count:" + r.Matches(i).Count);//1

            r = new Regex("^", RegexOptions.Multiline);
            Console.WriteLine("r match count:" + r.Matches(i).Count);//2

            r = new Regex("$", RegexOptions.Multiline);
            Console.WriteLine("r match count:" + r.Matches(i).Count);//2

            r = new Regex("^Live for nothing,\r$\n^die for something$", RegexOptions.Multiline);
            Console.WriteLine("r16 match count:" + r.Matches(i).Count);//1
            //对于一个多行字符串，在设置了Multiline选项之后，^和$将出现多次匹配。

            i = "Live for nothing,die for something";
            m = "Live for nothing,die for some thing";

            r = new Regex(@"\bthing\b");
            Console.WriteLine("r match count:" + r.Matches(i).Count);//0

            r = new Regex(@"thing\b");
            Console.WriteLine("r match count:" + r.Matches(i).Count);//2

            r = new Regex(@"\bthing\b");
            Console.WriteLine("r match count:" + r.Matches(m).Count);//1
            
            r = new Regex(@"\bfor something\b");
            Console.WriteLine("r match count:" + r.Matches(i).Count);//1
            //\b通常用于约束一个完整的单词

            string x = "1024";
            string y = "+1024";
            string z = "1,024";
            string a = "1";
            string b = "-1024";
            string c = "10000";
            r = new Regex(@"^\+?[1-9],?\d{3}$");

            Console.WriteLine("x match count:" + r.Matches(x).Count);//1
            Console.WriteLine("y match count:" + r.Matches(y).Count);//1
            Console.WriteLine("z match count:" + r.Matches(z).Count);//1
            Console.WriteLine("a match count:" + r.Matches(a).Count);//0
            Console.WriteLine("b match count:" + r.Matches(b).Count);//0
            Console.WriteLine("c match count:" + r.Matches(c).Count);//0
            //匹配1000到9999的整数。

        }

        private void PickOneFoo() 
        {
            string x = "0";
            string y = "0.23";
            string z = "100";
            string a = "100.01";
            string b = "9.9";
            string c = "99.9";
            string d = "99.";
            string e = "00.1";
            Regex r = new Regex(@"^\+?((100(.0+)*)|([1-9]?[0-9])(\.\d+)*)$");
            Console.WriteLine("x match count:" + r.Matches(x).Count);//1
            Console.WriteLine("y match count:" + r.Matches(y).Count);//1
            Console.WriteLine("z match count:" + r.Matches(z).Count);//1
            Console.WriteLine("a match count:" + r.Matches(a).Count);//0
            Console.WriteLine("b match count:" + r.Matches(b).Count);//1
            Console.WriteLine("c match count:" + r.Matches(c).Count);//1
            Console.WriteLine("d match count:" + r.Matches(d).Count);//0
            Console.WriteLine("e match count:" + r.Matches(e).Count);//0
            //匹配0到100的数。最外层的括号内包含两部分“(100(.0+)*)”，“([1-9]?[0-9])(\.\d+)*”，这两部分是“OR”的关系，即正则表达式引擎会先尝试匹配100，如果失败，则尝试匹配后一个表达式（表示[0,100)范围中的数字）。
        }

        private void SpecialCharacterFoo()
        {
            string x = "\\";
            Regex r1 = new Regex("^\\\\$");
            Console.WriteLine("r1 match count:" + r1.Matches(x).Count);//1
            Regex r2 = new Regex(@"^\\$");
            Console.WriteLine("r2 match count:" + r2.Matches(x).Count);//1
            Regex r3 = new Regex("^\\$");
            Console.WriteLine("r3 match count:" + r3.Matches(x).Count);//0
            //匹配“\”

            x = "\"";
            r1 = new Regex("^\"$");
            Console.WriteLine("r1 match count:" + r1.Matches(x).Count);//1
            r2 = new Regex(@"^""$");
            Console.WriteLine("r2 match count:" + r2.Matches(x).Count);//1
            //匹配双引号
        }

        private void GroupFoo()
        {
            string x = "Live for nothing,die for something";
            string y = "Live for nothing,die for somebody";
            Regex r = new Regex(@"^Live ([a-z]{3}) no([a-z]{5}),die \1 some\2$");
            Console.WriteLine("x match count:" + r.Matches(x).Count);//1
            Console.WriteLine("y match count:" + r.Matches(y).Count);//0
            //正则表达式引擎会记忆“()”中匹配到的内容，作为一个“组”，并且可以通过索引的方式进行引用。表达式中的“\1”，用于反向引用表达式中出现的第一个组，即粗体标识的第一个括号内容，“\2”则依此类推。

            x = "Live for nothing,die for something";
            r = new Regex(@"^Live for no([a-z]{5}),die for some\1$");
            if (r.IsMatch(x))
            {
                Console.WriteLine("group1 value:" + r.Match(x).Groups[1].Value);//输出：thing
            }
            //获取组中的内容。注意，此处是Groups[1]，因为Groups[0]是整个匹配的字符串，即整个变量x的内容。

            x = "Live for nothing nothing";
            r = new Regex(@"([a-z]+) \1");
            if (r.IsMatch(x))
            {
                x = r.Replace(x, "$1");
                Console.WriteLine("var x:" + x);//输出：Live for nothing
            }
            //删除原字符串中重复出现的“nothing”。在表达式之外，使用“$1”来引用第一个组，下面则是通过组名来引用：

            //x = "Live for nothing nothing";
            //r = new Regex(@"(?[a-z]+) \1");
            //if (r.IsMatch(x))
            //{
            //    x = r.Replace(x, "${g1}");
            //    Console.WriteLine("var x:" + x);//输出：Live for nothing
            //}

            x = "Live for nothing";
            r = new Regex(@"^Live for no(?:[a-z]{5})$");
            if (r.IsMatch(x))
            {
                Console.WriteLine("group1 value:" + r.Match(x).Groups[1].Value);//输出：(空)
            }
            //在组前加上“?:”表示这是个“非捕获组”，即引擎将不保存该组的内容。

        }

        private void GreedyFoo()
        {
            string x = "Live for nothing,die for something";
            Regex r1 = new Regex(@".*thing");
            if (r1.IsMatch(x))
            {
                Console.WriteLine("match:" + r1.Match(x).Value);//输出：Live for nothing,die for something
            }
            Regex r2 = new Regex(@".*?thing");
            if (r2.IsMatch(x))
            {
                Console.WriteLine("match:" + r2.Match(x).Value);//输出：Live for nothing
            }
        }

        private void reverseFoo()
        {
            string x = "Live for nothing,die for something";
            Regex r1 = new Regex(@".*thing,");
            if (r1.IsMatch(x))
            {
                Console.WriteLine("match:" + r1.Match(x).Value);//输出：Live for nothing,
            }
            Regex r2 = new Regex(@"(?>.*)thing,");
            if (r2.IsMatch(x))//不匹配
            {
                Console.WriteLine("match:" + r2.Match(x).Value);
            }
            //在r1中，“.*”由于其贪婪特性，将一直匹配到字符串的最后，随后匹配“thing”，但在匹配“,”时失败，此时引擎将回溯，并在“thing,”处匹配成功。在r2中，由于强制非回溯，所以整个表达式匹配失败。
        }


        private void FooMatch()
        {
            Match m = Regex.Match("abracadabra", "(a|b|r)+");
            Console.WriteLine("Match=" + m.ToString()); //Match=abra
        }

        private void Foo1()
        {
            bool t = Regex.IsMatch("abracadabra", "(a|b|r)+");
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

        private void FooCapitalFirstCharacter()
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

        private void FooCapitalFirstCharacter2()
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
