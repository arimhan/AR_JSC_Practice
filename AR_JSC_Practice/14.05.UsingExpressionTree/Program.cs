using System;
using System.Linq.Expressions;
using static System.Console;
namespace _14._05.UsingExpressionTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Expression const1 = Expression.Constant(1);
            Expression const2 = Expression.Constant(2);

            Expression leftExp = Expression.Multiply(const1, const2);   // x * y

            Expression param1 = Expression.Parameter(typeof(int));  //x
            Expression param2 = Expression.Parameter(typeof(int));  //y

            Expression rightExp = Expression.Subtract(param1, param2);   // x - y
            Expression exp = Expression.Add(leftExp, rightExp);

            //람다식 클래스의 파생클래스인 Expression<TDelegate>를 사용한다.
            //이 경우 "동적으로" 식 트리를 만들기 어렵다. (Expression 불변)
            Expression<Func<int, int, int>> expression = Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>
                (exp, new ParameterExpression[] { (ParameterExpression)param1, (ParameterExpression)param2 });

            Func<int, int, int> func = expression.Compile();
            WriteLine($"1 * 2 + ({7} - {8}) = {func(7,8)}");
        }
    }
}
