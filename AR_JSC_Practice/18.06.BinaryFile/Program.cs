using System;
using System.IO;
using static System.Console;

namespace _18._06.BinaryFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create)))
            {
                bw.Write(int.MaxValue);
                bw.Write("Good morning!");
                bw.Write(uint.MaxValue);
                bw.Write("안녕하세요!");
                bw.Write(double.MaxValue);
            }
            using BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open));
            WriteLine($"File size : {br.BaseStream.Length} bytes");
            WriteLine($"{br.ReadInt32()}");
            WriteLine($"{br.ReadString()}");
            WriteLine($"{br.ReadUInt32()}");
            WriteLine($"{br.ReadString()}");
            WriteLine($"{br.ReadDouble()}");
        }
    }
}
