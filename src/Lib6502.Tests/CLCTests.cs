using NUnit.Framework;

namespace Lib6502.Tests
{
    public class CLCTests
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
        public void CLC_WhenSet_ClearsFlag()
        {
            sut.SEC();

            sut.CLC();

            Assert.False(sut.C);
        }

        [Test]
        public void CLC_WhenNotSet_ClearsFlag()
        {
            sut.SetInitialState(CpuFlags.Empty);

            sut.CLC();

            Assert.False(sut.C);
        }
    }
}
