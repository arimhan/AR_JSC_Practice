using System;
using static System.Console;
namespace _13._06.EventTest
{
    delegate void EventHandler(string message);
    class MyNotifier
    {
        public event EventHandler SomethingHappened;
        public void DoSomething(int number)
        {
            int temp = number % 10; // 10 이상일 경우 10으로 나눠 나머지 값으로 확인하기
            if(temp != 0 && temp % 3 == 0)
            {
                SomethingHappened(String.Format("{0} : 짝", number));
            }
        }
    }
    internal class Program
    {
        static public void MyHandler(string message)
        {
            WriteLine(message);
        }
        static void Main(string[] args)
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler);

            for(int i = 1; i<30; i++)
            {
                notifier.DoSomething(i);
            }
        }
    }
}
