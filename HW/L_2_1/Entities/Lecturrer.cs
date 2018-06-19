using System;
using L_2_1.Enums;

namespace L_2_1.Entities
{
    public class Lecturrer
        :Human
    {
        public Knowledge Knowledge { get; }

        public Lecturrer(string fullName, Knowledge knowledge) : base(fullName)
        {
            Knowledge = knowledge;
        }

        public virtual void Work(Knowledge lectureType)
        {
            if(Knowledge.HasFlag(lectureType))
                Console.WriteLine($"{this.ToString()} is teaching on {1} lecture", lectureType);
            else
                Console.WriteLine($"{this.ToString()} is speaking \"Be-Meee-Kukareku\"");
            
        }

        //public override string ToString()
        //{
        //    return $"Lecturrer: {FullName}";
        //}
    }
}