using static System.Console;
namespace _03._01.SignedUnsigned
{
    class MainApp
    {
        static void Main(string[] args)
        {
            //byte 형식 255는 1111 1111
            //sbyte 형식으로 변환할 경우 -127이 출력되어야 하지만 2의 보수법으로 음수표현을
            //하기 때문에 -1값이 출력된다.
            byte a = 255;
            sbyte b = (sbyte)a;

            WriteLine(a);
            WriteLine(b);
        }
    }
}