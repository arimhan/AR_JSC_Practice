using System;
using static System.Console;
namespace _12._07.ExceptionFiltering
{
    class FilterableException : Exception //사용자 정의 예외 클래스. 예외 필터하기. (catch when 제약 조건)
    {
        public int ErrorNo { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter Number Between 0 ~ 10");
            string input = Console.ReadLine();
            try
            {
                int num = Int32.Parse(input);
                if (num < 0 || num > 10)
                    throw new FilterableException() { ErrorNo = num };
                else
                    WriteLine($"Output : {num}");
            }
            catch(FilterableException e ) when (e.ErrorNo < 0)
            {
                WriteLine("Negative input is not allowed.");
            }
            catch (FilterableException e) when (e.ErrorNo > 10)
            {
                WriteLine("Too big number is not allowed.");
            }
        }
    }
}
