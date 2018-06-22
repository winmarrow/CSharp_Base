using System;
using L_1_9.Attachment.Enums;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_1_9.Attachment.Enities
{
    public class Predictor
    {
        public void Predict()
        {
            CH.WriteSeparator();
            Console.WriteLine("Please choice prediction interval: ");
            var choiceResult = CH.GetChoiceFromUser<Period>(true);
            CH.ClearLine(2);
            Console.WriteLine(Predict(choiceResult));
        }

        private string Predict(Period period)
        {
            var rand = new Random((int) DateTime.Now.Ticks);

            var modificatorString =
                Enum.GetName(typeof(Modificator), rand.Next(Enum.GetNames(typeof(Modificator)).Length - 1)) ??
                string.Empty;
            var periodString = Enum.GetName(typeof(Period), period);


            return
                $"You will have \"{modificatorString} {(rand.Next(100) <= 50 ? "failure" : "luck")}\" on {periodString}";
            ;
        }
    }
}