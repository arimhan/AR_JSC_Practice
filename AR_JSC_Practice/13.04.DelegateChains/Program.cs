using System;
using static System.Console;
//대리자 체인(468p) : 대리자 하나가 여러 개의 메소드 동시에 참조 가능한 속성
// += or Delegate.Combine(d1, d2), -= or Delegate.Remove(~.EventOccured, d1) 로 체인 연결 및 해제 가능
namespace _13._04.DelegateChains
{
    delegate void Notify(string message);
    class Notifier
    {
        public Notify EventOccured;
    }
    class EventListener
    {
        private string name;
        public EventListener(string name)
        {
            this.name = name;
        }
        public void SomethingHappend(string message)
        {
            WriteLine($"{name}.SomethingHappend : {message}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier();
            EventListener listener1 = new EventListener("Listener1");
            EventListener listener2 = new EventListener("Listener2");
            EventListener listener3 = new EventListener("Listener3");
            notifier.EventOccured += listener1.SomethingHappend;    // +=를 활용해 listener1~3을 체인으로 연결한다.
            notifier.EventOccured += listener2.SomethingHappend;
            notifier.EventOccured += listener3.SomethingHappend;
            notifier.EventOccured("You've got mail.");
            WriteLine();

            notifier.EventOccured -= listener2.SomethingHappend;    // -=를 활용해 체인에서 제외 가능하다. (출력 listener1,3)
            notifier.EventOccured("Download complete.");
            WriteLine();

            notifier.EventOccured = new Notify(listener2.SomethingHappend) + new Notify(listener3.SomethingHappend);
            notifier.EventOccured("Nuclear launch detected.");  //위 +연산을 활용해 listener2+3을 새롭게 체인화 한다.
            WriteLine();

            Notify notify1 = new Notify(listener1.SomethingHappend);
            Notify notify2 = new Notify(listener2.SomethingHappend);
            notifier.EventOccured = (Notify)Delegate.Combine(notify1, notify2); //위 notify1,2로 listener1,2를 새롭게 구성한 뒤, Delegate.Combine메소드로 체인으로 연결한다.
            notifier.EventOccured("Fire!!");
            WriteLine();

            notifier.EventOccured = (Notify)Delegate.Remove(notifier.EventOccured, notify2); //위 연결된 listener1,2에서 2만 제외하면 listener1만 출력된다.
            notifier.EventOccured("RPG!");
            WriteLine();
        }
    }
}
