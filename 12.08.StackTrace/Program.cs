using System;
using static System.Console;
namespace _12._08.StackTrace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = 1;
                WriteLine(3 / --a); // 3/0에 대한 예외처리 발생
            }
            catch (DivideByZeroException e)
            {
                WriteLine(e.StackTrace); //StackTrace 프로퍼티는 문제가 발생한 부부의 소스코드 위치를 반환한다.
            }
        }
    }
}
