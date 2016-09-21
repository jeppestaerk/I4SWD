namespace Interface2
{
    public class MotorBike
    {
        private readonly IEngine _engine;

        public MotorBike(IEngine engine)
        {
            _engine = engine;
        }
        public void RunAtHalfSpeed()
        {
            _engine.SetThrottle(_engine.MaxThrottle / 2);
        }
    }
}
