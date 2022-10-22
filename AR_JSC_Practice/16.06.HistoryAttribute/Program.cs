using System;
using static System.Console;
namespace _16._06.HistoryAttribute
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    class History : System.Attribute
    {
        private string programmer;
        public double version;
        public string changes;

        public History(string programmer)
        {
            this.programmer = programmer;
            version = 1.0;
            changes = "First release.";
        }
        public string GetProgrammer()
        {
            return programmer;
        }
    }
    [History("Sean", version = 0.1, changes = "2017-11-01, Created class stub")]
    [History("Bob", version = 0.2, changes = "2020-12-03, Added Func() Method")]
    class MyClass
    {
        public void Func()
        {
            WriteLine("Func()");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(MyClass);
            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            WriteLine("MyClass change history...");
            foreach(Attribute a in attributes)
            {
                History h = a as History;
                if(h!= null)
                    WriteLine($"Ver: {h.version},   Programmer: {h.GetProgrammer()},   Changes: {h.changes}");
            }
        }
    }
}
