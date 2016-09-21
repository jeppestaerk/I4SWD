using PortioningMachine.ItemScorers;
using PortioningMachine.Logs;

namespace PortioningMachine.SystemComponents
{
    public class Bin : IBin
    {
        private readonly ILog _log;
        public double TargetWeight { get; private set; }
        public double CurWeight { get; private set; }
        public IItemScorer ItemScorer { set; private get; }

        public Bin(uint id, double targetWeight, ILog log)
        {
            Id = id;
            TargetWeight = targetWeight;
            _log = log;
            CurWeight = 0;
        }

        public uint Id { get; private set; }


        public void ReceiveItem(IItem item)
        {
            CurWeight += item.Weight;
            _log.LogItemAllocated(this, item);

            if (CurWeight >= TargetWeight) CloseBin();
        }

        public double ScoreItem(IItem item)
        {
            if (ItemScorer == null) throw new PortioningControlException("ItemScorer not set!");
            return ItemScorer.ScoreItem(item, CurWeight, TargetWeight);
        }

        private void CloseBin()
        {
            var giveAway = (CurWeight - TargetWeight)/TargetWeight*100;

            // Create string to log
            var str = string.Format("Bin {0} closed. Target = {1:0.00}g, actual = {2:0.00}g, give-away = {3:0.00}%",
                Id, TargetWeight, CurWeight, giveAway);
            _log.LogBinClosed(Id, TargetWeight, CurWeight, giveAway);

            CurWeight = 0;
        }

        public override string ToString()
        {
            return string.Format("Bin [{0}, {1:0.00} > {2:0.00}]", Id, CurWeight, TargetWeight);
        }
    }
}