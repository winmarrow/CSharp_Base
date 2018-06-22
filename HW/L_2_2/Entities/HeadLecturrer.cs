using System;

namespace L_2_2.Entities
{
    public class HeadLecturrer : HumanFromUnivercity
    {
        public HeadLecturrer(string firstName, string lastName, string department, int authorityLevel)
            : base(firstName, lastName, department)
        {
            AuthorityLevel = authorityLevel;
        }

        public int AuthorityLevel { get; protected set; }

        public override bool Equals(object obj)
        {
            return obj is HeadLecturrer headLecturrer
                   && headLecturrer.AuthorityLevel == AuthorityLevel
                   && base.Equals(obj);
        }

        public override void Work()
        {
            Console.WriteLine($"{this}, is controlling his department with authority level \"{AuthorityLevel}\"");
        }
    }
}