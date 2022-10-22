using System;
//레코드 -> 인스턴스 생성 시 불변 객체 생성됨
namespace _09._05.Record
{
 record RTransaction
    {
        public string From { get; init; }
        public string To { get; init; }
        public int Amount { get; init; }
        public override string ToString()
        {
            return $"{From,-10} -> {To,-10} : ${Amount}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            RTransaction tr1 = new RTransaction { From = "Alice", To = "Bob", Amount = 100 };
            RTransaction tr2 = new RTransaction { From = "Alice", To = "Charlie", Amount = 100 };
            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
        }
    }
}
