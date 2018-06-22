using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using L_2_2.Abstractions;
using SharedLib.Abstract;

namespace L_2_2.Collections
{
    public class HumanCollection : Collection<Human>
    {
        private const string AlreadyExistErrorString = "Same item already exist in collection";
        private const string AddItemString = "Item was successfully added";

        private readonly Logger _logger;

        public HumanCollection(Logger logger)
        {
            _logger = logger;
        }

        public HumanCollection(Logger logger, IEnumerable<Human> human)
            : base(human.ToList())
        {
            _logger = logger;
        }

        protected override void InsertItem(int index, Human item)
        {
            if (Contains(item))
            {
                _logger.LogError(AlreadyExistErrorString);
                _logger.LogError(item.ToString(), false);
                return;
            }

            base.InsertItem(index, item);
            _logger.LogInfo(AddItemString);
        }
    }
}