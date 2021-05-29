using NUnit.Framework;

namespace Lib6502.Tests
{
    public class BRKTests
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
        public void BRK_ProgramCounter_IncreatedByTwo()
        {
            var expected = sut.PC + 2;

            sut.BRK();

            var actual = sut.PC;

            Assert.AreEqual(expected, actual, "Program counter was incorrect");
        }

        [Test]
        public void BRK_BreakFlagSet()
        {
            Assert.IsFalse(sut.B);

            sut.BRK();

            Assert.IsTrue(sut.B, "Break CPU flag was not set");

        }
    }
}