using NUnit.Framework;
using System.IO;
using System.Text;

namespace Lib6502.Tests
{
    public class m6502AddressModeTests
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
        public void AbsoluteAddress_CanReadValue()
        {
            // write the absolute address into memory at the program counter
            mem.Write(sut.PC, new byte[] { 0x00, 0x44 });

            // write the desire expected value at the absolute address
            mem.Write(0x4400, 0x23);

            // perform the absolute address operation
            sut.A_ABS();

            // verify the value at the absolute address was fetched into the fetched "register"
            Assert.AreEqual(0x23, sut.fetched);
        }

        [Test]
        public void AbsoluteAddressWithXOffset_CanReadValue()
        {
            // write the instruction at the program counter
            mem.Write(sut.PC, Assembler.Assemble("ADC $4400,X"));

            // write the desire expected value at the absolute address
            mem.Write(0x4401, 0x23);

            // perform the absolute address operation
            sut.X = 0x01;

            // increment the program counter because we're not interested in the operation
            sut.PC++;

            // act
            sut.A_ABX();

            // verify the value at the absolute address was fetched into the fetched "register"
            Assert.AreEqual(0x23, sut.fetched);
        }

        [Test]
        public void AbsoluteAddressWithYOffset_CanReadValue()
        {
            // perform the absolute address operation
            sut.Y = 0x01;

            // write the desire expected value at the absolute address with Y offset
            mem.Write((ushort)(0x4400 + sut.Y), 0x23);

            // write the instruction at the program counter
            mem.Write(sut.PC, Assembler.Assemble("ADC $4400,Y"));

            // increment the program counter because we're not interested in the operation
            sut.PC++;

            // act
            sut.A_ABY();

            // verify the value at the absolute address was fetched into the fetched "register"
            Assert.AreEqual(0x23, sut.fetched);
        }

        [Test]
        public void Accumulator_CanReadValue()
        {
            // perform the absolute address operation
            sut.A = 0x23;

            // write the instruction at the program counter
            mem.Write(sut.PC, Assembler.Assemble("ASL A"));

            // increment the program counter because we're not interested in the operation
            sut.PC++;

            // act
            sut.A_ACC();

            // verify the value at the absolute address was fetched into the fetched "register"
            Assert.AreEqual(0x23, sut.fetched);
        }
        [Test]
        public void Immediate_CanReadValue()
        {
            mem.Write(sut.PC, 0x44);

            sut.A_IMM();

            Assert.AreEqual(0x44, sut.fetched);
        }

        [Test]
        public void Indirect_CanReadValue()
        {
            // write the absolute address at the indirect address above
            mem.Write(0x1000, new byte[] { 0x00, 0x44 });

            // write the desire expected value at the absolute address
            mem.Write(0x4400, 0x23);

            // write the absolute address into memory at the program counter
            mem.Write(sut.PC, Assembler.Assemble("JMP ($1000)"));

            // increment the program counter because we're not interested in the operation
            sut.PC++;

            // perform the absolute address operation
            sut.A_IND();

            // verify the value at the absolute address was fetched into the fetched "register"
            Assert.AreEqual(0x23, sut.fetched);
        }

        [Test]
        public void IndexedIndirect_CanReadValue()
        {
            // write the absolute address at the indirect address above
            mem.Write(0x24, new byte[] { 0x74, 0x20 });

            // write the desire expected value at the absolute address
            mem.Write(0x2074, 0x23);

            // write the absolute address into memory at the program counter
            mem.Write(sut.PC, Assembler.Assemble("LDA ($20,X)"));

            // increment the program counter because we're not interested in the operation
            sut.PC++;

            sut.X = 0x04;

            // perform the indexed indirect operation
            sut.A_IZX();

            // verify the value at the absolute address was fetched into the fetched "register"
            Assert.AreEqual(0x23, sut.fetched);
        }

