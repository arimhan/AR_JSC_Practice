using System;
using System.Collections;
using static System.Console;
namespace _10._16.Yield
{
    class MyEnumrator
    {
        int[] numbers = { 1, 2, 3, 4 };
        public IEnumerator GetEnumerator()
        {
            yield return numbers[0];
            yield return numbers[1];
            yield return numbers[2];
            yield break;            //GetEnumerator() 메소드 종료시키므로 아래[3]은 실행하지 않음.
            yield return numbers[3];
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyEnumrator();
            foreach (int i in obj)
                WriteLine(i);
        }
    }
}
