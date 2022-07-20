using System;
using System.Threading;
using static System.Console;
namespace _19._02.Synchronize
{
    class Counter
    {
        const int LOOP_COUNT = 10; // 1000
        readonly object thisLock;
        //readonly object thisLock2;
        private int count;
        //private int testcount;
        public int Count
        {
            get { return count; }
        }
        public Counter()
        {
            thisLock = new object();
            count = 0;
        }
        //public int Test
        //{
        //    get { return testcount; }
        //}
        //public Tester()
        //{
        //    thisLock2 = new object();
        //    testcount = 0;
        //}
        public void Increase()
        {
            int loopCount = LOOP_COUNT;
            while(loopCount-->0)
            {
                lock(thisLock)
                {
                    count++;
                    //testcount++;
                }
                Thread.Sleep(1);
            }
        }
        public void Decrease()
        {
            int loopCount = LOOP_COUNT;
            while (loopCount-- > 0)
            {
                lock (thisLock)
                {
                    count--;
                    //testcount--;
                }
                Thread.Sleep(1);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter();
            //Tester tester = new Tester();
            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));
            incThread.Start();
            decThread.Start();
            incThread.Join();
            decThread.Join();

            WriteLine(counter.Count);
            //WriteLine(counter.Test);
        }
    }
}
