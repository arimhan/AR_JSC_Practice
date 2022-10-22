using System;
//초기화 전용 자동 구현 프로퍼티
namespace _09._04.InitOnly
{
    class Transaction
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
            Transaction tr1 = new Transaction { From = "Alice", To = "Bob", Amount = 100};  
            Transaction tr2 = new Transaction { From = "Bob", To = "Charlie", Amount = 50 };
            Transaction tr3 = new Transaction { From = "Charlie", To = "Alice", Amount = 50 };
            //tr1.Amount = 30; //tr1~3초기화 이후 프로퍼티 수정 불가
            Console.WriteLine(tr1);
            Console.WriteLine(tr2);
            Console.WriteLine(tr3);
        }
    }
}
