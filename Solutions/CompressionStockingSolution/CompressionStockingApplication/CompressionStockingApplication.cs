using System;
using CompressionStocking.BusinessLogic;
using CompressionStocking.Devices.Compression;
using CompressionStocking.Devices.UserInterface;
using CompressionStocking.Mechanisms.Compression;
using CompressionStocking.Mechanisms.UserInterface;

namespace CompressionStockingApplication
{
  class CompressionStockingApplication
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKeyInfo;
            
            Console.WriteLine("Compression Stocking Configuration");
            Console.WriteLine("A:   Air compression mechanism");
            Console.WriteLine("Z:   Laces compresison mechanism");
            Console.WriteLine("ESC: Terminate application");
            var configOk = false;

            // Read user input and create the applicable compression mechanism
            ICompressionMechanism compressionMechanism = null;  // Will be initiated below according to user's choice
            do
            {
                consoleKeyInfo = Console.ReadKey(true); // true = do not echo character

                if (consoleKeyInfo.Key == ConsoleKey.A)
                {
                    compressionMechanism = new AirCompressionMechanism(new Pump(), 5000, 2000);
                    configOk = true;
                }
                if (consoleKeyInfo.Key == ConsoleKey.Z)
                {
                    compressionMechanism = new LaceCompressionMechanism(40, 100, new LaceTighteningDevice() );
                    configOk = true;
                }
                if (consoleKeyInfo.Key == ConsoleKey.Escape)
                    return;

            } while (!configOk);

            // Create the Stocking Controller using the factory corresponding to user's choice
            IUserOutput userOutput = new UserOutput(new LED(), new LED(), new Vibrator());
            StockingCtrl stockingCtrl = new StockingCtrl(compressionMechanism, userOutput);
            compressionMechanism.CompressionEventListener = stockingCtrl;   // Set up call-back receiver


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Compression Stocking Control User Interface");
            Console.WriteLine("A:   Compress");
            Console.WriteLine("Z:   Decompress");
            Console.WriteLine("ESC: Terminate application");

            do
            {
                consoleKeyInfo = Console.ReadKey(true); // true = do not echo character
                if (consoleKeyInfo.Key == ConsoleKey.A)  stockingCtrl.StartBtnPushed();
                if (consoleKeyInfo.Key == ConsoleKey.Z)  stockingCtrl.StopBtnPushed();

            } while (consoleKeyInfo.Key != ConsoleKey.Escape);
        }
    }
}
