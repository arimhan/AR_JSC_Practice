using System;
//using System.Linq; //FirstOrDefault사용
using static System.Console;
using System.Collections.Generic;
namespace _11._07.UsingDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["하나"]   = "one";        //key, value 형식으로 저장되며
            dic["둘"]    = "two";
            dic["셋"]    = "three";
            dic["넷"]    = "four";
            dic["다섯"]   = "five";

            WriteLine(dic["하나"]);       //key를 부르면 해당 key값과 연결된 value가 출력된다
            WriteLine(dic["둘"]);
            WriteLine(dic["셋"]);
            WriteLine(dic["넷"]);
            WriteLine(dic["다섯"]);

            //만일 Value로 Key를 찾고 싶을 경우, Using System.Linq를 활용, 찾을 key값에 해당하는 value를 입력하여 찾은 key를 _key에 반환한다.
            //var _key = dic.FirstOrDefault(x => x.Value == "one").Key;
            //WriteLine(_key);
        }
    }
}
