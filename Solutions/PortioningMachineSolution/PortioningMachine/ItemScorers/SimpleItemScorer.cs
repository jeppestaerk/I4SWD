using PortioningMachine.SystemComponents;

namespace PortioningMachine.ItemScorers
{
    public class SimpleItemScorer : IItemScorer
    {
        public double ScoreItem(IItem item, double binCurWeight, double binTargetWeight)
        {
            return 1.0;
        }
    }
}