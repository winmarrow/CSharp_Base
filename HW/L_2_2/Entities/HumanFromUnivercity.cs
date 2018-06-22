using System;
using L_2_2.Abstractions;

namespace L_2_2.Entities
{
    public class HumanFromUnivercity : Human
    {
        public HumanFromUnivercity(string firstName, string lastName, string department)
            : base(firstName, lastName)
        {
            Department = department;
        }

        public string Department { get; set; }

        public override void Work()
        {
            Console.WriteLine($"{this}, doing something in univercity");
        }

        public override bool Equals(object obj)
        {
            return obj is HumanFromUnivercity humanFromUnivercity
                   && humanFromUnivercity.Department == Department
                   && base.Equals(obj);
        }
    }
}