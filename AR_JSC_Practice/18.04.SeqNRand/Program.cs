using System;
using System.IO;
using static System.Console;

namespace _18._04.SeqNRand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stream outStream = new FileStream("a.dat", FileMode.Create);
            WriteLine($"Position : {outStream.Position}");

            outStream.WriteByte(0x01);
            WriteLine($"Position : {outStream.Position}");
            outStream.WriteByte(0x02);
            WriteLine($"Position : {outStream.Position}");
            outStream.WriteByte(0x03);
            WriteLine($"Position : {outStream.Position}");
            outStream.Seek(5, SeekOrigin.Current);
            WriteLine($"Position : {outStream.Position}");
            outStream.WriteByte(0x04);
            WriteLine($"Position : {outStream.Position}");

            outStream.Close();
        }
    }
}
