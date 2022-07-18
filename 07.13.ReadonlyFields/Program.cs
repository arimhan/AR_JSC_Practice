using System;

namespace _07._13.ReadonlyFields
{
    internal class Program
    {
        class Configuration
        {
            private readonly int min;
            private readonly int max;
            public Configuration(int v1, int v2)
            {
                min = v1;
                max = v2;
            }
            public void ChangeMax(int newMax)
            {
                max = newMax; //읽기 전용 필드에는 값을 할당할 수 없음. 컴파일 에러.
            }
        }
        static void Main(string[] args)
        {
            Configuration c = new Configuration(100, 10);
        }
    }
}
