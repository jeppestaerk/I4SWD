namespace CompressionStocking.Mechanisms.UserInterface
{
    public interface IUserOutput
    {
        void InformCompressionInitiated();
        void InformDecompressionInitiated();
        void InformCompressionComplete();
        void InformDecompressionComplete();
    }
}