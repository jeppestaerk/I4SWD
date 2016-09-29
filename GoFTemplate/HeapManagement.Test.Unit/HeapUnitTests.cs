using NUnit.Framework;

namespace HeapManagement.Test.Unit
{
    [TestFixture]
    public abstract class HeapUnitTests
    {
        [SetUp]
        public void Setup()
        {
            _uut = GetUut();
        }

        protected Heap _uut;
        protected const int HeapSize = 100;

        protected abstract Heap GetUut();


        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(HeapSize + 1)]
        public void Allocate_GenericInvalidHeapSizeForAllocation_RequestCannotBeSatisfied(int size)
        {
            Assert.Throws<HeapManagementException>(() => _uut.Allocate(size));
        }

        [TestCase(0, 11)]
        [TestCase(1, 10)]
        [TestCase(5, 6)]
        [TestCase(-1, 11)]
        public void Deallocate_GenericInvalidStartAddresses_NotAllowed(int startAddr, int size)
        {
            _uut.Allocate(10);
            Assert.Throws<HeapManagementException>(() => _uut.Deallocate(startAddr, size));
        }

        [Test]
        public void Allocate_GenericCompleteHeapAllocation_RequestSatisfied()
        {
            Assert.DoesNotThrow(() => _uut.Allocate(HeapSize));
        }

        [Test]
        public void Allocate_GenericHeapAlmostExhaustedNextRequestTooBig_RequestCannotBeSatisfied()
        {
            _uut.Allocate(HeapSize - 10);
            Assert.Throws<HeapManagementException>(() => _uut.Allocate(11));
        }

        [Test]
        public void Allocate_GenericUnsatisfiableRequest_RequestNotSatisfied()
        {
            _uut.Allocate(10);
            _uut.Allocate(10);
            _uut.Deallocate(0, 10);
            _uut.Allocate(80);
            Assert.Throws<HeapManagementException>(() => _uut.Allocate(11));
        }
    }
}