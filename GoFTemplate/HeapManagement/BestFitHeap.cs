using System.Collections.Generic;
using System.Linq;

namespace HeapManagement
{
    public class BestFitHeap : Heap
    {
        public BestFitHeap(int size) : base(size)
        {
        }

        protected override int FindBuffer(int size, List<Block> candidates)
        {
            if (candidates.Count == 0) throw new HeapManagementException("Unable to allocate memory", 0, size);

            var findCandidate = candidates[0];
            for (var i = 1; i < candidates.Count; i++)
                if (candidates[i].Length < findCandidate.Length) findCandidate = candidates[i];
            return findCandidate.StartAddr;
        }
    }
}
