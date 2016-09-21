namespace Interface2.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var bike = new MotorBike(new GasEngine(100));
            bike.RunAtHalfSpeed();

            bike = new MotorBike(new DieselEngine(30));
            bike.RunAtHalfSpeed();
        }
    }
}
