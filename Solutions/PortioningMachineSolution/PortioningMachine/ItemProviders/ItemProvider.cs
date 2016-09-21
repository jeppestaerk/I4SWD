using System.Threading;
using PortioningMachine.SystemComponents;

namespace PortioningMachine.ItemProviders
{
    public class ItemProvider : IItemProvider
    {
        private readonly IDistribution _dist;
        private uint _itemId;

        public ItemProvider(IDistribution dist)
        {
            _dist = dist;
            _itemId = 0;
        }

        public event ItemArrivedHandler ItemArrived;

        public void Go()
        {
            var thread = new Thread(Run);
            thread.Start();
        }

        private void OnItemArrived(IItem i)
        {
            if (ItemArrived != null) ItemArrived(this, i);
        }

        private void Run()
        {
            while (true)
            {
                IItem item = new Item {Id = ++_itemId, Weight = _dist.Next()};
                OnItemArrived(item);
                Thread.Sleep(10);
            }
        }
    }
}