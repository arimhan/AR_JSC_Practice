using System;
using static System.Console;
namespace _03._06.FloatToIntegral
{
    class MainApp
    {
        static void Main(string[] args)
        {
            float a = 0.9f;
            int b = (int)a;             //반올림따윈 없다. 0.9가 잘리고 0으로 출력됨.
            WriteLine("a: {0}, b: {1}", a, b);

            float c = 1.1f;
            int d = (int)c;             //마찬가지로 뒤에 0.1이 잘리고 1로 출력됨.
            WriteLine("c: {0}, d: {1}", c, d);

        }
    }
}