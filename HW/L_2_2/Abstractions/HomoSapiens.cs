
using System;

namespace L_2_2.Abstractions
{
    public abstract class HomoSapiens
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected HomoSapiens(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual void Work()
        {
            Console.WriteLine($"{this.ToString()}, doing something");
        }

        public override bool Equals(object obj)
        {
            return obj is HomoSapiens homoSapiens
                   && homoSapiens.FirstName == this.FirstName
                   && homoSapiens.LastName == this.LastName;

        }

        public override string ToString()
        {
            return $"{GetType().Name} {FirstName} {LastName}";
        }
    }
}
