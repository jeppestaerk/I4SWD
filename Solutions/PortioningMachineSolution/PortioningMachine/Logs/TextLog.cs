using PortioningMachine.SystemComponents;

namespace PortioningMachine.Logs
{
    public abstract class TextLog : ILog
    {

        protected abstract void Write(string str);

        public void LogBinClosed(uint id, double targetWeight, double curWeight, double giveAway)
        {
            var str = string.Format("Bin {0} closed. Target = {1:0.00}g, actual = {2:0.00}g, give-away = {3:0.00}%",
                id, targetWeight, curWeight, giveAway);
            Write(str);

        }

        public void LogItemReceived(IItem item)
        {
            Write(string.Format("Item {0} received", item));
        }

        public void LogItemWasted(IItem item)
        {
            Write(string.Format("{0} GOES IN GARBAGE BIN!!!", item));
        }

        public void LogItemAllocated(IBin bin, IItem item)
        {
            Write(string.Format("Item {0} allocated to bin {1}", item, bin));
        }
    }
}