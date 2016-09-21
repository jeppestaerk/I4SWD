using PortioningMachine.SystemComponents;

namespace PortioningMachine.ItemScorers
{
    public interface IItemScorer
    {
        double ScoreItem(IItem item, double binCurWeight, double binTargetWeight);
    }
}