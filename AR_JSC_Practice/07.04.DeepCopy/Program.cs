using System;

namespace _07.DeepCopy
{
    class MyClass
    {
        public int MyField1;
        public int MyField2;
        public MyClass DeepCopy() 
        {
            MyClass newCopy = new MyClass();
            newCopy.MyField1 = this.MyField1;
            newCopy.MyField2 = this.MyField2;
            return newCopy;
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shallow Copy");  //얕은 복사
            {
                MyClass source = new MyClass();
                source.MyField1 = 10;
                source.MyField2 = 20;
                MyClass target = source;
                target.MyField2 = 30;

                Console.WriteLine($"{source.MyField1} {source.MyField2}");
                Console.WriteLine($"{target.MyField1} {target.MyField2}");
            }
            Console.WriteLine("Deep Copy");  //깊은 복사
            {
                MyClass source = new MyClass();
                source.MyField1 = 10;
                source.MyField2 = 20;
                MyClass target = source.DeepCopy(); //실행할 경우 newCopy안에 초기에 세팅한 MyField1, MyField2의 값이 할당된다.
                target.MyField2 = 30;   //그리고 target에 복사한 값을 저장한 뒤, MyField2만 30으로 바꿔주면 source의 값은 10, 30, target의 값은 10, 30이 된다.

                Console.WriteLine($"{source.MyField1} {source.MyField2}");
                Console.WriteLine($"{target.MyField1} {target.MyField2}");
            }

        }
    }
}
