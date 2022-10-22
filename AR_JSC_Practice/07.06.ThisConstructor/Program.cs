using System;

namespace _07._6.ThisConstructor
{
    class MyClass
    {
        int a, b, c;
        public MyClass()
        {
            this.a = 5425;
            Console.WriteLine("MyClass()");
        }
        public MyClass(int b) : this()
        {
            this.b = b;
            Console.WriteLine($"MyClass({b})");
        }
        public MyClass(int b, int c) : this(b)  //이전에 구현한 MyClass(int b)를 호출하여 MyClass(int b, int c)의 int b 의 매개변수로 넣는다.
        {
            this.c = c;
            Console.WriteLine($"MyClass({b}),({c})");
        }
        public void PrintFields()
        {
            Console.WriteLine($"a: {a}, b:{b}, c:{c}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass a = new MyClass();
            a.PrintFields();
            Console.WriteLine();

            MyClass b = new MyClass(1);
            b.PrintFields();
            Console.WriteLine();

            MyClass c = new MyClass(10, 20);
            c.PrintFields();
        }
    }
}
