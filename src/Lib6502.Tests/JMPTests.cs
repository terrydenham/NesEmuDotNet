using NUnit.Framework;

namespace Lib6502.Tests
{
    public class JMPTests
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
        public void JMP_WithFetchedAddress_ProgramCounterMatches()
        {

            sut.addr_abs = 0x4000;
            
            sut.JMP();

            Assert.AreEqual(0x4000, sut.PC);
        }

    }
}

