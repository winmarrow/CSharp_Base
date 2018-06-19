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
            // TODO вызов ToString можно опустить. Интерполяция сама его вызовет.
            Console.WriteLine($"{this.ToString()} is sleeping - \"Z-z-Z\"");
        }

        public override string ToString()
        {
            // TODO В вашем случае можно было сделать этот метод более гибким. Вы же печатаете лишь тип
            return $"{this.GetType().Name}: {FullName}";
            //return $"Human: {FullName}";
        }
    }
}