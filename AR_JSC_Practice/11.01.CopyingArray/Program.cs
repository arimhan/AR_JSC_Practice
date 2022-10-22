using System;
using static System.Console;
namespace _11._01.CopyingArray
{
    internal class Program
    {
        static void CopyArray<T>(T[] source, T[] target) //<T>에 int, string의 자료형 대입하여 사용 가능
        {
            for (int i=0; i<source.Length; i++)
                target[i] = source[i];
        }
        static void Main(string[] args)
        {
            int[] source = { 1, 2, 3, 4, 5 };
            int[] target = new int[source.Length];
            CopyArray<int>(source, target);
            foreach(int element in target)
                WriteLine(element);

            string[] source2 = { "하나", "둘", "셋", "넷", "다섯" };
            string[] target2 = new string[source2.Length];
            CopyArray<string>(source2, target2);
            foreach (string element in target2)
                WriteLine(element);
        }
    }
}
