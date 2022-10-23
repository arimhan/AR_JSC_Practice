using static System.Console;
namespace _03._02.Overflow
{
    class MainApp
    {
        static void Main(string[] args)
        {
            uint a = uint.MaxValue;
            WriteLine(a);

            a = a + 1;
            WriteLine(a);

            //비타민 퀴즈 3-2
            int b = int.MaxValue;
            WriteLine(b);

            b = b + 1;
            WriteLine(b);

        }
    }
}