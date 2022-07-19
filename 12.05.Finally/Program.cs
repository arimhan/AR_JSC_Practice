using System;
using static System.Console;
namespace _12._05.Finally
{
    internal class Program
    {
        static int Divide(int dividend, int divisor)
        {
            try
            {
                WriteLine("Divide() 시작");
                return dividend / divisor;
            }
            catch (DivideByZeroException e)
            {
                WriteLine("Divide() 예외 발생");
                throw e;    //예외가 일어나도 finally구문이 실행된다.
            }
            finally         //보통 Close나 자원해제같은걸 넣어 사용한다. (뒷정리 코드)
            {
                WriteLine("Divide() 끝");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Write("제수를 입력하세요 : ");
                String temp = Console.ReadLine();
                int dividend = Convert.ToInt32(temp);

                Write("피제수를 입력하세요 : ");
                temp = Console.ReadLine();
                int divisor = Convert.ToInt32(temp);

                WriteLine($"{dividend}/{divisor} = {Divide(dividend, divisor)}");
            }
            catch(FormatException e)
            {
                WriteLine("에러 : " + e.Message);
            }
            catch(DivideByZeroException e)
            {
                WriteLine("에러 : " + e.Message);
            }
            finally
            {
                WriteLine("프로그램을 종료합니다.");
            }
        }
    }
}
