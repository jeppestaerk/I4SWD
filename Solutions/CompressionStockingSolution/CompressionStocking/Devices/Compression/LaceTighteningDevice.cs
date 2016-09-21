namespace CompressionStocking.Devices.Compression
{
    public class LaceTighteningDevice : ILaceTighteningDevice
    {
        public void Tighten()
        {
            System.Console.WriteLine("LACES tightened 1 click");
        }

        public void Loosen()
        {
            System.Console.WriteLine("LACES loosened 1 clicks");
        }
    }
}