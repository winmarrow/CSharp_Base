using System;
using L_2_1.Enums;

namespace L_2_1.Entities
{
    public class Student : Human
    {
        public Student(string fullName, Knowledge gapsInKnowledge) : base(fullName)
        {
            GapsInKnowledge = gapsInKnowledge;
        }

        public Knowledge GapsInKnowledge { get; }

        public virtual void Learn(Knowledge lectureType)
        {
            if (GapsInKnowledge == Knowledge.Full || GapsInKnowledge.HasFlag(lectureType))
                Console.WriteLine($"{this} is learning on {lectureType} lecture");
            else Sleep();
        }
    }
}