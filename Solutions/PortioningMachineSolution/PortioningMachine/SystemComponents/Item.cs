namespace PortioningMachine.SystemComponents
{
    public class Item : IItem
    {
        public uint Id { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}, {1:0.00}]", Id, Weight);
        }
    }
}