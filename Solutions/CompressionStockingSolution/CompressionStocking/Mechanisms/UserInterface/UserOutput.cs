using CompressionStocking.Devices.UserInterface;

namespace CompressionStocking.Mechanisms.UserInterface
{
    public class UserOutput : IUserOutput
    {
        private readonly ITwoStateUnit _greenLED;
        private readonly ITwoStateUnit _redLED;
        private readonly ITwoStateUnit _vibrator;

        public UserOutput(ITwoStateUnit greenLed, ITwoStateUnit redLed, ITwoStateUnit vibrator)
        {
            _greenLED = greenLed;
            _redLED = redLed;
            _vibrator = vibrator;

            _greenLED.TurnOff();
            _redLED.TurnOff();
            _vibrator.TurnOff();
        }

        public void InformCompressionInitiated()
        {
            _greenLED.TurnOn();
            _vibrator.TurnOn();
        }

        public void InformDecompressionInitiated()
        {
            _redLED.TurnOn();
            _vibrator.TurnOn();
        }

        public void InformCompressionComplete()
        {
            _greenLED.TurnOff();
            _vibrator.TurnOff();
        }

        public void InformDecompressionComplete()
        {
            _redLED.TurnOff();
            _vibrator.TurnOff();
        }
    }
}