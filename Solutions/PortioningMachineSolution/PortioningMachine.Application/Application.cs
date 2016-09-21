using PortioningMachine.Factories;
using PortioningMachine.ItemProviders;

namespace PortioningMachine.Application
{
    public class Application
    {
        public static void Main()
        {
            IPortionerMachineFactory factory = new RoundRobinPortionerMachineFactory();
            //IPortionerMachineFactory factory = new MultipleOfMeanPortionerMachineFactory();

            var itemProvider = factory.CreateItemProvider();
            factory.CreatePortionerControl(itemProvider, 8);

            itemProvider.Go();
        }
    }
}