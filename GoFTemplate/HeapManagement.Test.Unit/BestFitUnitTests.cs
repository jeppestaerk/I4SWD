using NUnit.Framework;

namespace HeapManagement.Test.Unit
{
    [TestFixture]
    public class BestFitUnitTests : HeapUnitTests
    {
        protected override Heap GetUut()
        {
            return new BestFitHeap(HeapSize);
        }


        [TestCase(1, 0)]
        [TestCase(8, 0)]
        [TestCase(10, 0)]
        [TestCase(11, 30)]
        [TestCase(15, 30)]
        [TestCase(16, 60)]
        public void Allocate_SeveralAllocationsDeallocationsThenAllocateBuffer_BestFitReturned(int allocate,
            int expectedStartAddr)
        {
            _uut.Allocate(10); // 0-10
            _uut.Allocate(10); // 10-20
            _uut.Allocate(10); // 20-30
            _uut.Allocate(15); // 30-45
            _uut.Allocate(15); // 45-60
            _uut.Deallocate(0, 10); // Deallocate 0-10
            _uut.Deallocate(30, 15); // Deallocate 30-45
            Assert.That(_uut.Allocate(allocate), Is.EqualTo(expectedStartAddr));
        }

        [TestCase(1, 30)]
        [TestCase(8, 30)]
        [TestCase(10, 30)]
        [TestCase(15, 30)]
        [TestCase(16, 0)]
        [TestCase(20, 0)]
        [TestCase(21, 60)]
        public void Allocate_SeveralAllocationsDeallocationOfLargeChunkThenAllocateBuffer_BestFitReturned(int allocate,
            int expectedStartAddr)
        {
            _uut.Allocate(10); // 0-10
            _uut.Allocate(10); // 10-20
            _uut.Allocate(10); // 20-30
            _uut.Allocate(15); // 30-45
            _uut.Allocate(15); // 45-60
            _uut.Deallocate(0, 10); // Deallocate 0-10
            _uut.Deallocate(10, 10); // Deallocate 10-20
            _uut.Deallocate(30, 15); // Deallocate 30-45
            Assert.That(_uut.Allocate(allocate), Is.EqualTo(expectedStartAddr));
        }

        [Test]
        public void Allocate_PristineHeap_FirstAddressReturned()
        {
            Assert.That(_uut.Allocate(10), Is.EqualTo(0));
        }

        [Test]
        public void Allocate_SecondAllocation_BestFitReturned()
        {
            _uut.Allocate(20);
            Assert.That(_uut.Allocate(10), Is.EqualTo(20));
        }
    }
}