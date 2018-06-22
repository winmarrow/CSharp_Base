using System;
using System.Collections.Generic;
using L_2_6.Entities;
using L_2_6.Exceptions;
using SharedLib.ConsoleHelpers;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_2_6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CH.SetConsoleColor();
            CH.SetConsoleOutputEncoding();

            var newStudents = new List<Student> // TODO надо закоментить ненужные 
            {
                new Student(),
                new Student {LastName = null},
                new Student {FirstName = null},
                null
            };

            var group = new StudentGroup(new List<Student>(), new ConsoleLogger());
            var newGroup = new StudentGroup(new List<Student>(newStudents), new ConsoleLogger());


            try
            {
                foreach (var student in newStudents)
                    group.AddStudent(student);
            }
            catch (InvalidStudentInput e)
            {
                Console.WriteLine(e.Message);
                if (e.InnerException != null)
                    Console.WriteLine(e.InnerException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            try
            {
                group.AddStudentsFromGroup(newGroup);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}