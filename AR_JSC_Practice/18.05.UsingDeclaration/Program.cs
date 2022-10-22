using System;
using System.IO;
using FS = System.IO.FileStream;
using static System.Console;

namespace _18._05.UsingDeclaration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long someValue = 0x123456789ABCDEF0;
            WriteLine($"{"Origina Data",-1}   : 0x{someValue:X16}");

            using (Stream outStream = new FS("a.dat", FileMode.Create))
            {
                byte[] wBytes = BitConverter.GetBytes(someValue);
                Write($"{"Byte array",-13}  : ");
                foreach(byte b in wBytes)
                    Write($"{b:X2} ");
                WriteLine();
                outStream.Write(wBytes, 0, wBytes.Length);
            }
            using Stream inStream = new FS("a.dat", FileMode.Open);
            byte[] rBytes = new byte[8];

            int i = 0;
            while(inStream.Position < inStream.Length)
                rBytes[i++] = (byte)inStream.ReadByte();
            long readValue = BitConverter.ToInt64(rBytes, 0);
            WriteLine($"{"Read Data",-13}  : 0x{readValue:X16}");
        }
    }
}
