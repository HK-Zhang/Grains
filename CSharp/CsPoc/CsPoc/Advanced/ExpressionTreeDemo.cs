using System;
using System.Linq.Expressions;
namespace CsPoc.Advanced
{
    public class ExpressionTreeDemo
    {
        public void Execute()
        {
            //InvocationExpressionFoo();
            //BinaryExpressionFoo();
            FlowControlExpression();
        }

        public void Foo1()
        {
            WhereFunc(x => x == string.Empty);
            WhereExpr(x => x == string.Empty);
        }

        public void WhereFunc(Func<string, bool> fun)
        {
        }

        public void WhereExpr(Expression<Func<string, bool>> expr)
        { 
        }

        public void InvocationExpressionFoo()
        {
            Expression<Func<bool, bool>> boolTest = t => t;
            Expression<Func<int, int, bool>> largeSumTest = (num1, num2) => (num1 + num2) > 1000;
            InvocationExpression invocationExpression = Expression.Invoke(largeSumTest, Expression.Constant(10), Expression.Constant(20));
            Console.WriteLine(invocationExpression.ToString());

            Expression<Func<bool, bool>> expr = Expression.Lambda<Func<bool, bool>>(Expression.Or(boolTest.Body, invocationExpression), boolTest.Parameters);

            Console.WriteLine(expr.Compile()(false));
  
        }

        public void BinaryExpressionFoo()
        {
            ParameterExpression pe = Expression.Parameter(typeof(int), "value");
            ConstantExpression ce = Expression.Constant(5, typeof(int));
            BinaryExpression lessThanExpr = Expression.LessThan(pe, ce);
            Expression<Func<int, bool>> lamda = Expression.Lambda<Func<int, bool>>(lessThanExpr, new ParameterExpression[] { pe });
            Console.WriteLine(lamda.Compile()(4));

        }

        public void FlowControlExpression()
        {
            // Creating a parameter expression.
            ParameterExpression valueExpr = Expression.Parameter(typeof(int), "value");

            // Creating an expression to hold a local variable. 
            ParameterExpression resultExpr = Expression.Parameter(typeof(int), "result");

            // Creating a label to jump to from a loop.
            LabelTarget label = Expression.Label(typeof(int));

            // Creating a method body.
            BlockExpression blockExpr = Expression.Block(
                // Adding a local variable.
                new[] { resultExpr },
                // Assigning a constant to a local variable: result = 1
                Expression.Assign(resultExpr, Expression.Constant(1)),
                // Adding a loop.
                Expression.Loop(
                // Adding a conditional block into the loop.
                Expression.IfThenElse(
                // Condition: value > 1
                Expression.GreaterThan(valueExpr, Expression.Constant(1)),
                // If true: result *= value --
                Expression.MultiplyAssign(resultExpr, Expression.PostDecrementAssign(valueExpr)),
                // If false, exit the loop and go to the label.
                Expression.Break(label, resultExpr)
                ),
                // Label to jump to.
       label
                )
                );

            // Compile and execute an expression tree.
            int factorial = Expression.Lambda<Func<int, int>>(blockExpr, valueExpr).Compile()(5);

            Console.WriteLine(factorial);
            // Prints 120.


        }

    }
}
