using System;
using static System.Console;
namespace _13._03.GenericDelegate
{
    delegate int Compare<T>(T a, T b);
    internal class Program
    {
        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);
        }
        static int DescendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) * -1;     //자신보다 큰 경우 1, 같으면 0, 작으면 -1을 반환
        }
        static void BubbleSort<T>(T[] DataSet, Compare<T> Comparer)
        {
            int i = 0;
            int j = 0;
            T temp;
            for (i = 0; i < DataSet.Length-1; i++)    //DataSet의 마지막 인덱스 접근하기 위해 Length-1
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++) 
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0) //DasaSet배열에서 0번인덱스 요소와 1번인덱스 요소를 비교했을때 0번인덱스 값이 크면
                    {
                        temp = DataSet[j + 1];      //temp에 1번 인덱스 값을 넣고
                        DataSet[j + 1] = DataSet[j];//DataSet[0]값을 DataSet[1]에 넣은다음
                        DataSet[j] = temp;          //DataSet[0]에 temp값을 넣는다 ->swap
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 2, 10 };
            WriteLine("Sorting ascending...");
            BubbleSort<int>(array, new Compare<int>(AscendCompare));

            for(int  i =0; i<array.Length; i++)
                Write($"{array[i]} ");

            string[] array2 = { "abc", "def", "ghi", "jkl", "mno" };
            WriteLine("\nSorting descending...");
            BubbleSort<string>(array2, new Compare<string>(DescendCompare));

            for (int i = 0; i < array2.Length; i++)
                Write($"{array2[i]} ");
            WriteLine();
        }
    }
}
