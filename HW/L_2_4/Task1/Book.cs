using System;

namespace L_2_4.Task1
{
    public class Book
    {
        public string Title { get; set; }
        public DateTime DoP { get; set; }

        public override string ToString()
        {
            return $"Book - \"{Title}\" - Published in {DoP.Year}.";
        }
    }
}
