using static System.Console;
namespace _03._05.SignedInsignedConversion
{
    class MainApp
    {
        static void Main(string[] args)
        {
            //74p) SigneUnsignedConversion

            int a = 500;
            uint b = (uint)a;
            WriteLine("a: {0}, b: {1}", a, b);

            //uint는 0 ~ 4,294,967,295인데 -30이면 최대값인 4294967295 - 29 = 4294967266으로 언더플로우가 발생한다.
            int x = -30;
            uint y = (uint)x;
            WriteLine("x: {0}, y: {1}", x, y);

        }
    }
}