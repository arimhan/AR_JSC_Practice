using System;

namespace _07.BasicClass
{
    internal class Cat
    {
        public string Name;
        public string Color;
        public void Meow()
        {
            Console.WriteLine($"{Name} : 야옹");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Cat Kitty = new Cat();
            Kitty.Color = "하얀색";
            Kitty.Name = "키티";
            Kitty.Meow();
            Console.WriteLine($"{Kitty.Name} : {Kitty.Color}");

            Cat Nero = new Cat();
            Nero.Color = "검은색";
            Nero.Name = "네로";
            Nero.Meow();
            Console.WriteLine($"{Nero.Name} : {Nero.Color}");
        }
    }
}
