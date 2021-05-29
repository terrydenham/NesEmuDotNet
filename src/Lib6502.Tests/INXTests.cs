using NUnit.Framework;

namespace Lib6502.Tests
{
    public class INXTests
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
        public void INX_WithZeroInRegister_ResultsInOne()
        {
            sut.X = 0x00;

            sut.INX();

            Assert.AreEqual(0x01, sut.X);
        }

        [Test]
        public void INX_WithOneTwentySevenInRegister_ResultsInNagativeFlag()
        {
            sut.X = 127;

            sut.INX();

            Assert.AreEqual(true, sut.N);
        }

        [Test]
        public void INX_WithNegativeOneInRegister_ResultsInZeroFlag()
        {
            sut.X = 0xFF;

            sut.INX();

            Assert.AreEqual(true, sut.Z);
        }

    }
}

