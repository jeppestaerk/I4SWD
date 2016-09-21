using System;

namespace Vehicles
{
    public class DieselEngine : IEngine
    {
        private uint _curThrottle;

        public DieselEngine(uint maxThrottle)
        {
            MaxThrottle = maxThrottle;
        }

        public uint MaxThrottle { get; }
        
        public void SetThrottle(uint thr)
        {
            _curThrottle = thr;
            Console.WriteLine($"Diesel engine running at {thr}");
        }

        public uint GetThrottle()
        {
            return _curThrottle;
        }
    }
}