using System;
using static System.Console;
using System.Collections.Generic;
namespace _11._05.UsingGenericQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            while(queue.Count > 0)
                WriteLine(queue.Dequeue());
        }
    }
}
