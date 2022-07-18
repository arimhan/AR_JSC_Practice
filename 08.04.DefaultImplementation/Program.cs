using System;

namespace _08._04.DefaultImplementation
{
    interface ILogger
    {
        void WriteLog(string message);
        void WriteError(string error) //새로운 메소드 추가
        {
            WriteLog($"Error: {error}");
        }
    }
    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
        }
        /*public void WriteError(string message)
        {
            Console.WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
        }*/
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            logger.WriteLog("System Up");
            logger.WriteError("System Fail");

            ConsoleLogger clogger = new ConsoleLogger();
            clogger.WriteLog("System Up");
            //clogger.WriteError("System Fail");    //ConsoleLogger 에서 주석처리된 WriteError를 재정의 해야 컴파일 성공함.
        }
    }
}
