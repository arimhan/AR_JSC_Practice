using System;
using static System.Console;
//Dynamic 형식
namespace _17._01.DuckTyping
{
    class MyClass
    {
        public void FuncA()
        { WriteLine(this.GetType() + ".FuncA()"); }
    }
    class Duck
    {
        public void Walk()
        { WriteLine(this.GetType() + ".Walk"); }
        public void Swin()
        { WriteLine(this.GetType() + ".Swin"); }
        public void Quack()
        { WriteLine(this.GetType() + ".Quack"); }
    }
    class Mallard : Duck
    { }
    class Robot
    {
        public void Walk()
        { WriteLine("Robot.Walk"); }
        public void Swin()
        { WriteLine("Robot.Swin"); }
        public void Quack()
        { WriteLine("Robot.Quack"); }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic[] arr = new dynamic[] { new Duck(), new Mallard(), new Robot() };

            foreach(dynamic duck in arr)
            {
                WriteLine(duck.GetType());
                duck.Walk();
                duck.Swin();
                duck.Quack();
                WriteLine();
            }
            /*
             * MyClass 내에 FuncB가 없기 때문에, obj는 FuncB가에서 컴파일 에러 발생.
             * dynamic으로 선언한 obj에서는 실행은 되지만 실행 도중 에러 발생. -> 컴파일 할 때 형식 검사를 같이 하지 않음. (이후에 함!)
             * 또한 리팩토링 기능 사용 불가. (ex. Walk() -> Run() 수정 불가. 해당 메소드 사용하는 곳에서 일일히 수정해야 함.)
            //MyClass obj = new MyClass();
            dynamic obj = new MyClass();
            obj.FuncA();
            obj.FuncB();
            */
        }
    }
}
