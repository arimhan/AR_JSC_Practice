using System;
using static System.Console;
namespace _12._06.MyException
{
    class InvalidArgumentException : Exception     //사용자 정의 예외 클래스
    {
        public InvalidArgumentException() { }
        public InvalidArgumentException(string message) : base(message) { }    
        public object Argument { get; set; }
        public string Range { get; set; }
    }
    internal class Program
    {
        static uint MergeARGB(uint alpha, uint red, uint green, uint blue)
        {
            uint[] args = new uint[] { alpha, red, green, blue };
            foreach (uint arg in args)
            {
                if (arg > 255)
                {
                    throw new InvalidArgumentException()
                    {
                        Argument = arg,
                        Range = "0~255"
                    };
                }
            }
            return  (alpha << 24 & 0xFF000000) |
                    (red << 16 & 0x00FF0000)   |
                    (green << 8 & 0x0000FF00)  |
                    (blue & 0x000000FF);
        }
        static void Main(string[] args)
        {
            try
            {
                WriteLine("0x{0:X}", MergeARGB(255, 111, 111, 111));
                WriteLine("0x{0:X}", MergeARGB(1,   65,  192, 128));
                WriteLine("0x{0:X}", MergeARGB(0,   255, 255, 300));

            }
            catch (InvalidArgumentException e)
            {
                WriteLine(e.Message);
                WriteLine($"Argument : {e.Argument},  Range : {e.Range}");
            }
        }
    }
}
