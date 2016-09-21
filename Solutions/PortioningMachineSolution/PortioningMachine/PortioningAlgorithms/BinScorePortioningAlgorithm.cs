using System;
using System.Collections.Generic;
using PortioningMachine.SystemComponents;

namespace PortioningMachine.PortioningAlgorithms
{
    public class BinScorePortioningAlgorithm : IPortioningAlgorithm
    {
        public IBin FindTargetBin(IItem item, List<IBin> bins)
        {
            var highestScore = -1.0;
            var targetBin = bins[0];

            foreach (var bin in bins)
            {
                var score = bin.ScoreItem(item);
                if (score > highestScore)
                {
                    highestScore = score;
                    targetBin = bin;
                }
            }

            if (Math.Abs(highestScore - 1.0) < Double.Epsilon)
            {
                // Rotate list

                IBin first = bins[0];
                bins.RemoveAt(0);
                bins.Add(first);
                //System.Console.WriteLine("Score {2:0.00}: {0} > {1}", item, targetBin, highestScore);
            }
            return targetBin;
        }
    }
}