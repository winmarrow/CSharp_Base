using L_2_2.Collections;
using SharedLib.Abstract;
using SharedLib.Loggers;
using CH = SharedLib.Helpers.ConsoleHelper;

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