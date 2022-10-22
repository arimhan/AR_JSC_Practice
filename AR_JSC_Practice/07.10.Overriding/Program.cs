using System;

namespace _07._10.Overriding
{
    class ArmorSuite
    {
        public virtual void Initialize()
        {
            Console.WriteLine("Armored");
        }
    }
    class IronMan : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            Console.WriteLine("Replusor Rays Armed");
        }
    }
    class WarMachine : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            Console.WriteLine("Double-Barrel Cannos Armed");
            Console.WriteLine("Micro-Rocket Launcher Armed");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating ArmorSuite...");
            ArmorSuite armorSuite = new ArmorSuite();
            armorSuite.Initialize();

            Console.WriteLine("\nCreating IronMan...");
            ArmorSuite ironman = new IronMan();
            ironman.Initialize();

            Console.WriteLine("\nCreating WarMachine...");
            ArmorSuite warmachine = new WarMachine();
            warmachine.Initialize();
        }
    }
}
