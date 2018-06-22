using System;
using L_2_6.Entities;

namespace L_2_6.Exceptions
{
    [Serializable]
    public class InvalidStudentInput : Exception
    {
        public InvalidStudentInput(Student invalidStudent = null)
        {
            InvalidStudent = invalidStudent;
        }

        public InvalidStudentInput(string message, Student invalidStudent = null) : base(message)
        {
            InvalidStudent = invalidStudent;
        }

        public InvalidStudentInput(string message, Exception innerException, Student invalidStudent = null) : base(
            message,
            innerException)
        {
            InvalidStudent = invalidStudent;
        }

        public Student InvalidStudent { get; }
    }
}