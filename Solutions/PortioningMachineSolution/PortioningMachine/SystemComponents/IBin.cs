namespace PortioningMachine.SystemComponents
{
    public interface IBin
    {
        uint Id { get; }
        double TargetWeight { get; }
        double CurWeight { get; }

        void ReceiveItem(IItem item);
        double ScoreItem(IItem item);
    }
}