using System;
using L_2_1.Enums;

namespace L_2_1.Entities
{
    public class Student 
        :Human
    {
        public Knowledge GapsInKnowledge { get; }

        public Student(string fullName, Knowledge gapsInKnowledge) : base(fullName)
        {
            GapsInKnowledge = gapsInKnowledge;
        }

        public virtual void Learn(Knowledge lectureType)
        {
            if (GapsInKnowledge == Knowledge.Full || GapsInKnowledge.HasFlag(lectureType))
                Console.WriteLine($"{this.ToString()} is learning on {lectureType} lecture");
            else Sleep();
        }

        public override string ToString()
        {
            return $"Student: {FullName}";
        }
    }
}