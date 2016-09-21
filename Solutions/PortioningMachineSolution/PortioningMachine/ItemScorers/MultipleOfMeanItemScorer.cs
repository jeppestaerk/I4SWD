using System;
using PortioningMachine.SystemComponents;

namespace PortioningMachine.ItemScorers
{
    public class MultipleOfMeanItemScorer : IItemScorer
    {
        private readonly double _itemMean;

        public MultipleOfMeanItemScorer(double itemMean)
        {
            _itemMean = itemMean;
        }

        public double ScoreItem(IItem item, double binCurWeight, double binTargetWeight)
        {
            double retVal = 0.0;

            // If the weight of the bin is more than 4 times the item mean away, just get the darn thing!
            if (binTargetWeight - binCurWeight > 4*_itemMean) return 1.0;

            // Calculate remainder between weight with item and integer multiple of mean
            double remainder = binTargetWeight - (binCurWeight + item.Weight);

            if (remainder < 0) // Overshoot - special rule for scoring
            {
                remainder = -remainder;
                // Worst case: Remainder is close to _itemMean (or even a bit over)
                // Best case: Remainder is close to 0
                if (remainder > _itemMean)
                    return 0.0;

                retVal = 1 - remainder/_itemMean;
            }

            else
            {
                remainder = Math.Abs(Math.IEEERemainder(remainder, _itemMean));

                // Score remainder:
                // Worst-case: Residual is _itemMean/2
                // Best-case: Residual is close to 0 or close to _itemMean
                retVal = 1 - remainder/(_itemMean/2);
            }

            // System.Console.WriteLine("Retval: {0:0.00}", retVal);
            return retVal;
        }
    }
}