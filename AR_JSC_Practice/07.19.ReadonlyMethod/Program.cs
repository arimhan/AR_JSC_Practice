using System;

namespace _07._19.ReadonlyMethod
{
    struct ACSetting
    {
        public double currentInCelsius;
        public double target;
        public readonly double GetFahrenheit()
        {
            //target = currentInCelsius * 1.8 + 32; //읽기 전용인 target에는 할당할 수 없다는 컴파일 에러
            //return target;
            return currentInCelsius * 1.8 + 32;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ACSetting acs;
            acs.currentInCelsius = 25;
            acs.target = 25;
            Console.WriteLine($"{acs.GetFahrenheit()}");
            Console.WriteLine($"{acs.target}");
        }
    }
}
