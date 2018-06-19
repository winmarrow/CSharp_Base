﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace L_1_9.Presentstion
{
    public class Student
    {
        private readonly List<Mark> _marks;

        //Fields as in presentation task O_o // TODO А я всё равно напишу что хоту тут видеть Get-Only properties
        public readonly string FirstName;
        public readonly string LastName;
        public readonly DateTime DoB;

        public Student(string firstName, string lastName, DateTime doB)
        {
            FirstName = firstName;
            LastName = lastName;
            DoB = doB;

            _marks = new List<Mark>();
        }
        

        public void AddMark(Mark mark)
        {
            // TODO Contains работает?
            if (Mark.IsMarkValid(mark) && !_marks.Contains(mark))
                _marks.Add(mark);
        }
        
        public override bool Equals(object obj)
        {
            return obj is Student student
                   && student.FirstName == this.FirstName
                   && student.LastName == this.LastName
                   && student.DoB == this.DoB;
        }

        public override string ToString()
        {
            _marks.Sort();
            // TODO когда работает SORT работают и Min и Max =)
            int minMark = _marks?.Count > 0 ? _marks[0].MarkNumber : 0;
            int maxMark = _marks?.Count > 0 ? _marks[_marks.Count-1].MarkNumber:0;
            double avgMark = CalculateAvgMark();

            return $"Student - {FirstName} {LastName}, marks:{minMark}/{maxMark}/{avgMark}";
        }

        private double CalculateAvgMark()
        {
            if (_marks.Count == 0) return 0d;
            if (_marks.Count == 1) return _marks[0].MarkNumber;

            double sum = 0d;
            foreach (Mark singleMark in _marks)
                sum += singleMark.MarkNumber;
            
            // TODO Just in case - Вы говорите что суммировать или из чего взять среднее
            var linqSum = _marks.Sum(mark => mark.MarkNumber);
            var linqAvg = _marks.Average(mark => mark.MarkNumber);

            return sum / _marks.Count;
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