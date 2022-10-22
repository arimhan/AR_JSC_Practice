using System;
using System.IO;
using static System.Console;

namespace _18._03.BasicIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long someValue = 0x123456789ABCDEF0;
            WriteLine($"{"Origina Data",-1}  : 0x{someValue:X16}");
            Stream outStream = new FileStream("a.dat", FileMode.Create);
            byte[] wBytes = BitConverter.GetBytes(someValue);   //a.dat을 바이너리 파일로 읽어보면,
            Write($"{"Bytes array",-13} : ");                   //리틀엔디안으로 설정되어있어 낮은 주소부터 저장해서 그런것.
            foreach(byte b in wBytes)
                Write($"{b:X2} ");
            WriteLine();
            outStream.Write(wBytes, 0, wBytes.Length);
            outStream.Close();

            Stream inStream = new FileStream("a.dat", FileMode.Open);
            byte[] rbytes = new byte[8];
            int i = 0;
            while (inStream.Position < inStream.Length)
                rbytes[i++] = (byte)inStream.ReadByte();

            long readValue = BitConverter.ToInt64(rbytes, 0);
            WriteLine($"{"Read Data",-13} : 0x{readValue:X16} ");
            inStream.Close();
        }
    }
}
