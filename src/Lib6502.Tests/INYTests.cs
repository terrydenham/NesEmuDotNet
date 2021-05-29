
using NUnit.Framework;

namespace Lib6502.Tests
{
    public class INYTests
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
        public void INY_WithZeroInRegister_ResultsInOne()
        {
            sut.Y = 0x00;

            sut.INY();

            Assert.AreEqual(0x01, sut.Y);
        }

        [Test]
        public void INY_WithOneTwentySevenInRegister_ResultsInNagativeFlag()
        {
            sut.Y = 127;

            sut.INY();

            Assert.AreEqual(true, sut.N);
        }

        [Test]
        public void INY_WithNegativeOneInRegister_ResultsInZeroFlag()
        {
            sut.Y = 0xFF;

            sut.INY();

            Assert.AreEqual(true, sut.Z);
        }


    }
}
