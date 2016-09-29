using System.Collections.Generic;

namespace HeapManagement
{
    public class FirstFitHeap : Heap
    {
        public FirstFitHeap(int size) : base(size)
        {
        }

        protected override int FindBuffer(int size, List<Block> candidates)
        {
            if (candidates.Count == 0) throw new HeapManagementException("Unable to allocate memory", 0, size);

            var startAddress = candidates[0].StartAddr;
            for (var i = 1; i < candidates.Count; i++)
                if (candidates[i].StartAddr < startAddress) startAddress = candidates[i].StartAddr;
            return startAddress;
        }
    }
}