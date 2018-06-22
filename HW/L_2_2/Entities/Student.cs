using System;

namespace L_2_2.Entities
{
    public class Student : HumanFromUnivercity
    {
        public Student(string firstName, string lastName, string department, sbyte course, string groupName)
            : base(firstName, lastName, department)
        {
            Course = course;
            GroupName = groupName;
        }

        public sbyte Course { get; protected set; }
        public string GroupName { get; protected set; }

        public override bool Equals(object obj)
        {
            return obj is Student student
                   && student.Course == Course
                   && student.GroupName == GroupName
                   && base.Equals(obj);
        }

        public override void Work()
        {
            Console.WriteLine($"{this}, course {Course} and group {GroupName} is learning");
        }
    }
}