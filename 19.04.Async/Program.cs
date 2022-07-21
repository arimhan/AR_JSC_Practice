using System;
using System.Threading.Tasks;
using static System.Console;
//690p async 한정자와 await 연산자로 만드는 비동기 코드
//async로 한정하는 메소드는 반환 형식이 Task, Task<TResult>, void여야 한다.
//=> async로 한정한 ~를 반환하는 메소드/태스크/람다식은 await연산자를 만나는 곳에서 호출자에게 제어를 돌려주며 await연산자가 없는 경우 동기로 실행된다.
namespace _19._04.Async
{
    internal class Program
    {
        async static private void MyMethodAsync(int count)
        {
            WriteLine("C");
            WriteLine("D");
            await Task.Run(async () =>
            {
                for (int i = 1; i <= count; i++)
                {
                    WriteLine($"{i}/{count}... ");
                    await Task.Delay(100);  //Thread.Sleep()의 비동기 버전
                }
            });
            WriteLine("G");
            WriteLine("H");
        }
        static void Caller()
        {
            WriteLine("A");
            WriteLine("B");
            MyMethodAsync(3);
            WriteLine("E");
            WriteLine("F");
        }
        static void Main(string[] args)
        {
            Caller();
            ReadLine(); //프로그램 종료 방지
        }
    }
}
