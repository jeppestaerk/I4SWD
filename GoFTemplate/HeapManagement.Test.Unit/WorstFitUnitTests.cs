using NUnit.Framework;

namespace HeapManagement.Test.Unit
{
    [TestFixture]
    public class WorstFitUnitTests : HeapUnitTests
    {
        protected override Heap GetUut()
        {
            return new WorstFitHeap(HeapSize);
        }


        [TestCase(1, 60)]
        [TestCase(8, 60)]
        [TestCase(10, 60)]
        [TestCase(11, 60)]
        [TestCase(15, 60)]
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

        [Test]
        public void Allocate_DeallocateToProduceNewWorstFit_CorrectAddressReturned()
        {
            _uut.Allocate(10); // 0-10
            _uut.Allocate(10); // 10-20
            _uut.Allocate(10); // 20-30
            _uut.Allocate(10); // 30-40
            _uut.Allocate(40); // 40-80
            _uut.Deallocate(10, 10);
            _uut.Deallocate(20, 10);
            _uut.Deallocate(30, 10);
            Assert.That(_uut.Allocate(10), Is.EqualTo(10));
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