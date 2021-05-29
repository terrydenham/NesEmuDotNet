using NUnit.Framework;

namespace Lib6502.Tests
{
    public class PHPTests
    {
        protected Memory mem;
        protected m6502 sut;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            mem = new Memory(1024 * 32);
            sut = new m6502(mem);
        }

        [SetUp]
        public void Setup()
        {
            mem.Clear();
            sut.Reset();
        }

        [Test]
        public void PHP_MovesAccumulatorOntoStackDecrementsStackPointer()
        {
            CpuFlags expected = CpuFlags.All;

            ushort oldSP = sut.SP;

            sut.Status = expected;

            sut.PHP();

            Assert.AreEqual(expected, (CpuFlags)mem.Read(oldSP));

            Assert.AreEqual(oldSP - 1, sut.SP);
        }

        [Test]
        public void PHP_TakesThreeClockCycles()
        {
            Assert.AreEqual(3, sut.PHP());
        }
    }
}
