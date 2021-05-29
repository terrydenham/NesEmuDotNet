using NUnit.Framework;

namespace Lib6502.Tests
{
    public class PLPTests
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
        public void PLP_MovesStackValueIntoProcessorStatusDecrementsStackPointer()
        {
            CpuFlags expected = CpuFlags.All;

            sut.SP--;

            ushort oldSP = sut.SP;

            mem.Write(sut.SP, (byte)expected);

            sut.PLP();

            Assert.AreEqual(expected, (CpuFlags)sut.Status);

            Assert.AreEqual(oldSP + 1, sut.SP);
        }

        [Test]
        public void PLP_TakesFourClockCycles()
        {
            Assert.AreEqual(4, sut.PLP());
        }
    }
}
