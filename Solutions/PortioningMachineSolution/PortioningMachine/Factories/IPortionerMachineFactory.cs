using PortioningMachine.ItemProviders;

namespace PortioningMachine.Factories
{
    public interface IPortionerMachineFactory
    {
        IItemProvider CreateItemProvider();
        void CreatePortionerControl(IItemProvider itemProvider, uint nBins);
    }
}