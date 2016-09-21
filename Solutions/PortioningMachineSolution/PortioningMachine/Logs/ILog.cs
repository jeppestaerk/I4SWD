using PortioningMachine.SystemComponents;

namespace PortioningMachine.Logs
{
    public interface ILog
    {
        void LogBinClosed(uint id, double targetWeight, double curWeight, double giveAway);
        void LogItemReceived(IItem item);
        void LogItemWasted(IItem item);
        void LogItemAllocated(IBin bin, IItem item);
    }
}