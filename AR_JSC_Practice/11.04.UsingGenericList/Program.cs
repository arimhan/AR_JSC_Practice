using System;
using static System.Console;
using System.Collections.Generic;
namespace _11._04.UsingGenericList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach(int element in list)
                WriteLine($"{element} ");
            WriteLine();
            list.RemoveAt(2);   //[2]번 인덱스의 값(요소)을 삭제

            foreach (int element in list)
                WriteLine($"{element} ");
            WriteLine();
            list.Insert(2, 2);  //[2]번 인덱스에 값2(요소)을 삽입

            foreach (int element in list)
                WriteLine($"{element} ");
            WriteLine();
        }
    }
}
