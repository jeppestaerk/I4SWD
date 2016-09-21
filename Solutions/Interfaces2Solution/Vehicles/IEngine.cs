namespace Vehicles
{
    public interface IEngine
    {
        uint MaxThrottle { get; }
        void SetThrottle(uint thr);
        uint GetThrottle();
    }
}