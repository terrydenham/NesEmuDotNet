using NUnit.Framework;

namespace Lib6502.Tests
{
    public class NOPTests
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
        public void NOP_FlagsAreNotChanged()
        {
            sut.SetInitialState(CpuFlags.Empty);
            
            sut.NOP();

            Assert.False(sut.B);
            Assert.False(sut.C);
            Assert.False(sut.D);
            Assert.False(sut.I);
            Assert.False(sut.N);
            Assert.False(sut.U);
            Assert.False(sut.V);
            Assert.False(sut.Z);
        }
    }
}

