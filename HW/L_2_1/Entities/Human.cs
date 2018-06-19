using System;

namespace L_2_1.Entities
{
    public class Human
    {
        public string FullName { get; }
        
        public Human(string fullName)
        {
            FullName = fullName;
        }

        public void Eat()
        {
            Console.WriteLine("Nam-Nam");
        }
        public void Sleep()
        {
            Console.WriteLine($"{this.ToString()} is sleeping - \"Z-z-Z\"");
        }

        public override string ToString()
        {
            return $"Human: {FullName}";
        }
    }
}