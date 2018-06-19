using System;
using L_2_2.Abstractions;

namespace L_2_2.Entities
{
    public class Lecturer
        : HomoSapiensFromUnivercity
    {
        public string CourseName { get; protected set; }

        public Lecturer(string firstName, string lastName, string department, string courseName)
            : base(firstName, lastName, department)
        {
            CourseName = courseName;
        }

        public void ChangeCourse(string courseName)
        {
            CourseName = courseName;
        }

        public override bool Equals(object obj)
        {
            return obj is Lecturer lecturer
                   && lecturer.CourseName == this.CourseName
                   && base.Equals(obj);
        }

        public override void Work()
        {
            Console.WriteLine($"{this.ToString()}, is teaching course \"{CourseName}\"");
        }
    }
}