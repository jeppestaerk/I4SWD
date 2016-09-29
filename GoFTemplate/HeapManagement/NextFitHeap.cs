using System.Collections.Generic;

namespace HeapManagement
{
    public class NextFitHeap : Heap
    {
        private int _nextAllocationStartAddr;

        public NextFitHeap(int size) : base(size)
        {
            _nextAllocationStartAddr = 0;
        }

        protected override int FindBuffer(int size, List<Block> candidates)
        {
            var startAddr = _nextAllocationStartAddr;
            if (candidates.Count == 0) throw new HeapManagementException("Unable to allocate memory", 0, size);

            var candidateFound = false;

            // Attempt to find block such that startadress is the smallest address 
            // bigger than _nextAllocationStartAddr
            foreach (var candidate in candidates)
                if ((candidate.StartAddr >= _nextAllocationStartAddr) && (candidate.StartAddr <= startAddr))
                {
                    candidateFound = true;
                    startAddr = candidate.StartAddr;
                }

            if (!candidateFound)
            {
                // No candidate found in _nextAllocationStartAddr;Memory.Length) 
                // - wrap-around of start address necessary
                _nextAllocationStartAddr = 0;

                foreach (var candidate in candidates)
                    if ((candidate.StartAddr >= _nextAllocationStartAddr) && (candidate.StartAddr <= startAddr))
                        startAddr = candidate.StartAddr;
            }

            _nextAllocationStartAddr = startAddr + size;
            return startAddr;
        }
    }
}