using SharedLib.Random;

namespace L_2_6.Entities
{
    public class Student
    {
        public Student()
        {
            FirstName = Rnd.RandomFirstName;
            LastName = Rnd.RandomLastName;
        }

        public Student(string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}