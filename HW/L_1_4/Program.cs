using System;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_1_4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CH.SetConsoleOutputEncoding();
            CH.SetConsoleColor();

            const string inputMsg = "Введитк натуральное число (n>0) : ";
            const string noPrimeMsg = "Нет простых чисел в выбранном диапазоне";
            const string invalidInputMsg = "Введены неверные значения...";
            const string outMsg = "{0,10}";

            var inputString = CH.GetStringFromConsole(inputMsg);

            if (!uint.TryParse(inputString, out var n))
            {
                Console.WriteLine(invalidInputMsg);
                Console.ReadKey();
                return;
            }

            CH.WriteSeparator();

            if (n == 1)
            {
                Console.WriteLine(noPrimeMsg);
            }
            else if (n >= 2)
            {
                Console.Write(outMsg, 2);


                for (uint number = 2; number <= n; number++)
                {
                    var isPrime = false;

                    for (uint oldNumber = 2; oldNumber <= Math.Ceiling(Math.Sqrt(number)); ++oldNumber)
                        if (number % oldNumber != 0)
                        {
                            isPrime = true;
                            break;
                        }

                    if (isPrime) Console.Write(outMsg, number);
                }
            }

            Console.WriteLine();
            CH.WriteSeparator();

            //exit
            Console.ReadKey();
        }
    }
}