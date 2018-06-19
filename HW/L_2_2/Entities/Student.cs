using System;
using L_2_2.Abstractions;

namespace L_2_2.Entities
{
    public class Student
        : HomoSapiensFromUnivercity
    {
        public sbyte Cource { get; protected set; }
        public string GroupName { get; protected set; }

        public Student(string firstName, string lastName, string department, sbyte cource, string groupName)
            : base(firstName, lastName, department)
        {
            Cource = cource;
            GroupName = groupName;
        }

        public override bool Equals(object obj)
        {
            return obj is Student student
                   && student.Cource == this.Cource
                   && student.GroupName == this.GroupName
                   && base.Equals(obj);
        }

        public override void Work()
        {
            Console.WriteLine($"{this.ToString()}, cource { Cource} and group { GroupName} is learning");
        }
    }
}