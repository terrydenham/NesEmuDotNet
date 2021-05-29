using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Lib6502.Tests
{
    [TestFixture]
    public class m6502Tests
    {
        protected m6502 sut;
        protected Memory memory;

        [OneTimeSetUp]
        public void Init()
        {
            memory = new Memory(32 * 1024); // 32k
            sut = new m6502(memory);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {

        }

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
            memory.Clear();
        }

        internal static void AssertFlags(m6502 sut, bool c, bool z, bool n = false, bool v = false, bool d = false, bool b = false, bool i = false)
        {
            Assert.AreEqual(b, sut.B, "Break flag was not correct");
            Assert.AreEqual(c, sut.C, "Carry flag was not correct");
            Assert.AreEqual(d, sut.D, "Decimal flag was not correct");
            Assert.AreEqual(i, sut.I, "Interrupt flag was not correct");
            Assert.AreEqual(n, sut.N, "Negative flag was not correct");
            //Assert.AreEqual(sut.U, "Unused flag was not correct");
            Assert.AreEqual(v, sut.V, "Overflow flag was not correct");
            Assert.AreEqual(z, sut.Z, "Zero flag was not correct");

        }

        internal static void AssertFlags2(m6502 sut, CpuFlags expectedFlags)
        {
            Assert.AreEqual((expectedFlags & CpuFlags.B) == CpuFlags.B, sut.B, "Break flag was not correct");
            Assert.AreEqual((expectedFlags & CpuFlags.C) == CpuFlags.C, sut.C, "Carry flag was not correct");
            Assert.AreEqual((expectedFlags & CpuFlags.D) == CpuFlags.D, sut.D, "Decimal flag was not correct");
            Assert.AreEqual((expectedFlags & CpuFlags.I) == CpuFlags.I, sut.I, "Interrupt flag was not correct");
            Assert.AreEqual((expectedFlags & CpuFlags.N) == CpuFlags.N, sut.N, "Negative flag was not correct");
            Assert.AreEqual((expectedFlags & CpuFlags.U) == CpuFlags.U, sut.U, "Unused flag was not correct");
            Assert.AreEqual((expectedFlags & CpuFlags.V) == CpuFlags.V, sut.V, "Overflow flag was not correct");
            Assert.AreEqual((expectedFlags & CpuFlags.Z) == CpuFlags.Z, sut.Z, "Zero flag was not correct");
        }

        /*
        #region ADC
        [TestCase(CpuFlags.Empty, 0x01, "ADC #$44", CpuFlags.Empty, Description = "IMM add positive number", ExpectedResult = 0x45)]
        [TestCase(CpuFlags.Empty, 0x01, "ADC #$FF", CpuFlags.C | CpuFlags.V, Description = "IMM add positive number with overflow", ExpectedResult = 0x00)]
        [TestCase(CpuFlags.Empty, 0x01, "ADC #00", CpuFlags.Empty, Description = "ZPG add positive number", ExpectedResult = 0x45 )]
        public byte PerformADC_WithPositiveNumbers(CpuFlags initialState, byte initialValue, string instruction, CpuFlags finalState)
        {
            var x = new Tuple<ushort, byte>[] { new Tuple<ushort, byte>(0x00, 0x01) };

            var byteCode = Assembler.Assemble(new []{ instruction }); ;


            memory.Write(sut.PC, byteCode);


            sut.SetInitialState(initialState);
            sut.A = initialValue;
            
            sut.Clock();

            Assert.AreEqual(sut.Cycles, sut.Instructions[byteCode[0]].Cycles - 1 );
            AssertFlags2(sut, finalState);
            return sut.A;
        }

        [Test]
        public void PerformADCInIMM_WithPositiveNumbers_NoOverflow()
        {
            sut.A = 0x01;

            var byteCode = Assembler.Assemble(new[] { "ADC #$44" });
            Assert.AreEqual(byteCode, new byte[] { 0x69, 0x44 });

            memory.Write(sut.PC, byteCode);

            sut.Clock();

            Assert.AreEqual(sut.Cycles, sut.Instructions[byteCode[0]].Cycles - 1);
            Assert.AreEqual(0x45, sut.A);
            AssertFlags(sut, false, false);
        }

        [Test]
        public void PerformADCInIMM_WithPositiveNumbersMoreThan255_Overflow()
        {
            sut.A = 0xFF;

            var byteCode = new byte[] { 0x69, 0x01 };

            memory.Write(sut.PC, byteCode);

            sut.Clock();

            Assert.AreEqual(sut.Cycles, sut.Instructions[byteCode[0]].Cycles - 1);
            Assert.AreEqual(0x00, sut.A);
            AssertFlags(sut, true, false, false, true);
        }

        [Test, Ignore("Not ready")]
        public void PerformADCInIMMPositiveWithOverflow()
        {
            var memory = new Memory(32 * 1024);

            var byteCode = new byte[] { 0x69, 0x44 };
            var sut = new m6502(memory);
            sut.A = 0xFF;

            Assert.IsFalse(sut.B);

            memory.Write(sut.PC, byteCode);

            sut.Clock();
            Assert.AreEqual(sut.Cycles, sut.Instructions[byteCode[0]].Cycles - 1);
            Assert.AreEqual(0x43, sut.A);
            AssertFlags(sut, false, false, false, false, false, true, false);
            //Assert.False(sut.B, "Break flag was not correct");
            //Assert.False(sut.C, "Carry flag was not correct");
            //Assert.False(sut.D, "Decimal flag was not correct");
            //Assert.False(sut.I, "Interrupt flag was not correct");
            //Assert.False(sut.N, "Negative flag was not correct");
            //Assert.False(sut.U, "Unused flag was not correct");
            //Assert.True(sut.V, "Overflow flag was not correct");
            //Assert.False(sut.Z, "Zero flag was not correct");
        }
        #endregion

        #region AND
        [Test]
        public void PerformANDInABS()
        {
            string[] codeLines = new[] { "AND $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x2D, 0x00, 0x44 }, machineCode);
            //byte[] machineCode = new byte[] { 0x2D, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("AND $4400", codeLines[0]);
        }

        [Test]
        public void PerformANDInABX()
        {
            string[] codeLines = new[] { "AND $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x3D, 0x00, 0x44 }, machineCode);
            //byte[] machineCode = new byte[] { 0x3D, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("AND $4400,X", codeLines[0]);
        }

        [Test]
        public void PerformANDInABY()
        {
            string[] codeLines = new[] { "AND $4400,Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x39, 0x00, 0x44 }, machineCode);
            //byte[] machineCode = new byte[] { 0x39, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("AND $4400,Y", codeLines[0]);
        }

        [Test]
        public void PerformANDInIMMWithZeroInAccumulatorAndZeroValueResultsInZeroValue()
        {
            var memory = new Memory(32 * 1024);

            var byteCode = new byte[] { 0x69, 0x00 };
            var sut = new m6502(memory);
            sut.A = 0x00;

            Assert.IsFalse(sut.B);

            memory.Write(sut.PC, byteCode);

            sut.Clock();
            Assert.AreEqual(sut.Cycles, sut.Instructions[byteCode[0]].Cycles - 1);
            Assert.AreEqual(0x00, sut.A);
            AssertFlags(sut, false, false, false, false, false, false, false);
        }

        [Test]
        public void PerformANDInIMMWithZeroInAccumulatorAndNonZeroValueResultsInZeroValue()
        {
            var memory = new Memory(32 * 1024);

            var byteCode = new byte[] { 0x69, 0x44 };
            var sut = new m6502(memory);
            sut.A = 0x00;

            Assert.IsFalse(sut.B);

            memory.Write(sut.PC, byteCode);

            sut.Clock();
            Assert.AreEqual(sut.Cycles, sut.Instructions[byteCode[0]].Cycles - 1);
            Assert.AreEqual(0x00, sut.A);
            AssertFlags(sut, false, false, false, false, false, false, false);
        }

        [Test]
        public void PerformANDInIMMWithNonZeroInAccumulatorAndNonZeroValueResultsInNonZeroValue()
        {
            var memory = new Memory(32 * 1024);

            var byteCode = new byte[] { 0x69, 0x44 };
            var sut = new m6502(memory);
            sut.A = 0x01;

            Assert.IsFalse(sut.B);

            memory.Write(sut.PC, byteCode);

            sut.Clock();
            Assert.AreEqual(sut.Cycles, sut.Instructions[byteCode[0]].Cycles - 1);
            Assert.AreEqual(0x01, sut.A);
            AssertFlags(sut, false, false, false, false, false, false, false);
        }

        [Test]
        public void PerformANDInIMMWithNonZeroInAccumulatorAndZeroValueResultsInNonZeroValue()
        {
            var memory = new Memory(32 * 1024);

            var byteCode = new byte[] { 0x69, 0x00 };
            var sut = new m6502(memory);
            sut.A = 0x01;

            Assert.IsFalse(sut.B);

            memory.Write(sut.PC, byteCode);

            sut.Clock();
            Assert.AreEqual(sut.Cycles, sut.Instructions[byteCode[0]].Cycles - 1);
            Assert.AreEqual(0x01, sut.A);
            AssertFlags(sut, false, false, false, false, false, false, false);
        }

        [Test]
        public void PerformANDInIZX()
        {
            string[] codeLines = new[] { "AND ($44,X) ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x21, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x21, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("AND ($44,X)", codeLines[0]);
        }
        [Test]
        public void PerformANDInIZY()
        {
            string[] codeLines = new[] { "AND ($44),Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x31, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x31, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("AND ($44),Y", codeLines[0]);
        }
        [Test]
        public void PerformANDInZP0()
        {
            string[] codeLines = new[] { "AND $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x25, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x25, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("AND $44", codeLines[0]);
        }

        [Test]
        public void PerformANDInZPX()
        {
            string[] codeLines = new[] { "AND $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x35, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x35, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("AND $44,X", codeLines[0]);
        }

        #endregion
        */
    }
}