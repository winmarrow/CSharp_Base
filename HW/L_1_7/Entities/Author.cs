using System;

namespace L_1_7.Entities
{
    public class Author
    {
        public string FirstName;
        public string LastName;
        public DateTime DoB;

        public Author(string firstName, string lastName, DateTime doB)
        {
            FirstName = firstName;
            LastName = lastName;
            DoB = doB;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }


        public override bool Equals(object obj)
        {

            return obj is Author author
                   && author.GetFullName() == this.GetFullName()
                   && author.DoB == this.DoB;
        }

        //Static
        public static bool IsAuthorValid(Author author)
        {
            return author != null
                   && !string.IsNullOrWhiteSpace(author.FirstName)
                   && !string.IsNullOrWhiteSpace(author.LastName)
                   && author.DoB != new DateTime();
        }
    }
}