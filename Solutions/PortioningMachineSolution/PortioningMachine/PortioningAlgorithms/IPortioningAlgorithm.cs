using System.Collections.Generic;
using PortioningMachine.SystemComponents;

namespace PortioningMachine.PortioningAlgorithms
{
    public interface IPortioningAlgorithm
    {
        IBin FindTargetBin(IItem item, List<IBin> bins);
    }
}