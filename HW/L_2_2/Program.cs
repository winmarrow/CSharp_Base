using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L_2_2.Entities;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            CH.SetConsoleOutputEncoding();
            CH.SetConsoleColor();

            var students = new List<Student>()
            {
                new Student("Abdul", "Student 1", "Departament 1", (sbyte)1, "G1"),
                new Student("Vdul", "Student 2", "Departament -2", (sbyte)1, "G2"),
                new Student("Opozdal", "Student 3", "Departament 3", (sbyte)1, "G3"),
                new Student("Umni", "Student 4", "Departament 666", (sbyte)1, "G666"),
                new Student("Knyzz", "From last table", "Departament 666", (sbyte)1, "G666"),//4
            };

            var lecturers = new List<Lecturer>()
            {
                new Lecturer("Uchit"," Chemuto", "Gdeto","O chomto"),
                new Lecturer("NE Uchit"," Chemuto", "TamTO","Ni o chom"),
            };

            var heads = new List<HeadLecturrer>()
            {
                new HeadLecturrer("Zloy", "Dulahan", "Hell", 666)
            };

            var univarcity = new University();

            foreach (var student in students)
                univarcity.Students.Add(student);

            foreach (var lecturer in lecturers)
                univarcity.Lecturers.Add(lecturer);

            foreach (var head in heads)
                univarcity.HedLecturrers.Add(head);

            CH.WriteSeparator();

            univarcity.Students.Add(students[4]); //there must be error in log

            CH.WriteSeparator();
            CH.WriteSeparator();

            univarcity.UniversityWork();

            Console.ReadKey();
        }
    }
}
