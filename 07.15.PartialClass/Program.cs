using System;

namespace _07._15.PartialClass  //분할 클래스
{
    partial class MyClass       //MyClass클래스를 2개로 분할할 수 있으며, 이 때 컴파일러는 MyClass를 하나로 묶어 컴파일 한다.
    {
        public void Method1()
        {
            Console.WriteLine("Method1");
        }
        public void Method2()
        {
            Console.WriteLine("Method2");
        }
    }
    partial class MyClass
    {
        public void Method3()
        {
            Console.WriteLine("Method3");
        }
        public void Method4()
        {
            Console.WriteLine("Method4");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            obj.Method1();
            obj.Method2();
            obj.Method3();
            obj.Method4();
        }
    }
}
