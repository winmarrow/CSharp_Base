namespace L_2_2.Abstractions
{
    public abstract class Human
    {
        protected Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public abstract void Work();

        public override bool Equals(object obj)
        {
            return obj is Human human
                   && human.FirstName == FirstName
                   && human.LastName == LastName;
        }

        public override string ToString()
        {
            return $"{GetType().Name} {FirstName} {LastName}";
        }
    }
}