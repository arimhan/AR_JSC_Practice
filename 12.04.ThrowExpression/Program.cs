using System;
using static System.Console;
namespace _12._04.ThrowExpression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int? a = null;
                //int ?a = 0;
                int b = a ?? throw new ArgumentNullException(); //a가 null이므로 할당불가. 바로 throw한다.
            }
            catch (ArgumentNullException e)
            {
                WriteLine(e);
            }
            try
            {
                int[] array = new[] { 1, 2, 3 };
                int index = 2;  //2;    
                int value = array[index >= 0 && index <3 ? index : throw new IndexOutOfRangeException()];
                //array의 사이즈가 3으로 범위를 벗어나서 바로 throw한다.
                //설정한 index의 크기가 0보다 크고 max보다 작을경우 해당 index의 value를 찾아 반환한다.
            }
            catch (IndexOutOfRangeException e)
            {
                WriteLine(e);
            }
        }
    }
}
