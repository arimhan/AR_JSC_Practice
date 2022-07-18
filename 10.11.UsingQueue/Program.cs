using System;
using System.Collections;
namespace _10._11.UsingQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue que = new Queue();
            que.Enqueue(1); //키워드를 사용해서 값을 추가
            que.Enqueue(2);
            que.Enqueue(3);
            que.Enqueue(4);
            que.Enqueue(5);
            while(que.Count>0)
                Console.WriteLine(que.Dequeue());   //뺄 값을 Dequeue로 옮긴다
        }
    }
}
