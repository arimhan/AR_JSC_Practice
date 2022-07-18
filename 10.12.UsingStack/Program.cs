using System;
using System.Collections;
namespace _10._12.UsingStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            while(stack.Count > 0)
                Console.WriteLine(stack.Pop()); //맨 위에 있는(나중에 넣은) 값부터 Pop으로 꺼낸다.
        }
    }
}