        [Test]
        public void IndirectIndexed_CanReadValue()
        {
            // write the absolute address at the indirect address above
            mem.Write(0x86, new byte[] { 0x28, 0x40 });

            // write the desire expected value at the absolute address
            mem.Write(0x4038, 0x23);

            // write the absolute address into memory at the program counter
            mem.Write(sut.PC, Assembler.Assemble("LDA ($86),Y"));

            // increment the program counter because we're not interested in the operation
            sut.PC++;

            sut.Y = 0x10;

            // perform the indexed indirect operation
            sut.A_IZY();

            // verify the value at the absolute address was fetched into the fetched "register"
            Assert.AreEqual(0x23, sut.fetched);
        }

        [Test]
        public void Implied_CanReadValue()
        {
            byte expected = 0x23;

            // reset the cpu state
            sut.SetInitialState(CpuFlags.Empty);

            // implied function reads from the (A)ccumulator
            sut.A = expected;

            // perform the implied operation
            sut.A_IMP();

            Assert.AreEqual(expected, sut.fetched);
        }

        [Test, Ignore("not ready yet")]
        public void RelativeWithNegativeOffset_CanReadValue()
        {
            // set the starting program counter
            sut.PC = 0x209;

            // write the instruction into the program counter address
            mem.Write(sut.PC, Assembler.Assemble("BEQ $89"));

            // increment the program counter because we're not interested in the operation
            sut.PC++;

            // perform the absolute address operation
            sut.A_REL();

            // verify the value at the absolute address was fetched into the fetched "register"
            Assert.AreEqual(0x200, sut.addr_abs);
        }

        [Test]
        public void RelativeWithPositiveOffset_CanReadValue()
        {
            // set the starting program counter
            sut.PC = 0xFFF;

            // write the instruction into the program counter address
            mem.Write(sut.PC, Assembler.Assemble("BEQ $20"));

            // increment the program counter because we're not interested in the operation
            sut.PC++;

            // perform the absolute address operation
            sut.A_REL();

            // verify the value at the absolute address was fetched into the fetched "register"
            Assert.AreEqual(0x1020, sut.addr_abs);
        }

        [Test]
        public void ZeroPage_CanReadValue()
        {
            byte expected = 0x23;

            // set the starting program counter
            sut.PC = 0xFFF;

            // write the expected value in the zero page address
            mem.Write(0x0044, expected);

            // write the instruction into the program counter address
            mem.Write(sut.PC, Assembler.Assemble("STA $44"));

            // increment the program counter because we're not interested in the operation
            sut.PC++;

            // perform the zero page address operation
            sut.A_ZP0();

            // verify the value fetched is what we expected
            Assert.AreEqual(expected, sut.fetched);
        }

        [Test]
        public void ZeroPageWithOffsetX_CanReadValue()
        {
            byte expected = 0x23;

            // write the expected value at the zero page with x offset
            mem.Write(0x96, expected);

            // set the starting program counter;
            sut.PC = 0xFFF;

            // write the instruction into the program counter address
            mem.Write(sut.PC, Assembler.Assemble("LDA $86,X"));

            // increment the program counter because we're no interested in the operation
            sut.PC++;

            // set the offset value in the X register
            sut.X = 0x10;

            // perform the zero page with x offset address operation
            sut.A_ZPX();

            // verify the value fetched is what we expected
            Assert.AreEqual(expected, sut.fetched);
        }

        [Test]
        public void ZeroPageWithOffsetY_CanReadValue()
        {
            byte expected = 0x23;

            // write the expected value at the zero page with x offset
            mem.Write(0x96, expected);

            // set the starting program counter;
            sut.PC = 0xFFF;

            // write the instruction into the program counter address
            mem.Write(sut.PC, Assembler.Assemble("LDA $86,Y"));

            // increment the program counter because we're no interested in the operation
            sut.PC++;

            // set the offset value in the X register
            sut.Y = 0x10;

            // perform the zero page with x offset address operation
            sut.A_ZPY();

            // verify the value fetched is what we expected
            Assert.AreEqual(expected, sut.fetched);
        }
    }
}