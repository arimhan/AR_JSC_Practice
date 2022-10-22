using System;

namespace _07._11.MethodHiding
{
    class Base
    {
        public void MyMethod()
        {
            Console.WriteLine("Base.MyMethod()");
        }
    }
    class Derived : Base
    {
        public new void MyMethod()  //파생 클래스 버전의 메소드를 new 한정자로 수식 -> 메소드 숨기기 가능
        {
            Console.WriteLine("Derived.MyMethod()");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Base baseObj = new Base();
            baseObj.MyMethod();

            Derived derivedObj = new Derived();
            derivedObj.MyMethod();

            Base baseOrDerived = new Derived(); //동적할당 시, Derived가 아닌 Base클래스를 호출해 Derived 클래스의 메소드를 숨기고 Base클래스의 메소드를 출력한다.
            baseOrDerived.MyMethod();
        }
    }
}
