﻿using System;

namespace L_2_2.Entities
{
    public class Lecturer : HumanFromUnivercity
    {
        public Lecturer(string firstName, string lastName, string department, string courseName)
            : base(firstName, lastName, department)
        {
            CourseName = courseName;
        }

        public string CourseName { get; protected set; }

        public void ChangeCourse(string courseName)
        {
            CourseName = courseName;
        }

        public override bool Equals(object obj)
        {
            return obj is Lecturer lecturer
                   && lecturer.CourseName == CourseName
                   && base.Equals(obj);
        }

        public override void Work()
        {
            Console.WriteLine($"{this}, is teaching course \"{CourseName}\"");
        }
    }
}