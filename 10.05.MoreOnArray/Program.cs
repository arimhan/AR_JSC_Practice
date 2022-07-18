using System;

namespace _10._05.MoreOnArray
{
    internal class Program
    {
        private static bool CheckPassed(int score)
        {
            return score >= 60;
        }
        private static void Print(int value)
        {
            Console.WriteLine($"{value} ");
        }
        static void Main(string[] args)
        {
            int[] scores = new int[] { 80, 74, 81, 90, 34 };
            foreach (int score in scores)
                Console.WriteLine($"{score} ");
            Console.WriteLine();

            Array.Sort(scores); //scores 내 값 오름차순 정렬
            Array.ForEach<int>(scores, new Action<int>(Print));
            Console.WriteLine();

            Console.WriteLine($"Number of dimensions : {scores.Rank}");
            Console.WriteLine($"Binary Search : 81 is at" + $"{Array.BinarySearch<int>(scores, 81)}"); //배열index

            Console.WriteLine($"Linear Search : 90 is at" + $"{Array.IndexOf(scores, 90)}");
            Console.WriteLine($"Everyone passed ?: " + $"{Array.TrueForAll<int>(scores, CheckPassed)}");

            int index = Array.FindIndex<int>(scores, (score) => score < 60);
            scores[index] = 61;
            Console.WriteLine($"Everyone passed ?: " + $"{Array.TrueForAll<int>(scores, CheckPassed)}");
            Console.WriteLine($"Old length of scores: " + $"{scores.GetLength(0)}");

            Array.Resize<int>(ref scores, 10);
            Console.WriteLine($"New length of scores: " + $"{scores.Length}");

            Array.ForEach<int>(scores, new Action<int>(Print));
            Console.WriteLine();

            Array.Clear(scores, 3, 7);              //3번부터 7개 요소를 지우기?
            Array.ForEach<int>(scores, new Action<int>(Print));

            int[] sliced = new int[3];
            Array.Copy(scores, 0, sliced, 0, 3);    //0번부터 3개 요소를 차례대로 복사
            Array.ForEach<int>(sliced, new Action<int>(Print));
            Console.WriteLine();
        }
    }
}
