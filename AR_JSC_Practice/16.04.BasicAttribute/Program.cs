using System;
using static System.Console;
//Attribute 애트리뷰트 : 코드에 대한 부가 정보 기록. 주석과는 조금 다른 개념.
//설명하고자 하는 코드 요소 앞에 [ 애트리뷰트_이름(애트리뷰트_매개변수) ] 방식으로 사용한다.
namespace _16._04.BasicAttribute
{
    class MyClass
    {
        [Obsolete("OldMethod()는 폐기되었습니다. NewMethod()를 이용하세요.")] //VS내 or 콘솔창에서 경고메시지 [사용되지 않음]
        public void OldMethod()
        {
            WriteLine("I'm Old");
        }
        public void NewMethod()
        {
            WriteLine("I'm New");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();
            obj.OldMethod();
            obj.NewMethod();
        }
    }
}
