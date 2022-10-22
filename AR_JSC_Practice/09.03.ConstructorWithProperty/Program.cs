using System;
//프로퍼티를 이용한 초기화
namespace _09._03.ConstructorWithProperty
{
    class BirthdayInfo
    {
        public string Name
        { get; set; }
        public DateTime Birthday
        { get; set; }
        public int Age
        { get
            {
                return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BirthdayInfo birth = new BirthdayInfo() //프로퍼티 생성자를 활용한 초기화
            {
                Name = "서현",
                Birthday = new DateTime(1991, 6, 28)
            };
            Console.WriteLine($"Name : {birth.Name}");
            Console.WriteLine($"Birthday : {birth.Birthday.ToShortDateString()}");
            Console.WriteLine($"Age : {birth.Age}");
        }
    }
}
