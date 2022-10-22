using System;
using static System.Console;
//익명 메소드 : 자신을 참조할 대리자의 형식과 동일한 형식으로 선언. 
//대리자가 참조할 메소드를 넘길 경우, 이 메소드가 일회용일 때 사용.
namespace _13._05.AnonymousMethod
{
    delegate int Compare(int a, int b);
    internal class Program
    {
        static void BubbleSort(int[] DataSet, Compare Comparer)     //메소드와 
        {
            int i = 0;
            int j = 0;
            int temp = 0;
            for (i = 0; i < DataSet.Length - 1; i++)    //DataSet의 마지막 인덱스 접근하기 위해 Length-1
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
            BubbleSort(array, delegate (int a, int b)   //익명메소드 선언, 오름차순 정렬
                {
                    if (a > b)
                        return 1;
                    else if (a == b)
                        return 0;
                    else
                        return -1;
                });
            for (int i = 0; i < array.Length; i++) 
                Write($"{array[i]} ");

            int[] array2 = { 7, 2, 8, 10, 11 };
            WriteLine("\nSorting descending...");
            BubbleSort(array2, delegate (int a, int b)  //익명메소드 선언, 내림차순 정렬
            {
                if (a < b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            });
            for (int i = 0; i < array2.Length; i++)
                Write($"{array2[i]} ");
            WriteLine();
        }
    }
}
