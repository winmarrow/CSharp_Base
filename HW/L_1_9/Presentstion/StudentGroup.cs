using System.Collections.Generic;
using L_1_9.Presentstion;

namespace HW_Lecture_1_9.Presentation
{
    public class StudentGroup
    {
        //Collection
        private readonly List<Student> _students = new List<Student>();

        //Add
        public void Add(Student student)
        {
            if(Student.IsStudentValid(student))
                _students.Add(student);
        }

        //Remove
        public void Remove(Student student)
        {
            if (Student.IsStudentValid(student) && _students.Contains(student))
                _students.Add(student);
        }
        public void RemoveAt(int index)
        {
            if(index> 0 && index < _students.Count)
                _students.RemoveAt(index);
        }

        //Indexation
        public Student this[int index]
        {
            get
            {
                if (index > 0 && index < _students.Count)
                    return _students[index];

                return null;
            }
        }
    }
}