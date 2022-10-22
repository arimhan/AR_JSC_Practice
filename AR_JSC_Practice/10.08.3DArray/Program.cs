using System;

namespace _10._08._3DArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = new int[4, 3, 2]
            {
                {{1, 2}, {3, 4 },{5, 6 } },
                {{1, 4}, {2, 5 },{3, 6 } },
                {{6, 5}, {4, 3 },{2, 1 } },
                {{6, 3}, {5, 2 },{4, 1 } },
            };

            for (int i=0; i<array.GetLength(0); i++)
            {
                for(int j=0; j<array.GetLength(1); j++) //1행씩
                {
                    Console.Write("{ ");
                    for(int k=0; k < array.GetLength(2); k++)   //2개의 요소 출력
                    {
                        Console.Write($"{array[i, j, k]} ");
                    }
                    Console.Write("} ");
                }
                Console.WriteLine("");
            }
        }
    }
}
