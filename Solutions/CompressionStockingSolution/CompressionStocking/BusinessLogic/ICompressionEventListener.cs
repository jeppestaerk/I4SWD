namespace CompressionStocking.BusinessLogic
{
    public interface ICompressionEventListener
    {
        void CompressionInitiated();
        void CompressionComplete();
        void DecompressionInitiated();
        void DecompressionComplete();
    }
}