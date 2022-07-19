using System;
using static System.Console;
namespace _12._01_KillingProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };
            for(int i =0; i<5; i++)
            {
                WriteLine(arr[i]);  //for문에서 i값이 배열사이즈보다 커서 예외가 발생한다.
            }
            WriteLine("종료");
        }
    }
}
