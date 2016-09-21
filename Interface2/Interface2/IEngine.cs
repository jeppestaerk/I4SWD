namespace Interface2
{
    public interface IEngine
    {
        uint MaxThrottle { get; }

        uint GetThrottle();
        void SetThrottle(uint thr);
    }
}