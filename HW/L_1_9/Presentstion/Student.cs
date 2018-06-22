using System;
using System.Collections.Generic;
using System.Linq;

namespace L_1_9.Presentstion
{
    public class Student
    {
        private readonly List<Mark> _marks;

        public Student(string firstName, string lastName, DateTime doB)
        {
            FirstName = firstName;
            LastName = lastName;
            DoB = doB;

            _marks = new List<Mark>();
        }

        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DoB { get; }


        public void AddMark(Mark mark)
        {
            if (Mark.IsMarkValid(mark) && !_marks.Contains(mark))
                _marks.Add(mark);
        }

        public override bool Equals(object obj)
        {
            return obj is Student student
                   && student.FirstName == FirstName
                   && student.LastName == LastName
                   && student.DoB == DoB;
        }

        public override string ToString()
        {
            var minMark = _marks.Min(mark => mark.MarkNumber);
            var maxMark = _marks.Max(mark => mark.MarkNumber);
            var avgMark = _marks.Average(mark => mark.MarkNumber);

            return $"Student - {FirstName} {LastName}, marks:{minMark}/{maxMark}/{avgMark}";
        }

        public static bool IsStudentValid(Student student)
        {
            return student != null
                   && !string.IsNullOrWhiteSpace(student.FirstName)
                   && !string.IsNullOrWhiteSpace(student.LastName)
                   && student.DoB != default(DateTime);
        }
    }
}