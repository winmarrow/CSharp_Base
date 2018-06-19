using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using L_2_2.Abstractions;
using SharedLib.Abstract;

namespace L_2_2.Collections
{
    public class HomoSapiensCollection : Collection<HomoSapiens>
    {
        private const string AlreadyExistErrorString = "Same item already exist in collection";
        private const string AddItemString = "Item was successfully added";

        private Logger _logger;

        public HomoSapiensCollection(Logger logger)
        {
            _logger = logger;
        }

        public HomoSapiensCollection(Logger logger, IEnumerable<HomoSapiens> homoSapienses)
            : base(homoSapienses.ToList())
        {
            _logger = logger;
        }

        protected override void InsertItem(int index, HomoSapiens item)
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
