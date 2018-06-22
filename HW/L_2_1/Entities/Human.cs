using System;

namespace L_2_1.Entities
{
    public class Human
    {
        public Human(string fullName)
        {
            FullName = fullName;
        }

        public string FullName { get; }

        public void Eat()
        {
            Console.WriteLine("Nam-Nam");
        }

        public void Sleep()
        {
            Console.WriteLine($"{this} is sleeping - \"Z-z-Z\"");
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FullName}";
        }
    }
}