using System;

namespace _07._8.Inheritance
{
    class Base
    {
        protected string Name;
        public Base(string Name)
        {
            this.Name = Name;
            Console.WriteLine($"{this.Name}.Base()");
        }
        ~Base()     //소멸자는 .NET 5(.NET Core포함) 이상 버전일 경우 애플리케이션 종료될 때 소멸자 호출X (GC.Collect()를 호출하면 강제 실행됨)
        {
            Console.WriteLine($"{this.Name}.~Base()");
        }
        public void BaseMethod()
        {
            Console.WriteLine($"{Name}.BaseMethod()");
        }
    }
    class Derived : Base    //상속
    {
        public Derived(string Name) : base(Name)
        {
            Console.WriteLine($"{this.Name}.Derived()");
        }
        ~Derived()
        {
            Console.WriteLine($"{this.Name}.~Derived()");
        }
        public void DerivedMethod()
        {
            Console.WriteLine($"{Name}.DerivedMethod()");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Base a = new Base("a");
            a.BaseMethod();

            Derived b = new Derived("b");
            b.BaseMethod();
            b.DerivedMethod();
            //GC.Collect();
        }
    }
}
