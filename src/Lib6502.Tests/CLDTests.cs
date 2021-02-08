using NUnit.Framework;

namespace Lib6502.Tests
{
    public class CLDTests
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
        public void CLD_WhenSet_ClearsFlag()
        {
            sut.SED();

            sut.CLD();

            Assert.False(sut.D);
        }

        [Test]
        public void CLD_WhenNotSet_ClearsFlag()
        {
            sut.SetInitialState(CpuFlags.Empty);

            sut.CLD();

            Assert.False(sut.D);
        }
    }
}
