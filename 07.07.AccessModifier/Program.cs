using System;

namespace _07._7.AccessModifier
{
    class WaterHeater
    {
        protected int temperature;
        public void SetTemperature(int temperature)
        {
            if(temperature < -5 || temperature>42)
            {
                throw new Exception("Out of temperature range");
            }
            this.temperature = temperature;
        }
        internal void TurnOnWater()
        {
            Console.WriteLine($"Turn on water : {temperature}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WaterHeater heater = new WaterHeater();
                heater.SetTemperature(20);
                heater.TurnOnWater();
                heater.SetTemperature(-2);
                heater.TurnOnWater();
                heater.SetTemperature(50);  //try에서 범위를 벗어났기 때문에 실행시에는 이 행은 무시하며, 
                heater.TurnOnWater();

            }
            catch (Exception e)             //디버깅 시 32줄 부분에서 Out of temperature range 라며 예외가 발생한다.
            { 
                Console.WriteLine(e.Message); 
            }
        }
    }
}
