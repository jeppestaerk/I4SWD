namespace Vehicles
{
    public class Motorbike
    {	
        private readonly IEngine _engine;

	    public Motorbike(IEngine engine)
	    {
		    _engine = engine;
	    }

	    public void RunAtHalfSpeed()
	    {
	        var curThrottle = _engine.MaxThrottle;
            _engine.SetThrottle(curThrottle/2);
	    }

    }
}
