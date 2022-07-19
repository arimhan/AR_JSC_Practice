using System;
using static System.Console;
//대리자 : 대리자 선언 후, 호출자에서 대리자 호출시도 시 대리자는 해당 메소드를 호출한다.
//대리자는 메소드의 주소를 참조하고 있어 메서드를 대신 호출이 가능하며,
//C, C++의 참조 포인터와 유사하지만 데이터 타입을 안전하게 처리한다는 장점이 있다.
//메서드 -> 메서드 전달 or 메서드 조합(연결) 시 Func, Action 대리자 사용
namespace _13._01.Delegate
{
    delegate int MyDelegate(int a, int b);  //대리자 선언, 대리자가 참조하는 메서드와 반환 타입 및 매개변수가 동일해야 한다.
    class Calculator
    {
        public int Plus(int a, int b)       //대리자는 인스턴스 메소드, 정적 메소드 모두 참조 가능.
        {
            return a + b;
        }
        public static int Minus(int a, int b)
        {
            return a - b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator Calc = new Calculator();
            MyDelegate Callback;

            Callback = new MyDelegate(Calc.Plus);
            WriteLine(Callback(3,4));               //메소드를 호출하듯 대리자를 사용하면 참조하고 있는 메소드 실행.
            Callback = new MyDelegate(Calculator.Minus);
            WriteLine(Callback(7, 5));
        }
    }
}
