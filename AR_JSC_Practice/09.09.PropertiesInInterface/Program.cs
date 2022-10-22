using System;

namespace _09._09.PropertiesInInterface
{
    interface INamedValue
    {
        string Name { get; set; }
        string Value { get; set; }
    }
    class NamedValue : INamedValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            NamedValue name = new NamedValue()
            { Name = "이름", Value = "박상현"};
            NamedValue height = new NamedValue()
            { Name = "키", Value = "177Cm" };
            NamedValue Weight = new NamedValue()
            { Name = "몸무게", Value = "90Kg" };

            Console.WriteLine($"{name.Name} : {name.Value}");
            Console.WriteLine($"{height.Name} : {height.Value}");
            Console.WriteLine($"{Weight.Name} : {Weight.Value}");
        }
    }
}
