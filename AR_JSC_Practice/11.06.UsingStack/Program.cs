using System;
using static System.Console;
using System.Collections.Generic;
namespace _11._06.UsingGenericStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            while(stack.Count > 0)
                 WriteLine(stack.Pop());
        }
    }
}
