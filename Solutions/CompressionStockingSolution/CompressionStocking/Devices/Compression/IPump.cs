namespace CompressionStocking.Devices.Compression
{
    public interface IPump
    {
        void PumpPositive();
        void Stop();
        void PumpNegative();
    }
}