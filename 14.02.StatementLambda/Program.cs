using System;
using static System.Console;
namespace _14._02.StatementLambda
{
    internal class Program
    {
        delegate string Concatenate(string[] args);
        static void Main(string[] args)
        {
            string[] input = ReadLine().Split();
            Concatenate concat = 
                (arr) =>
            {
                string result = "";
                foreach (string s in arr)
                    result += s;

                return result;
            };
            WriteLine(concat(input));
            //WriteLine(concat(args));
        }
    }
}
