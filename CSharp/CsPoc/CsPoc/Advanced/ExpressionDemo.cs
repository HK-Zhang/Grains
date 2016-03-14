using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSDemo
{
    public class ExpressionDemo
    {
        public static void Execute()
        {
            //Foo1();
            //Foo2();
            //Foo3();
            //Foo4();
            //Foo5();
            //Foo6();
            //Foo7();
            //Foo8();
            Foo9();
        }

        public static string ConsStr(object str)
        {
            string _str = str + "aa";
            Console.WriteLine(_str);
            return _str;
        }

        public string ConsStr2(object str)
        {
            string _str = str + "aa";
            Console.WriteLine(_str);
            return _str;
        }




        private static void Foo1() 
        {
            Expression<Func<Person, bool>> exp = p => p.Name.Contains("ldp") && p.Birthday.Year > 1990;
            var p1 = new Person { Name = "Henryldp", Birthday = new DateTime(2000, 1, 1) };
            Console.WriteLine(exp.Compile().Invoke(p1));
        }

        private static void Foo2()
        {
            var p1 = new Person { Name = "Henryldp", Birthday = new DateTime(2000, 1, 1) };

            var parameter = Expression.Parameter(typeof(Person), "p");
            var left = Expression.Call(
                Expression.Property(parameter, "Name"),
                typeof(string).GetMethod("Contains"),
                Expression.Constant("ldp"));
            var right = Expression.GreaterThan(
                Expression.Property(Expression.Property(parameter, "Birthday"), "Year"),
                Expression.Constant(1990));
            var body = Expression.AndAlso(left, right);
            var lambda = Expression.Lambda<Func<Person, bool>>(body, parameter);

            Console.WriteLine(lambda.Compile().Invoke(p1));
        }

        private static void Foo3()
        {
            ConstantExpression _constExp = Expression.Constant("aaa", typeof(string));//一个常量
            MethodCallExpression _methodCallexp = Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), _constExp);
            Expression<Action> consoleLambdaExp = Expression.Lambda<Action>(_methodCallexp);
            consoleLambdaExp.Compile()();
        }

        private static void Foo4()
        {
            ParameterExpression _parameExp = Expression.Parameter(typeof(string), "MyParameter");

            MethodCallExpression _methodCallexpP = Expression.Call(typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), _parameExp);
            Expression<Action<string>> _consStringExp = Expression.Lambda<Action<string>>(_methodCallexpP, _parameExp);
            _consStringExp.Compile()("Hello!!");
        }

        private static void Foo5()
        {
            ParameterExpression _paraObj = Expression.Parameter(typeof(object), "objPara");
            MethodCallExpression _MyStateMethod = Expression.Call(typeof(ExpressionDemo).GetMethod("ConsStr", new Type[] { typeof(object) }), _paraObj);
            Expression<Func<object, string>> _meyLambdaState = Expression.Lambda<Func<object, string>>(_MyStateMethod, _paraObj);
            string s_tr = _meyLambdaState.Compile()("ni Hao");
            Console.WriteLine("return value: " + s_tr);

        }

        private static void Foo6()
        {
            ExpressionDemo _pg = new ExpressionDemo();
            ParameterExpression _paraObj2 = Expression.Parameter(typeof(object), "objPara");
            MethodCallExpression _MyStateMethod2 = Expression.Call(Expression.Constant(_pg), typeof(ExpressionDemo).GetMethod("ConsStr2"), _paraObj2);
            Expression<Func<object, string>> _meyLambdaState2 = Expression.Lambda<Func<object, string>>(_MyStateMethod2, _paraObj2);
            string s_tr2 = _meyLambdaState2.Compile()("you shi ni ");
            Console.WriteLine("return value: " + s_tr2);
        }

        private static void Foo7()
        {
            ConstantExpression _consNum = Expression.Constant(5, typeof(int));
            UnaryExpression _unaryPlus = Expression.Decrement(_consNum);
            Expression<Func<int>> _unaryLam = Expression.Lambda<Func<int>>(_unaryPlus);
            Console.WriteLine(_unaryLam.Compile()());

        }

        private static void Foo8()
        {
            ParameterExpression _ParaA = Expression.Parameter(typeof(int), "a");
            ParameterExpression _ParaB = Expression.Parameter(typeof(int), "b");
            BinaryExpression _BinaAdd = Expression.Add(_ParaA, _ParaB);
            Expression<Func<int, int, int>> _MyBinaryAddLamb = Expression.Lambda<Func<int, int, int>>(_BinaAdd, new ParameterExpression[] { _ParaA, _ParaB });
            Console.WriteLine("Expression：  " + _MyBinaryAddLamb);
            Console.WriteLine(_MyBinaryAddLamb.Compile()(3, 6));
        }

        private static void Foo9()
        {
            ParameterExpression _ParaA = Expression.Parameter(typeof(int), "a");
            ParameterExpression _ParaB = Expression.Parameter(typeof(int), "b");
            BinaryExpression _BinaAdd = Expression.Add(_ParaA, _ParaB);  //a+b

            ParameterExpression _paraC = Expression.Parameter(typeof(int), "c");
            UnaryExpression _paraDecr = Expression.Decrement(_paraC);    //(a+b)*(--c)
            BinaryExpression _binaMultiply = Expression.Multiply(_BinaAdd, _paraDecr);
            Expression<Func<int, int, int, int>> _MyBinaryLamb = Expression.Lambda<Func<int, int, int, int>>(_binaMultiply, new ParameterExpression[] { _ParaA, _ParaB, _paraC });
            Console.WriteLine("Expression：  " + _MyBinaryLamb);
            Console.WriteLine(_MyBinaryLamb.Compile()(3, 6, 5));

        }

    }
}
