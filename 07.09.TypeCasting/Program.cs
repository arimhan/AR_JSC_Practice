using System;
//형식 변환을 위한 연산자
//is : 객체가 해당 형식에 해당하는지 검사하여 그 결과를 bool 값으로 반환
//as : 형식 변환 연산자와 같은 역할을 함. 형식 변환 연산자는 변환 실패 시 예외가 발생하지만, as연산자는 변환 실패 시 객체 참조를 null로 만들어 더 안전하다.
namespace _07._9.TypeCasting
{
    class Mammal
    {
        public void Nurce()
        {
            Console.WriteLine("Nurse()");
        }
    }
    class Dog : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("Bark()");
        }
    }
    class Cat : Mammal
    {
        public void Meow()
        {
            Console.WriteLine("Meow()");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Mammal mammal = new Dog();
            Dog dog;

            if(mammal is Dog)
            {
                dog = (Dog)mammal;  //mammal 객체가 Dog형식을 확인 후 형변환 처리
                dog.Bark();
            }
            Mammal mammal2 = new Cat();
            Cat cat = mammal2 as Cat;   //mammal2 객체가 (Dog),(Mammal)형식변환 대신 as연산자를 사용하여 형변환처리
            if(cat != null)
                cat.Meow();
            Cat cat2 = mammal as Cat;   //mammal 객체는 이미 Dog형식으로 형변환 처리 되었으므로, cat2는 형변환 실패로 null이 들어가서 아래 행을 건너뛴다.
            if (cat2 != null)
                cat2.Meow();
            else
            Console.WriteLine("cat2 is not a Cat");
        }
    }
}
