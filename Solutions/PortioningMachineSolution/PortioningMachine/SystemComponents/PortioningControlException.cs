using System;

namespace PortioningMachine.SystemComponents
{
    internal class PortioningControlException : Exception
    {
        public PortioningControlException(string str) : base(str)
        {
        }
    }
}