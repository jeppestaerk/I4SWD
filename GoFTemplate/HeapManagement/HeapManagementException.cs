using System;

namespace HeapManagement
{
    public class HeapManagementException : Exception
    {
        public HeapManagementException(string msg, int startAddr, int bufferSize) : base(msg)
        {
            BufferSize = bufferSize;
            StartAddr = startAddr;
        }

        public int BufferSize { get; private set; }
        public int StartAddr { get; private set; }
    }
}