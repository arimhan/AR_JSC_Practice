using System;
//using static System.Console;

namespace DelegateDemo
{
    class Program
    {
        delegate float SumHandler(float a, float b);
        SumHandler sumHandler;

        private float Sum(float a, float b)
        {
            return a + b;
        }
        private void Start()
        {
            sumHandler = Sum;
            float sum = sumHandler(10.0f, 5.0f);
            Console.WriteLine($"Sum = {sum}");
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
    }
}
