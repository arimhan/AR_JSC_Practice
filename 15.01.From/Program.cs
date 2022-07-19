using System;
using System.Linq;
using static System.Console;
//LINQ의 범위변수와 foreach문의 반복 변수의 차이점?
//foreach문의 반복 변수는 데이터 원본으로부터 데이터를 담아내지만, 범위 변수는 실제로 데이터를 담지는 않는다.
//그래서 쿼리식 외부에서 선언된 변수에 범위 변수의 데이터를 복사해 넣거나 하는 일은 X
//즉, foreach문의 반복 변수는 데이터 담을 수 O, LINQ의 범위변수는 X
namespace _15._01.From
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };
            var result = from    n in numbers   //numbers 데이터 원본 안에서 범위변수 n으로 뽑아낸다
                         where   n % 2 ==0
                         orderby n
                         select  n;
            foreach (int n in result)
                WriteLine($"짝수 : {n}"); 
        }
    }
}
