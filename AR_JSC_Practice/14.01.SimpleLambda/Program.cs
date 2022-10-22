using System;
using static System.Console;
namespace _14._01.SimpleLambda
{
    internal class Program
    {
        delegate int Calculater(int a, int b);
        static void Main(string[] args)
        {
            Calculater calc = (a, b) => a + b;
            WriteLine($"{3} + {4} :  {calc(3, 4)}"); 
        }
    }
}
