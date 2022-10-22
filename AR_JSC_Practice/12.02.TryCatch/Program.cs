using System;
using static System.Console;
namespace _12._02.TryCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3 };

            try    //실행하고자 하는 코드
            {
                for (int i = 0; i < 5; i++)
                {
                    WriteLine(arr[i]);  //for문에서 i값이 배열사이즈보다 커서 예외가 발생한다.
                }
            }
            //예외가 발생했을 때의 처리. catch는 여러개가 가능하다.
            catch (IndexOutOfRangeException e)   //디버깅에서 예외발생 시 이 부분에서 예외출력이 되며 다음으로 넘어가 예외메시지를 출력한다.
            {
                WriteLine($"예외가 발생했습니다 : {e.Message}");
            }
            WriteLine("종료");
        }
    }
}
