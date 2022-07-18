using System;

namespace _07._12.SealedMethod
{
    class Base
    {
        public virtual void SealMe(){}
    }
    class Derived : Base
    {
        public sealed override void SealMe()  {}    //이 메서드만 봉인할 수 있음
    }
    class WantToOverride : Derived  
    { 
        public override void SealMe() { }           //봉인된 메서드를 재정의 불가 -> 컴파일 에러
    }
    internal class Program
    {
        static void Main(string[] args)     {   }
    }
}
// 컴파일 에러 발생
// 오류 CS0239	'WantToOverride.SealMe()': 상속된 'Derived.SealMe()' 멤버는 봉인되어 있으므로 재정의할 수 없습니다.	07.12.SealedMethod	
// C:\_HAR\C3\JSC_Arim\07.12.SealedMethod\Program.cs   15  활성

