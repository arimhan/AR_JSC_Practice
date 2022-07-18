using System;
using System.IO; //파일과 데이터 스트림에 대한 읽기 및 쓰기 형식, 디렉터리 지원 형식
                 //인터페이스는 I로 시작
namespace _08._01.Interface
{
    interface ILogger
    {
        void WriteLog(string message);
    }
    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(),message);
        }
    }
    class FileLogger : ILogger
    {
        private StreamWriter writer;
        public FileLogger(string path)
        {
            writer = File.CreateText(path);
            writer.AutoFlush = true;
        }
        public void WriteLog(string message)
        {
            writer.WriteLine("{0} {1}", DateTime.Now.ToShortTimeString(), message);
        }
    }
    class ClimateMonitor
    {
        private ILogger logger;
        public ClimateMonitor(ILogger logger)
        {
            this.logger = logger;
        }
        public void start()
        {
            while(true)
            {
                Console.WriteLine("온도를 입력해주세요: ");
                string temperature = Console.ReadLine();
                if (temperature == "") break;
                logger.WriteLog("현재 온도: " + temperature);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ClimateMonitor monitor = new ClimateMonitor(new FileLogger("MyLog.txt"));   //FileLogger
            //C:\_HAR\C3\JSC_Arim\08.01.Interface\bin\Debug\net5.0 위치에 저장
            //ClimateMonitor monitor = new ClimateMonitor(new ConsoleLogger());         //ConsoleLogger
            monitor.start();
        }
    }
}
