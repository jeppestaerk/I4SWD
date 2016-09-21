using CompressionStocking.Mechanisms.Compression;
using CompressionStocking.Mechanisms.UserInterface;

namespace CompressionStocking.BusinessLogic
{
    public class StockingCtrl : IButtonHandler, ICompressionEventListener
    {
        private enum State
        {
            Relaxed,
            Compressing,
            Compressed,
            Decompressing
        }
        private readonly ICompressionMechanism _compressionMechanism;
        private readonly IUserOutput _userOutput;
        private State _state;

        public StockingCtrl(ICompressionMechanism compressionMechanism, IUserOutput userOutput)
        {
            _compressionMechanism = compressionMechanism;
            _userOutput = userOutput;
            _state = State.Relaxed;
        }


        // From IButtonHandler
        public void StartBtnPushed()
        {
            switch (_state)
            {
                case State.Relaxed:
                    _state = State.Compressing;
                    _compressionMechanism.Compress();
                    break;

                case State.Decompressing:
                    _state = State.Compressing;
                    _compressionMechanism.Stop();
                    _compressionMechanism.Compress();
                    break;
            }
        }

        public void StopBtnPushed()
        {
            switch (_state)
            {
                case State.Compressed:
                    _state = State.Decompressing;
                    _compressionMechanism.Decompress();
                    break;

                case State.Compressing:
                    _state = State.Decompressing;
                    _compressionMechanism.Stop();
                    _compressionMechanism.Decompress();
                    break;
            }
        }

        // From ICompressionEventListener
        public void CompressionInitiated()
        {
            _userOutput.InformCompressionInitiated();
        }


        public void DecompressionInitiated()
        {
            _userOutput.InformDecompressionInitiated();
        }

        public void CompressionComplete()
        {
            _state = State.Compressed;
            _userOutput.InformCompressionComplete();
        }

        public void DecompressionComplete()
        {
            _state = State.Relaxed;
            _userOutput.InformDecompressionComplete();
        }


    }
}