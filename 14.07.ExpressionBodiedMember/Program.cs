using System;
using System.Collections.Generic;
using static System.Console;
//식으로 이루어지는 멤버 506p
namespace _14._07.ExpressionBodiedMember
{
    class FriendList
    {
        private List<string> list = new List<string>();
        public void Add(string name) => list.Add(name);
        public void Remove(string name) => list.Remove(name);
        public void PrintAll()
        {
            foreach(var s in list)
                WriteLine(s);
        }
        public FriendList() => WriteLine("FriendList()");
        ~FriendList() => WriteLine("~FriendList()");


        //public int Capacity => list.Capacity; 읽기 전용
        public int Capacity //속성
        {
            get => list.Capacity; 
            set => list.Capacity = value; 
        }

        //public string this[int index] => list[index]; 읽기 전용
        public string this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            FriendList obj = new FriendList();
            obj.Add("Eeny");
            obj.Add("Meeny");
            obj.Add("Miny");
            obj.Remove("Eeny");
            obj.PrintAll();

            WriteLine($"{obj.Capacity}");
            obj.Capacity = 10;
            WriteLine($"{obj.Capacity}");

            WriteLine($"{obj[0]}");
            obj[0] = "Moe";
            obj.PrintAll();
        }
    }
}
