using static System.Console;
namespace _03._03.IntegralConversion
{
    class MainApp
    {
        static void Main(string[] args)
        {
            sbyte a = 127;
            WriteLine(a);

            int b = (int)a;
            WriteLine(b);

            int x = 128; // sbyte는 최대값이 127임.
            WriteLine(x);

            //여기서 이미 언더플로우가 일어남. 127 -> -128
            sbyte y = (sbyte)x;
            WriteLine(y);
        }
    }
}