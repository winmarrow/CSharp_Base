using System;
using L_2_3.Entities;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            CH.SetConsoleOutputEncoding();
            CH.SetConsoleColor();

            Random rand = new Random((int)DateTime.Now.Ticks); ;
            Field field = new Field(rand.Next(10, 20), rand.Next(10, 20));

            while (true)
            {
                switch (CH.GetChoiceFromUser(new[] { "Generate new animals", "To next step" }, true, true).ChoisedIndex)
                {
                    case 0:
                        field.GenerateNewAnimals(rand.Next(5, 20), rand.Next(2, 5));
                        break;
                    case 1:
                            field.NextStep();
                        break;

                    case -1:
                        return;
                }
            }

            Console.ReadKey();
        }
    }
}
