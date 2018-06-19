using System;

namespace SharedLib.Random
{
    public class Rnd
    {
        private static readonly PersonNameGenerator NameGenerator;
        private static readonly System.Random Rand;

        static Rnd()
        {
            Rand = new System.Random(DateTime.Now.Second);
            NameGenerator = new PersonNameGenerator(Rand);
        }

        public static string RandomFirstName => NameGenerator.GenerateRandomFirstName();
        public static string RandomLastName => NameGenerator.GenerateRandomLastName();
        public static double RandomMark => Rand.Next(0, 9) + Rand.NextDouble();
    }
}