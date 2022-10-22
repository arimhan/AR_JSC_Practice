using System;
using System.Threading;
using static System.Console;
namespace _19._01.BasicThread
{
    internal class Program
    {
        static void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                WriteLine($"DoSomething : {i}");
                Thread.Sleep(10);
            }
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(DoSomething));
            WriteLine("Starting thread...");
            t1.Start();

            for(int i = 0; i < 5; i++)
            {
                WriteLine($"Main : {i}");
                Thread.Sleep(10);
            }
            WriteLine("Wating untill thread stops...");
            t1.Join();

            WriteLine("Finished");
        }
    }
}
