using System;
using System.Linq;
using System.IO;
using static System.Console;
namespace _18._01.Dir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directory;
            if (args.Length < 1)
                directory = ".";        //디렉터리를 .으로 구분
            else
                directory = args[0];

            WriteLine($"{directory} directory Info");
            WriteLine($"- Directories : ");
            var directories = (from dir in Directory.GetDirectories(directory)  //디렉터리 목록 조회
                               let info = new DirectoryInfo(dir)
                               select new
                               {
                                   Name = info.Name,
                                   Attributes = info.Attributes}).ToList();
            foreach (var d in directories)
                WriteLine($"{d.Name} : {d.Attributes}");
            WriteLine("- Files : ");
            var files = (from file in Directory.GetFiles(directory)             //하위 파일 목록 조회
                         let info = new FileInfo(file)                          //let -> LINQ안에서 변수를 만든다 LINQ의 var라고 이해하기.
                         select new
                         {
                             Name = info.Name,
                             FileSize = info.Length,
                             Attributes = info.Attributes}).ToList();
            foreach (var f in files)
                WriteLine($"{f.Name} : {f.FileSize}, {f.Attributes}");
            ReadKey();  //자동 꺼짐 방지
        }
    }
}
