using System;
using System.IO;
using static System.Console;
namespace _18._07.TextFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter(new FileStream("a.txt", FileMode.Create)))
            {
                sw.WriteLine(int.MaxValue);
                sw.WriteLine("Good morning");
                sw.WriteLine(uint.MaxValue);
                sw.WriteLine("안녕하세요!");
                sw.WriteLine(double.MaxValue);
            }
            using (StreamReader sr = new StreamReader(new FileStream("a.txt", FileMode.Open)))
            {
                WriteLine($"File size : {sr.BaseStream.Length} bytes");
                while( sr.EndOfStream == false)
                    WriteLine(sr.ReadLine());
            }
        }
    }
}
