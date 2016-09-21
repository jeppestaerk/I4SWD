using Vehicles;

namespace VehicleAppl
{
    class Program
    {
        static void Main(string[] args)
        {
            var bike = new Motorbike(new GasEngine(100));
            bike.RunAtHalfSpeed();

            bike = new Motorbike(new DieselEngine(30));
            bike.RunAtHalfSpeed();
        }
    }
}
