using System;
using System.Collections; //컬렉션(자료구조)
//ArrayList , Queue, Stack, Hashtable

namespace _10._10.UsingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach(object obj in list)
                Console.Write($"{obj} ");
            Console.WriteLine();

            list.RemoveAt(2);   //값 2를 삭제
            foreach (object obj in list)
                Console.Write($"{obj} ");
            Console.WriteLine();

            list.Insert(2, 2);  //배열[2]에 2를 삽입
            foreach (object obj in list)
                Console.Write($"{obj} ");
            Console.WriteLine();

            list.Add("abc");
            list.Add("def");

            for(int i =0; i<list.Count; i++)
                Console.Write($"{list[i]} ");
            Console.WriteLine();
        }
    }
}
