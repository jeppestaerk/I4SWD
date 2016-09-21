using System;

namespace CompressionStocking.Devices.Compression
{
    public class Pump : IPump
    {
        public void PumpPositive()
        {
            Console.WriteLine("Pump building POSITIVE pressure");
        }

        public void Stop()
        {
            Console.WriteLine("Pump stopped");
        }

        public void PumpNegative()
        {
            Console.WriteLine("Pump building NEGATIVE pressure");
        }
    }
}