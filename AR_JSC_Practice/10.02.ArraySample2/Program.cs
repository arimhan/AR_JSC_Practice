using System;

namespace _10._02.ArraySample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] scores = new int[5];
            scores[0] = 80;
            scores[1] = 74;
            scores[2] = 81;
            scores[^2] = 90;     //배열의 마지막 -1 => 뒤에서 두번째
            scores[^1] = 34;     //배열의 마지막 => 뒤에서 첫번째

            foreach (int score in scores)
                Console.WriteLine(score);

            int sum = 0;
            foreach (int score in scores)
                sum += score;
            int average = sum / scores.Length;
            Console.WriteLine($"Average Score:  {average}");
        }
    }
}
