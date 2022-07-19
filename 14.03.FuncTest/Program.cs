using System;
using static System.Console;
//Func를 활용한 무명함수 만들기
//Func 대리자 : 결과를 반환하는 메소드를 참조 => 가장 마지막에 있는 매개변수가 반환 형식
namespace _14._03.FuncTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int> func1 = () => 10;
            WriteLine($"func1() : {func1()}");

            Func<int, int> func2 = (x) => x * 2;
            WriteLine($"func2() : {func2(4)}");

            Func<double, double, double> func3 = (x, y) => x / y;
            WriteLine($"func3(22, 7) : {func3(22, 7)}");
        }
    }
}
