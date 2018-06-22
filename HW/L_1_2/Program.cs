using System;
using System.Globalization;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_1_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CH.SetConsoleOutputEncoding();
            CH.SetConsoleColor();

            //output caption
            CH.WriteSeparator();
            Console.WriteLine("\t\t\t\t\t\t- Sphere Calculator -");
            CH.WriteSeparator();
            Console.WriteLine("\t\t\t\t\t\t-= Basic Formulas =-");
            Console.WriteLine("\t\t\t\t\tVolume=(4/3)\u03C0R\u00B3 m\u00B3 & Area = 4\u03C0R\u00B2 m\u00B2");

            //input radius of sphere
            CH.WriteSeparator();
            var separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            double sphereRadius;
            string sphereRadiusString;

            do
            {
                sphereRadiusString = CH.GetStringFromConsole(
                    $"Please enter the radius (R) of your sphere in meters (m) [you must separate of number parts with \"{separator}\" char]");
            } while (!double.TryParse(sphereRadiusString, out sphereRadius));


            //convertation & calculations

            var sphereV = 4.0 / 3.0 * Math.PI * Math.Pow(sphereRadius, 3.0);
            var sphereA = 4.0 * Math.PI * Math.Pow(sphereRadius, 2.0);

            //output results
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            CH.WriteSeparator();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(
                "\tVolume=(4/3)\u03C0R\u00B3={0:0.###} m\u00B3{1}\tArea=(4/3)\u03C0R\u00B3={2:0.###} m\u00B2", sphereV,
                Environment.NewLine, sphereA);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            CH.WriteSeparator();
            Console.WriteLine(
                $"\tThank you for using our program, we hope it helped you :D {Environment.NewLine}\tGoodbye!");

            //exit
            Console.ReadKey();
        }
    }
}