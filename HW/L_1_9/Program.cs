using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L_1_9.Attachment;
using L_1_9.Attachment.Enities;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_1_9
{
    class Program
    {
        static void Main(string[] args)
        {
            CH.SetConsoleOutputEncoding();
            CH.SetConsoleColor();

            switch (CH.GetChoiceFromUser(new[] { "Attachment", "Presentation" }, true, true).ChoisedIndex)
            {
                case 0:
                    new Predictor().Predict();
                    break;
                case 1:
                    Console.WriteLine("Ha-ha there is nothing. See source files in folder \"Presentation\"");
                    break;
            }

            Console.ReadKey();
        }
    }
}
