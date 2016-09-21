using PortioningMachine.ItemProviders;
using PortioningMachine.ItemScorers;
using PortioningMachine.Logs;
using PortioningMachine.PortioningAlgorithms;
using PortioningMachine.SystemComponents;

namespace PortioningMachine.Factories
{
    public class MultipleOfMeanPortionerMachineFactory : IPortionerMachineFactory
    {
        public IItemProvider CreateItemProvider()
        {
            return new ItemProvider(new GaussianDistribution(125, 20));
        }

        public void CreatePortionerControl(IItemProvider itemProvider, uint nBins)
        {
            var ctrlLog = new FileTextLog("c:\\PortionerCtrlLog.txt");
            var binLog = new SimpleTextLog();
            //var binLog = new ConsoleLog();

            var control = new Control(itemProvider, ctrlLog, new BinScorePortioningAlgorithm());
            var scorer = new MultipleOfMeanItemScorer(125);

            for (uint i = 0; i < nBins; i++)
            {
                control.AddBin(new Bin(i, 2000, binLog) {ItemScorer = scorer});
            }
        }
    }
}