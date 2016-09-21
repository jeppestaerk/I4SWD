using System;

namespace CompressionStocking.Devices.UserInterface
{
    public class Vibrator : ITwoStateUnit
    {
        public void TurnOn()
        {
            Console.WriteLine("Vibrator turned ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("Vibrator turned OFF");
        }
    }
}