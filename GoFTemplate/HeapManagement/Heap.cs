using System.Collections.Generic;

namespace HeapManagement
{
    public abstract class Heap
    {
        protected const bool Allocated = true;
        private const bool Free = false;
        protected bool[] Memory;

        protected Heap(int size)
        {
            Memory = new bool[size];
            for (var i = 0; i < size; i++)
                Memory[i] = Free;
        }


        // Returns "address" of a buffer of size 'size'
        public int Allocate(int size)
        {
            // Find a buffer
            if ((size <= 0) || (size > Memory.Length))
                throw new HeapManagementException("Cannot allocate buffer of invalid size", 0, size);

            var startAddr = FindBuffer(size, FindCandidateBlocks(size)); // Delegated to concrete implementations
            for (var i = startAddr; i < startAddr + size; i++)
                Memory[i] = Allocated;
            return startAddr;
        }


        public void Deallocate(int addr, int size)
        {
            if ((addr < 0) || (addr + size > Memory.Length)) // Start address/size combination invalid
                throw new HeapManagementException("Cannot deallocate buffer with invalid start address and/or size",
                    addr, size);

            for (var i = addr; i < addr + size; i++) // Buffer for deallocation (partially) unallocated
                if (Memory[i] != Allocated)
                    throw new HeapManagementException("Trying to deallocate unallocated buffer", addr, size);

            for (var i = addr; i < addr + size; i++)
                Memory[i] = Free;
        }

        // Returns start adresses of all contiguous blocks of memory of size >= 'size'
        protected List<Block> FindCandidateBlocks(int size)
        {
            var candidateBlocks = new List<Block>();
            for (var i = 0; i < Memory.Length;)
            {
                var blockFound = true;
                var j = 0;
                for (; j < size; j++)
                    if ((i + j >= Memory.Length) || (Memory[i + j] == Allocated))
                    {
                        blockFound = false;
                        break;
                    }
                if (blockFound)
                {
                    while ((i + j < Memory.Length) && (Memory[i + j] != Allocated)) j++;
                    candidateBlocks.Add(new Block(i, j));
                }
                else
                {
                    while ((i + j < Memory.Length) && (Memory[i + j] == Allocated)) j++;
                }
                i += j;
            }

            return candidateBlocks;
        }

        protected abstract int FindBuffer(int size, List<Block> candidates );
    }

    public class Block
    {
        public Block(int sa, int l)
        {
            StartAddr = sa;
            Length = l;
        }

        public int StartAddr { get; private set; }
        public int Length { get; private set; }
    }
}