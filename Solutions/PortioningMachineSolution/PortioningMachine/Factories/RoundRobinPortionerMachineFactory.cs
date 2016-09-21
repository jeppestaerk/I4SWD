using PortioningMachine.ItemProviders;
using PortioningMachine.Logs;
using PortioningMachine.PortioningAlgorithms;
using PortioningMachine.SystemComponents;

namespace PortioningMachine.Factories
{
    public class RoundRobinPortionerMachineFactory : IPortionerMachineFactory
    {
        public IItemProvider CreateItemProvider()
        {
            return new ItemProvider(new GaussianDistribution(125, 25));
        }


        public void CreatePortionerControl(IItemProvider itemProvider, uint nBins)
        {
            var ctrlLog = new SimpleTextLog();
            var binLog = new SimpleTextLog();

            var control = new Control(itemProvider, ctrlLog, new RoundRobinPortioningAlgorithm());

            for (uint i = 0; i < nBins; i++)
            {
                control.AddBin(new Bin(i, 2000, binLog));
            }
        }
    }
}