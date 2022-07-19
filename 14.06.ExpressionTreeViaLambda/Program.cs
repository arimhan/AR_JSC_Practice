using System;
using System.Linq.Expressions;
using static System.Console;
namespace _14._06.ExpressionTreeViaLambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, int, int>> expression =
                (a, b) => 1 * 2 + (a - b);
            Func<int, int, int> func = expression.Compile();
            WriteLine($"1 * 2 + ({7} - {8}) = {func(7,8)}");
        }
    }
}
