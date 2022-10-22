using System;
using static System.Console;
//Action을 활용한 무명함수 만들기
//Action 대리자 : Func대리자와 거의 비슷하지만, 반환 형식이 없다는 차이가 있다.
//Action대리자의 형식 매개변수는 모두 입력 매개변수를 위해 선언되어 있다. => Func는 반환이 목적, Action은 수행이 목적이기 때문.
namespace _14._04.ActionTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action act1 = () => WriteLine("Action()"); 
            act1();

            int result = 0;
            Action<int> act2 = (x) => result = x * x;   //여기서 int는 수행 시 사용되는 입력 매개변수 타입이다.

            act2(3);
            WriteLine($"result : {result}");

            Action<double, double> act3 = (x, y) =>
            {
                double pi = x / y;
                WriteLine($"Action<T1, T2> ({x}, {y}) : {pi}");
            };
            act3(22.0, 7.0);
        }
    }
}
