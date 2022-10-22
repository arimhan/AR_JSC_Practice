using System;
using System.IO;
using static System.Console;
namespace _18._02.Touch
{
    internal class Program
    {
        static void OnWrongPathTypes(string type)
        {
            WriteLine($"{type} is wrong type");
            return;
        }
        static void Main(string[] args)
        {
            string[] cd = { "C:\\_HAR\\C3\\Testfile.zip" };
            if (cd.Length == 0)
            {
                WriteLine("Usage : Touch.exe <Path> [Type:File/Directory]");
                return;
            }
            string path = cd[0];
            string type = "File";
            if (cd.Length > 1)
                type = cd[1];

            if (File.Exists(path) || Directory.Exists(path))
            {
                if (type == "File")
                    File.SetLastWriteTime(path, DateTime.Now);  //여기서 계속 경로 액세스가 거부되는데 다른데서도 실행해보자..
                                                                //만일 파일이 존재할 경우, 해당 파일의 수정시간을 업데이트한다.
                else if (type == "Directory")
                    Directory.SetLastWriteTime(path, DateTime.Now);
                else
                {
                    OnWrongPathTypes(path);
                    return;
                }
                WriteLine($"Update {path} {type}");
            }
            else
            {
                if (type == "File")                 //현재 파일은 존재하지 않는데 type이 File이면, 생성하자~
                    File.Create(path).Close();
                else if (type == "Directory")       
                    Directory.CreateDirectory(path);
                else
                {
                    OnWrongPathTypes(path);         
                    return;
                }
                WriteLine($"Created {path} {type}");
            }
            ReadKey();  //자동 꺼짐 방지
        }
    }
}
