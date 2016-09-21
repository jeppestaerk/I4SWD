using System.Collections.Generic;
using PortioningMachine.ItemProviders;
using PortioningMachine.Logs;
using PortioningMachine.PortioningAlgorithms;

namespace PortioningMachine.SystemComponents
{
    public class Control
    {
        private readonly List<IBin> _bins;
        private readonly ILog _log;
        private readonly IPortioningAlgorithm _portioningAlgorithm;


        public Control(IItemProvider itemProvider, ILog log, IPortioningAlgorithm portioningAlgorithm)
        {
            _log = log;
            itemProvider.ItemArrived += HandleItem;
            _portioningAlgorithm = portioningAlgorithm;
            _bins = new List<IBin>();
        }

        public void AddBin(IBin bin)
        {
            _bins.Add(bin);
        }


        // Event handler
        public void HandleItem(object sender, IItem item)
        {
            if (_portioningAlgorithm == null) throw new PortioningControlException("Portioning algorithm not set");

            _log.LogItemReceived(item);

            // Find the target bin (delegated to the portioning algorithm)
            var targetBin = _portioningAlgorithm.FindTargetBin(item, _bins);

            // Assign item to bin, if found
            if (targetBin != null) targetBin.ReceiveItem(item);
            else
            {
                _log.LogItemWasted(item);
            }
        }
    }
}