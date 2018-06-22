using L_2_2.Collections;
using SharedLib.Abstract;
using SharedLib.ConsoleHelpers;
using CH = SharedLib.ConsoleHelpers.ConsoleHelper;

namespace L_2_2.Entities
{
    public class University
    {
        public University()
        {
            Logger logger = new ConsoleLogger();
            UnivrsityHumans = new HumanCollection(logger);
        }

        public HumanCollection UnivrsityHumans { get; }

        public void UniversityWork()
        {
            foreach (var univrsityHuman in UnivrsityHumans)
                univrsityHuman.Work();
        }
    }
}