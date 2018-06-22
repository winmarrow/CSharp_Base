using System;
using System.Collections.Generic;
using CH = SharedLib.Helpers.ConsoleHelper;

namespace L_2_1.Entities
{
    public class Univercity
    {
        private const string LectionTemplateString = "{0} lection \"{1}\" is held in classroom #{2} ";

        public Univercity()
        {
            Humans = new List<Human>();
            Lections = new Dictionary<Lection, List<Human>>();
        }

        public List<Human> Humans { get; }
        public Dictionary<Lection, List<Human>> Lections { get; }

        public void CheckLections()
        {
            foreach (var lectionPair in Lections)
            {
                var lection = lectionPair.Key;

                CH.WriteSeparator();

                Console.WriteLine(LectionTemplateString, lection.Type, lection.Theme, lection.Classroom);
                CH.WriteSeparator();

                var humansOnLection = lectionPair.Value;

                foreach (var human in humansOnLection)
                    switch (human)
                    {
                        case Student student:
                            student.Learn(lection.Type);
                            break;
                        case Lecturrer lecturrer:
                            lecturrer.Work(lection.Type);
                            break;
                        default:
                            Console.Write($"{human} is eating. ");
                            human.Eat();
                            break;
                    }
            }
        }
    }
}