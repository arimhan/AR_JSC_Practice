using System;
using System.Runtime.CompilerServices;
using static System.Console;
//Caller Infod : C++의 매크로 같은 개념.
//https://velog.io/@excellent/CSstack-overflow-out-of-memory
namespace _16._05.CallerInfo
{
    public static class Trace
    {
        public static void WriteLine(                   string message,
                                    [CallerFilePath]    string file = "",       //현재 메소드가 호출된 소스 파일 경로 출력 (컴파일 시 전체 경로)
                                    [CallerLineNumber]  int line = 0,         //현재 메소드가 호출된 소스 파일 내의 행(Line)
                                    [CallerMemberName]  string member = "")   //현재 메소드를 호출한 메소드 또는 프로퍼티의 이름
        {
            Console.WriteLine($"{file} (Line : {line}) {member} : {message}");
            //Console.을 안 붙이면 콘솔메서드인지 새로만든 메서드인지 헷갈림.
            //즉, 재귀호출 해버려서 StackOverflow 혹은 OOM(OutOfMemoryException) 발생함. 조심하기.
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Trace.WriteLine("즐거운 프로그래밍!!!");
        }
    }
}
