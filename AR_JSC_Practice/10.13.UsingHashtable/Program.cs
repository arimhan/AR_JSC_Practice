using System;
using System.Collections;
using static System.Console; //Console 생략 가능.
namespace _10._13.UsingHashtable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht["하나"] = "one";
            ht["둘"]  = "two";
            ht["셋"]  = "three";
            ht["넷"]  = "four";
            ht["다섯"] = "five";
            WriteLine(ht["하나"] );
            WriteLine(ht["둘"]);
            WriteLine(ht["셋"]);
            WriteLine(ht["넷"]);
            WriteLine(ht["다섯"]);
        }
    }
}
