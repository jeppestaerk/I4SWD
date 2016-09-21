using System.Threading;
using CompressionStocking.Devices.Compression;

namespace CompressionStocking.Mechanisms.Compression
{
    public class LaceCompressionMechanism : CompressionMechanism
    {
        private readonly uint _nClicksToCompress;
        private readonly uint _msBetweenClicks; 
        private readonly ILaceTighteningDevice _laceTighteningDevice;

        public LaceCompressionMechanism(uint nClicksToCompress, uint msBetweenClicks, ILaceTighteningDevice laceTighteningDevice)
        {
            _nClicksToCompress = nClicksToCompress;
            _laceTighteningDevice = laceTighteningDevice;
            _msBetweenClicks = msBetweenClicks;
        }


        public override void Compress()
        {
            InformCompressionInitiated();
            for (uint i = 0; i < _nClicksToCompress; i++)
            {
                _laceTighteningDevice.Tighten();
                Thread.Sleep((int) _msBetweenClicks);
            }
            InformCompressionComplete();
        }



        public override void Decompress()
        {
            InformDecompressionInitiated();
            for (uint i = 0; i < _nClicksToCompress; i++)
            {
                _laceTighteningDevice.Loosen();
                Thread.Sleep((int) _msBetweenClicks);
            }
            InformDecompressionComplete();
        }

        public override void Stop()
        {
            
        }
    }
}