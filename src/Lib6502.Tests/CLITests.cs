using NUnit.Framework;

namespace Lib6502.Tests
{
    public class CLITests
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
        public void CLI_WhenSet_ClearsFlag()
        {
            sut.SEI();

            sut.CLI();

            Assert.False(sut.I);
        }

        [Test]
        public void CLI_WhenNotSet_ClearsFlag()
        {
            sut.SetInitialState(CpuFlags.Empty);

            sut.CLI();

            Assert.False(sut.I);
        }
    }
}
