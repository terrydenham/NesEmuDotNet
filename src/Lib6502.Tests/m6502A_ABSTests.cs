using NUnit.Framework;
using System.IO;
using System.Text;

namespace Lib6502.Tests
{
    public class m6502A_ABSTests
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
        public void CanReadValueAtAbsoluteAddress()
        {
            mem.Write(0x4400, 0x44);

            sut.A_ABS();

            Assert.AreEqual(0x44, sut.fetched);
        }
   }
}