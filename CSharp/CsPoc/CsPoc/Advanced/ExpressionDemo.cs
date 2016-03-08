using CsPoc;
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
            Foo2();
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
    }
}
