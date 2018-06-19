using SharedLib.Random;

namespace L_2_4.Task2
{
    public class Student
    {
        public Student()
        {
            FirstName = Rnd.RandomFirstName;
            LastName = Rnd.RandomLastName;
            AvgMark = Rnd.RandomMark;
        }

        public Student(int avgMark, string lastName, string firstName)
        {
            AvgMark = avgMark;
            LastName = lastName;
            FirstName = firstName;
        }

        public double AvgMark { get; private set; }

        public string LastName { get; }

        public string FirstName { get; }


        public void AddToMark(double value)
        {
            AvgMark += value;
        }
    }
}
