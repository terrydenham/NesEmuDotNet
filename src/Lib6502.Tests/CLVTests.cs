using NUnit.Framework;

namespace Lib6502.Tests
{
    public class CLVTests
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
        public void CLV_WhenSet_ClearsFlag()
        {
            sut.SetInitialState(CpuFlags.V);

            sut.CLV();

            Assert.False(sut.V);
        }

        [Test]
        public void CLV_WhenNotSet_ClearsFlag()
        {
            sut.SetInitialState(CpuFlags.Empty);

            sut.CLV();

            Assert.False(sut.V);
        }
    }
}
