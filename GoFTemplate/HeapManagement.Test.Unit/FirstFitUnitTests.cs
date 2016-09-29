using NUnit.Framework;

namespace HeapManagement.Test.Unit
{
    [TestFixture]
    public class FirstFitUnitTests : HeapUnitTests
    {
        protected override Heap GetUut()
        {
            return new FirstFitHeap(HeapSize);
        }


        [TestCase(1, 0)]
        [TestCase(8, 0)]
        [TestCase(10, 0)]
        [TestCase(11, 40)]
        public void Allocate_SeveralAllocationsDeallocateFirstBufferThenAllocateBuffer_FirstFitReturned(int allocate,
            int expectedStartAddr)
        {
            _uut.Allocate(10); // 0
            _uut.Allocate(10); // 10
            _uut.Allocate(10); // 20
            _uut.Allocate(10); // 30
            _uut.Deallocate(0, 10); // Deallocate [0,10)
            Assert.That(_uut.Allocate(allocate), Is.EqualTo(expectedStartAddr));
        }

        [TestCase(1, 20)]
        [TestCase(8, 20)]
        [TestCase(10, 20)]
        [TestCase(11, 40)]
        public void Allocate_SeveralAllocationsDeallocateBufferInMiddleThenAllocateBuffer_FirstFitReturned(int allocate,
            int expectedStartAddr)
        {
            _uut.Allocate(10); // 0
            _uut.Allocate(10); // 10
            _uut.Allocate(10); // 20
            _uut.Allocate(10); // 30
            _uut.Deallocate(20, 10); // Deallocate [20,30)
            Assert.That(_uut.Allocate(allocate), Is.EqualTo(expectedStartAddr));
        }

        [Test]
        public void Allocate_PristineHeap_FirstAddressReturned()
        {
            Assert.That(_uut.Allocate(10), Is.EqualTo(0));
        }

        [Test]
        public void Allocate_SecondAllocation_FirstFitReturned()
        {
            _uut.Allocate(20);
            Assert.That(_uut.Allocate(10), Is.EqualTo(20));
        }

        [Test]
        public void Deallocate_AllocatedBufferDeallocatedThenAllocated_FirstAddressAllocated()
        {
            var startAddr = _uut.Allocate(10);
            _uut.Deallocate(startAddr, 10);
            Assert.That(_uut.Allocate(5), Is.EqualTo(0));
        }
    }
}