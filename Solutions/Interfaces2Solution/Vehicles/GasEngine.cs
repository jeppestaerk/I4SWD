using System;

namespace Vehicles
{
    public class GasEngine : IEngine
    {
        private uint _curThrottle;


        public GasEngine(uint maxthrottle)
        {
            MaxThrottle= maxthrottle;
        }

        public uint MaxThrottle { get; }

        public void SetThrottle(uint thr)
        {
            _curThrottle = thr;
            Console.WriteLine($"Gas engine running at {thr}");
        }

        public uint GetThrottle()
        {
            return _curThrottle;
        }
    }

}
