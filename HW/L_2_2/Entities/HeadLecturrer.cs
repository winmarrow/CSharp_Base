using System;
using L_2_2.Abstractions;

namespace L_2_2.Entities
{
    public class HeadLecturrer
        : HomoSapiensFromUnivercity
    {
        public int AuthorityLevel { get; protected set; }

        public HeadLecturrer(string firstName, string lastName, string department, int authorityLevel)
            : base(firstName, lastName, department)
        {
            AuthorityLevel = authorityLevel;
        }

        public override bool Equals(object obj)
        {
            return obj is HeadLecturrer headOfTheDepartment
                   && headOfTheDepartment.AuthorityLevel == this.AuthorityLevel
                   && base.Equals(obj);
        }

        public override void Work()
        {
            Console.WriteLine($"{this}, is controlling his department with authority level \"{AuthorityLevel}\"");
        }
    }
}