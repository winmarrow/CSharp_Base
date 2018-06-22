using System;

namespace L_2_6.Entities
{
    public class InvalidStudentInputEventArgs : EventArgs
    {
        public InvalidStudentInputEventArgs(Exception exception, Student item)
        {
            Exception = exception;
            InvalidStudent = item;
        }

        public Exception Exception { get; }
        public Student InvalidStudent { get; }
    }
}