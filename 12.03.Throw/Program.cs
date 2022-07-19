using System;
using static System.Console;
namespace _12._03.Throw
{
    internal class Program
    {
        static void DoSomething(int arg)
        {
            if (arg < 10)
                WriteLine($"arg : {arg}");
            else
                throw new Exception("arg가 10보다 큽니다.");  //2. 예외 발생-> Exception에 이 예외메시지를 넘겨서
        }
        static void Main(string[] args)
        {
            try
            {
                DoSomething(1);
                DoSomething(3);
                DoSomething(5);
                DoSomething(9);
                DoSomething(11);    //1. 여기서 예외발생하여 다음 코드 실행X
                DoSomething(13);
            }  
            catch (Exception e)     //3.예외 메시지를 e로 받아 출력한다.
            {
                WriteLine(e.Message);
            }
        }
    }
}
