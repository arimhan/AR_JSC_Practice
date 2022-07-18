using System;

//인터페이스와  클래스, 추상클래스가 다른 점?
//인터페이스 : 클래스와 비슷. 메서드, 이벤트, 프로퍼티 소유 , 구현X (한 번에 여러 클래스 상속 가능)
//추상클래스 : 구현 O , 인스턴스 X, 추상 메소드 O(인터페이스의 역할을 할 수 있도록 도와줌 => 파생클래스에서 반드시 구현하도록 강제함)
//추상 클래스 상속하는 추상 클래스 만들 수 있음.
//추상 메소드 : public, protected, internal, protected internal 한정자 중 하나 사용
//추상 클래스 상속받는 클래스는 반드시 추상 메서드를 구현해야 함
//추상 클래스가 다른 추상 클래스 상속 시 구현X 괜찮음
namespace _08._05.AbstractClass
{
    abstract class AbstractBase
    {
        protected void PrivateMethodA()
        {
            Console.WriteLine("AbstractBase.PrivateMethodA()");
        }
        public void PublicMethodA()
        {
            Console.WriteLine("AbstractBase.PublicMethodA()");
        }
        public abstract void AbstractMethodA();
    }
    class Derived : AbstractBase
    {
        public override void AbstractMethodA()
        {
            Console.WriteLine("Derived.AbstractMethodA()");
            PrivateMethodA();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            AbstractBase obj = new Derived();
            //AbstractBase obj = new AbstractBase(); 이렇게 사용이 불가능함.
            obj.AbstractMethodA();
            obj.PublicMethodA();
        }
    }
}
