using PortioningMachine.SystemComponents;

namespace PortioningMachine.ItemProviders
{
    public delegate void ItemArrivedHandler(object o, IItem item);

    public interface IItemProvider
    {
        event ItemArrivedHandler ItemArrived;
        void Go();
    }
}