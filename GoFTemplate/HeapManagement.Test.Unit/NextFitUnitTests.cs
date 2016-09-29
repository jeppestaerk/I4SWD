using NUnit.Framework;

namespace HeapManagement.Test.Unit
{
    [TestFixture]
    public class NextFitUnitTests : HeapUnitTests
    {
        protected override Heap GetUut()
        {
            return new NextFitHeap(HeapSize);
        }

        [Test]
        public void Allocate_OneAllocationAndDeallocationPerformed_NextAddressReturned()
        {
            _uut.Allocate(10);
            _uut.Allocate(10);
            _uut.Deallocate(0, 10);
            Assert.That(_uut.Allocate(10), Is.EqualTo(20));
        }

        [Test]
        public void Allocate_OneAllocationPerformed_NextAddressReturned()
        {
            _uut.Allocate(10);
            Assert.That(_uut.Allocate(10), Is.EqualTo(10));
        }

        [Test]
        public void Allocate_PristineHeap_FirstAddressReturned()
        {
            Assert.That(_uut.Allocate(10), Is.EqualTo(0));
        }

        [Test]
        public void Allocate_WrapAroundNecessary_Address0Returned()
        {
            _uut.Allocate(20); // [0;20)
            _uut.Allocate(20); // [20;49)
            _uut.Allocate(HeapSize - 2*20 - 10); // [40;90)
            _uut.Deallocate(0, 20); // Make hole [0;20)
            Assert.That(_uut.Allocate(20), Is.EqualTo(0));
        }

        [Test]
        public void Allocate_WrapAroundNecessary_CorrectAddressReturned()
        {
            _uut.Allocate(20); // [0;20)
            _uut.Allocate(20); // [20;49)
            _uut.Allocate(HeapSize - 2*20 - 10); // [40;90)
            _uut.Deallocate(20, 20); // Make hole [20;40)
            Assert.That(_uut.Allocate(20), Is.EqualTo(20));
        }
    }
}