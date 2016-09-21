using System.Collections.Generic;
using PortioningMachine.SystemComponents;

namespace PortioningMachine.PortioningAlgorithms
{
    public class RoundRobinPortioningAlgorithm : IPortioningAlgorithm
    {
        private int _curBinIndex;

        public RoundRobinPortioningAlgorithm()
        {
            _curBinIndex = 0;
        }


        public IBin FindTargetBin(IItem item, List<IBin> bins)
        {
            var targetBin = bins[_curBinIndex];
            _curBinIndex = (_curBinIndex + 1)%bins.Count;
            return targetBin;
        }
    }
}