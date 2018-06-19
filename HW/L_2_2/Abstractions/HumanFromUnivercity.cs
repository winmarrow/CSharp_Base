using System;

namespace L_2_2.Abstractions
{
    public abstract class HomoSapiensFromUnivercity: HomoSapiens
    // TODO опять же тут нету абстрактности.
    {
        public string Department { get; set; }

        protected HomoSapiensFromUnivercity(string firstName, string lastName, string department) 
            : base(firstName, lastName)
        {
            Department = department;
        }

        public override void Work()
        {
            Console.WriteLine($"{this.ToString()}, doing something in univercity");
        }

        public override bool Equals(object obj)
        {
            return obj is HomoSapiensFromUnivercity humanFromUnivercity
                   && humanFromUnivercity.Department == this.Department
                   && base.Equals(obj);
        }
    }
}