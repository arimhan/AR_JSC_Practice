using System;
using MyExtension;  //확장 메소드를 담는 클래스의 네임스페이스 사용
// static 메소드 선언(this, 확장하고자 하는 클래스(형식)의 인스턴스, 확장 메소드 호출 시 입력되는 매개변수)
namespace MyExtension       //확장 메소드 : 기존 클래스의 기능을 확장하는 방법.
{
    public static class IntegerExtension
    {
        public static int Square(this int myInt)
        {
            return myInt * myInt;
        }
        public static int Power(this int myInt, int exponent)
        {
            int result = myInt;
            for (int i = 0; i < exponent; i++)
                result = result * myInt;
            return result;
        }
    }
}

namespace _07._16.ExtensionMethod
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"3^2 : {3.Square()}");
            Console.WriteLine($"3^4 : {3.Power(4)}");
            Console.WriteLine($"2^10 : {2.Power(10)}");
        }
    }
}
