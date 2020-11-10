using NUnit.Framework;
using System.Security.Cryptography;

namespace Lib6502.Tests
{
    public class AssemblerAssembleTests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region Assemble
        #region ADC
        [Test]
        public void AssembleADCWithABS()
        {
            string[] codeLines = new[] { "ADC $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x6D, 0x00, 0x44 }, machineCode);
        }

        [Test]
        public void AssembleADCWithABX()
        {
            string[] codeLines = new[] { "ADC $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x7D, 0x00, 0x44 }, machineCode);
            //byte[] machineCode = new byte[] { 0x7D, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Assemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ADC $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleADCWithABY()
        {
            string[] codeLines = new[] { "ADC $4400,Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x79, 0x00, 0x44 }, machineCode);
            //byte[] machineCode = new byte[] { 0x79, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Assemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ADC $4400,Y", codeLines[0]);
        }

        [Test]
        public void AssembleADCWithIMM()
        {
            string[] codeLines = new[] { "ADC #$44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x69, 0x44 }, machineCode);
        }

        [Test]
        public void AssembleADCWithIZX()
        {
            string[] codeLines = new[] { "ADC ($44,X) ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x61, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x61, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Assemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ADC ($44,X)", codeLines[0]);
        }

        [Test]
        public void AssembleADCWithIZY()
        {
            string[] codeLines = new[] { "ADC ($44),Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x71, 0x44 }, machineCode);
            //byte[] machineCode = new byte[] { 0x71, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Assemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ADC ($44),Y", codeLines[0]);
        }

        [Test]
        public void AssembleADCWithZP0()
        {
            string[] codeLines = new[] { "ADC $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x65, 0x44 }, machineCode);
            //byte[] machineCode = new byte[] { 0x65, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Assemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ADC $44", codeLines[0]);
        }

        [Test]
        public void AssembleADCWithZPX()
        {
            string[] codeLines = new[] { "ADC $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x75, 0x44 }, machineCode);
            //byte[] machineCode = new byte[] { 0x75, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Assemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ADC $44,X", codeLines[0]);
        }
        #endregion

        #region AND
        [Test]
        public void AssembleANDWithABS()
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
        public void AssembleANDWithABX()
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
        public void AssembleANDWithABY()
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
        public void AssembleANDWithIMM()
        {
            string[] codeLines = new[] { "AND #$44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x29, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x29, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("AND #$44", codeLines[0]);
        }

        [Test]
        public void AssembleANDWithIZX()
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
        public void AssembleANDWithIZY()
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
        public void AssembleANDWithZP0()
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
        public void AssembleANDWithZPX()
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

        #region ASL
        [Test]
        public void AssembleASLWithABS()
        {
            string[] codeLines = new[] { "ASL $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x0E, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x0E, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ASL $4400", codeLines[0]);
        }

        [Test]
        public void AssembleASLWithABX()
        {
            string[] codeLines = new[] { "ASL $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x1E, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x1E, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ASL $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleASLWithACC()
        {
            string[] codeLines = new[] { "ASL A ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x0A }, machineCode);

            //byte[] machineCode = new byte[] { 0x0A };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ASL A", codeLines[0]);
        }

        [Test]
        public void AssembleASLWithZP0()
        {
            string[] codeLines = new[] { "ASL $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x06, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x06, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ASL $44", codeLines[0]);
        }

        [Test]
        public void AssembleASLWithZPX()
        {
            string[] codeLines = new[] { "ASL $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x16, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x16, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ASL $44,X", codeLines[0]);
        }

        #endregion

        #region BIT
        [Test]
        public void AssembleBITWithABS()
        {
            string[] codeLines = new[] { "BIT $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x2C, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x2C, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("BIT $4400", codeLines[0]);
        }
        [Test]
        public void AssembleBITWithZP0()
        {
            string[] codeLines = new[] { "BIT $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x24, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x24, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("BIT $44", codeLines[0]);
        }
        #endregion

        #region Branch
        [Test]
        public void AssembleBranchBCC()
        {
            string[] codeLines = new[] { "BCC $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x90, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x90, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("BCC $44", codeLines[0]);
        }

        [Test]
        public void AssembleBranchBCS()
        {
            string[] codeLines = new[] { "BCS $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xB0, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xB0, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("BCS $44", codeLines[0]);
        }

        [Test]
        public void AssembleBranchBEQ()
        {
            string[] codeLines = new[] { "BEQ $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xF0, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xF0, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("BEQ $44", codeLines[0]);
        }

        [Test]
        public void AssembleBranchBMI()
        {
            string[] codeLines = new[] { "BMI $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x30, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x30, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("BMI $44", codeLines[0]);
        }

        [Test]
        public void AssembleBranchBNE()
        {
            string[] codeLines = new[] { "BNE $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xD0, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xD0, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("BNE $44", codeLines[0]);
        }
        [Test]
        public void AssembleBranchBPL()
        {
            string[] codeLines = new[] { "BPL $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x10, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x10, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("BPL $44", codeLines[0]);
        }

        [Test]
        public void AssembleBranchBVC()
        {
            string[] codeLines = new[] { "BVC $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x50, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x50, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("BVC $44", codeLines[0]);
        }

        [Test]
        public void AssembleBranchBVS()
        {
            string[] codeLines = new[] { "BVS $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x70, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x70, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("BVS $44", codeLines[0]);
        }
        #endregion

        #region BRK
        [Test]
        public void AssembleBRK()
        {
            string[] codeLines = new[] { "BRK ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x00 }, machineCode);

            //byte[] machineCode = new byte[] { 0x00 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("BRK", codeLines[0]);
        }
        #endregion

        #region CMP
        [Test]
        public void AssembleCMPWithABS()
        {
            string[] codeLines = new[] { "CMP $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xCD, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xCD, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CMP $4400", codeLines[0]);
        }

        [Test]
        public void AssembleCMPWithABX()
        {
            string[] codeLines = new[] { "CMP $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xDD, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xDD, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CMP $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleCMPWithABY()
        {
            string[] codeLines = new[] { "CMP $4400,Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xD9, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xD9, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CMP $4400,Y", codeLines[0]);
        }

        [Test]
        public void AssembleCMPWithIMM()
        {
            string[] codeLines = new[] { "CMP #$44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xC9, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xC9, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CMP #$44", codeLines[0]);
        }

        [Test]
        public void AssembleCMPWithIZX()
        {
            string[] codeLines = new[] { "CMP ($44,X) ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xC1, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xC1, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CMP ($44,X)", codeLines[0]);
        }

        [Test]
        public void AssembleCMPWithIZY()
        {
            string[] codeLines = new[] { "CMP ($44),Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xD1, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xD1, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CMP ($44),Y", codeLines[0]);
        }

        [Test]
        public void AssembleCMPWithZP0()
        {
            string[] codeLines = new[] { "CMP $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xC5, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xC5, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CMP $44", codeLines[0]);
        }

        [Test]
        public void AssembleCMPWithZPX()
        {
            string[] codeLines = new[] { "CMP $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xD5, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xD5, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CMP $44,X", codeLines[0]);
        }
        #endregion

        #region CPX
        [Test]
        public void AssembleCPXWithABS()
        {
            string[] codeLines = new[] { "CPX $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xEC, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xEC, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CPX $4400", codeLines[0]);
        }
        [Test]
        public void AssembleCPXWithIMM()
        {
            string[] codeLines = new[] { "CPX #$44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xE0, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xE0, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CPX #$44", codeLines[0]);
        }

        [Test]
        public void AssembleCPXWithZP0()
        {
            string[] codeLines = new[] { "CPX $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xE4, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xE4, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CPX $44", codeLines[0]);
        }
        #endregion

        #region CPY
        [Test]
        public void AssembleCPYWithABS()
        {
            string[] codeLines = new[] { "CPY $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xCC, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xCC, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CPY $4400", codeLines[0]);
        }

        [Test]
        public void AssembleCPYWithIMM()
        {
            string[] codeLines = new[] { "CPY #$44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xC0, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xC0, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CPY #$44", codeLines[0]);
        }

        [Test]
        public void AssembleCPYWithZP0()
        {
            string[] codeLines = new[] { "CPY $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xC4, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xC4, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CPY $44", codeLines[0]);
        }
        #endregion

        #region DEC
        [Test]
        public void AssembleDECWithABS()
        {
            string[] codeLines = new[] { "DEC $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xCE, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xCE, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("DEC $4400", codeLines[0]);
        }

        [Test]
        public void AssembleDECWithABX()
        {
            string[] codeLines = new[] { "DEC $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xDE, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xDE, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("DEC $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleDECWithZP0()
        {
            string[] codeLines = new[] { "DEC $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xC6, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xC6, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("DEC $44", codeLines[0]);
        }

        [Test]
        public void AssembleDECWithZPX()
        {
            string[] codeLines = new[] { "DEC $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xD6, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xD6, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("DEC $44,X", codeLines[0]);
        }
        #endregion

        #region EOR
        [Test]
        public void AssembleEORWithABS()
        {
            string[] codeLines = new[] { "EOR $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x4D, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x4D, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("EOR $4400", codeLines[0]);
        }

        [Test]
        public void AssembleEORWithABX()
        {
            string[] codeLines = new[] { "EOR $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x5D, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x5D, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("EOR $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleEORWithABY()
        {
            string[] codeLines = new[] { "EOR $4400,Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x59, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x59, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("EOR $4400,Y", codeLines[0]);
        }

        [Test]
        public void AssembleEORWithIMM()
        {
            string[] codeLines = new[] { "EOR #$44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x49, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x49, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("EOR #$44", codeLines[0]);
        }

        [Test]
        public void AssembleEORWithIZX()
        {
            string[] codeLines = new[] { "EOR ($44,X) ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x41, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x41, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("EOR ($44,X)", codeLines[0]);
        }

        [Test]
        public void AssembleEORWithIZY()
        {
            string[] codeLines = new[] { "EOR ($44),Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x51, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x51, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("EOR ($44),Y", codeLines[0]);
        }

        [Test]
        public void AssembleEORWithZP0()
        {
            string[] codeLines = new[] { "EOR $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x45, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x45, 0x44 };
            
            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("EOR $44", codeLines[0]);
        }

        [Test]
        public void AssembleEORWithZPX()
        {
            string[] codeLines = new[] { "EOR $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x55, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x55, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("EOR $44,X", codeLines[0]);
        }
        #endregion

        #region Flag
        [Test]
        public void AssembleFlagCLC()
        {
            string[] codeLines = new[] { "CLC ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x18 }, machineCode);

            //byte[] machineCode = new byte[] { 0x18 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CLC", codeLines[0]);
        }

        [Test]
        public void AssembleFlagCLD()
        {
            string[] codeLines = new[] { "CLD ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xD8 }, machineCode);

            //byte[] machineCode = new byte[] { 0xD8 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CLD", codeLines[0]);
        }

        [Test]
        public void AssembleFlagCLI()
        {
            string[] codeLines = new[] { "CLI ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x58 }, machineCode);

            //byte[] machineCode = new byte[] { 0x58 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CLI", codeLines[0]);
        }

        [Test]
        public void AssembleFlagCLV()
        {
            string[] codeLines = new[] { "CLV ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xB8 }, machineCode);

            //byte[] machineCode = new byte[] { 0xB8 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("CLV", codeLines[0]);
        }

        [Test]
        public void AssembleFlagSEC()
        {
            string[] codeLines = new[] { "SEC ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x38 }, machineCode);

            //byte[] machineCode = new byte[] { 0x38 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("SEC", codeLines[0]);
        }

        [Test]
        public void AssembleFlagSED()
        {
            string[] codeLines = new[] { "SED ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xF8 }, machineCode);

            //byte[] machineCode = new byte[] { 0xF8 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("SED", codeLines[0]);
        }

        [Test]
        public void AssembleFlagSEI()
        {
            string[] codeLines = new[] { "SEI ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x78 }, machineCode);

            //byte[] machineCode = new byte[] { 0x78 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("SEI", codeLines[0]);
        }
        #endregion

        #region INC
        [Test]
        public void AssembleINCWithABS()
        {
            string[] codeLines = new[] { "INC $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xEE, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xEE, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("INC $4400", codeLines[0]);
        }

        [Test]
        public void AssembleINCWithABX()
        {
            string[] codeLines = new[] { "INC $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xFE, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xFE, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("INC $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleINCWithZP0()
        {
            string[] codeLines = new[] { "INC $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xE6, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xE6, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("INC $44", codeLines[0]);
        }

        [Test]
        public void AssembleINCWithZPX()
        {
            string[] codeLines = new[] { "INC $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xF6, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xF6, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("INC $44,X", codeLines[0]);
        }
        #endregion

        #region JMP
        [Test]
        public void AssembleJMPWithABS()
        {
            string[] codeLines = new[] { "JMP $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x4C, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x4C, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("JMP $4400", codeLines[0]);
        }

        [Test]
        public void AssembleJMPWithIND()
        {
            string[] codeLines = new[] { "JMP ($4400) ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x6C, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x6C, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("JMP ($4400)", codeLines[0]);
        }
        #endregion

        #region JSR
        [Test]
        public void AssembleJSRWithABS()
        {
            string[] codeLines = new[] { "JSR $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x20, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x20, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("JSR $4400", codeLines[0]);
        }
        #endregion

        #region LDA
        [Test]
        public void AssembleLDAWithABS()
        {
            string[] codeLines = new[] { "LDA $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xAD, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xAD, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDA $4400", codeLines[0]);
        }

        [Test]
        public void AssembleLDAWithABX()
        {
            string[] codeLines = new[] { "LDA $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xBD, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xBD, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDA $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleLDAWithABY()
        {
            string[] codeLines = new[] { "LDA $4400,Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xB9, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xB9, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDA $4400,Y", codeLines[0]);
        }

        [Test]
        public void AssembleLDAWithIMM()
        {
            string[] codeLines = new[] { "LDA #$44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xA9, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xA9, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDA #$44", codeLines[0]);
        }

        [Test]
        public void AssembleLDAWithIZX()
        {
            string[] codeLines = new[] { "LDA ($44,X) ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xA1, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xA1, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDA ($44,X)", codeLines[0]);
        }

        [Test]
        public void AssembleLDAWithIZY()
        {
            string[] codeLines = new[] { "LDA ($44),Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xB1, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xB1, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDA ($44),Y", codeLines[0]);
        }

        [Test]
        public void AssembleLDAWithZP0()
        {
            string[] codeLines = new[] { "LDA $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xA5, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xA5, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDA $44", codeLines[0]);
        }

        [Test]
        public void AssembleLDAWithZPX()
        {
            string[] codeLines = new[] { "LDA $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xB5, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xB5, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDA $44,X", codeLines[0]);
        }
        #endregion

        #region LDX
        [Test]
        public void AssembleLDXWithABS()
        {
            string[] codeLines = new[] { "LDX $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xAE, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xAE, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDX $4400", codeLines[0]);
        }

        [Test]
        public void AssembleLDXWithABY()
        {
            string[] codeLines = new[] { "LDX $4400,Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xBE, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xBE, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDX $4400,Y", codeLines[0]);
        }

        [Test]
        public void AssembleLDXWithIMM()
        {
            string[] codeLines = new[] { "LDX #$44; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xA2, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xA2, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDX #$44", codeLines[0]);
        }

        [Test]
        public void AssembleLDXWithZP0()
        {
            string[] codeLines = new[] { "LDX $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xA6, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xA6, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDX $44", codeLines[0]);
        }

        [Test]
        public void AssembleLDXWithZPY()
        {
            string[] codeLines = new[] { "LDX $44,Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xB6, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xB6, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDX $44,Y", codeLines[0]);
        }
        #endregion

        #region LDY
        [Test]
        public void AssembleLDYWithABS()
        {
            string[] codeLines = new[] { "LDY $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xAC, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xAC, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDY $4400", codeLines[0]);
        }

        [Test]
        public void AssembleLDYWithABX()
        {
            string[] codeLines = new[] { "LDY $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xBC, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xBC, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDY $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleLDYWithIMM()
        {
            string[] codeLines = new[] { "LDY #$44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xA0, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xA0, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDY #$44", codeLines[0]);
        }

        [Test]
        public void AssembleLDYWithZP0()
        {
            string[] codeLines = new[] { "LDY $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xA4, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xA4, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDY $44", codeLines[0]);
        }

        [Test]
        public void AssembleLDYWithZPX()
        {
            string[] codeLines = new[] { "LDY $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xB4, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xB4, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LDY $44,X", codeLines[0]);
        }
        #endregion

        #region LSR
        [Test]
        public void AssembleLSRWithABS()
        {
            string[] codeLines = new[] { "LSR $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x4E, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x4E, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LSR $4400", codeLines[0]);
        }

        [Test]
        public void AssembleLSRWithABX()
        {
            string[] codeLines = new[] { "LSR $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x5E, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x5E, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LSR $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleLSRWithACC()
        {
            string[] codeLines = new[] { "LSR A ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x4A }, machineCode);

            //byte[] machineCode = new byte[] { 0x4A };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LSR A", codeLines[0]);
        }

        [Test]
        public void AssembleLSRWithZP0()
        {
            string[] codeLines = new[] { "LSR $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x46, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x46, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LSR $44", codeLines[0]);
        }

        [Test]
        public void AssembleLSRWithZPX()
        {
            string[] codeLines = new[] { "LSR $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x56, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x56, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("LSR $44,X", codeLines[0]);
        }
        #endregion

        #region NOP
        [Test]
        public void AssembleNOP()
        {
            string[] codeLines = new[] { "NOP ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xEA }, machineCode);

            //byte[] machineCode = new byte[] { 0xEA };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("NOP", codeLines[0]);
        }

        [Test]
        public void AssembleNOPofTwo()
        {
            string[] codeLines = new[] { "NOP ; comment", "NOP" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(2, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xEA, 0xEA }, machineCode);

            //byte[] machineCode = new byte[] { 0xEA, 0xEA };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(2, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("NOP", codeLines[0]);
            //Assert.AreEqual("NOP", codeLines[1]);
        }

        #endregion

        #region ORA
        [Test]
        public void AssembleORAWithABS()
        {
            string[] codeLines = new[] { "ORA $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x0D, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x0D, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ORA $4400", codeLines[0]);
        }

        [Test]
        public void AssembleORAWithABX()
        {
            string[] codeLines = new[] { "ORA $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x1D, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x1D, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ORA $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleORAWithABY()
        {
            string[] codeLines = new[] { "ORA $4400,Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x19, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x19, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ORA $4400,Y", codeLines[0]);
        }

        [Test]
        public void AssembleORAWithIMM()
        {
            string[] codeLines = new[] { "ORA #$44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x09, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x09, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ORA #$44", codeLines[0]);
        }

        [Test]
        public void AssembleORAWithIZX()
        {
            string[] codeLines = new[] { "ORA ($44,X) ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x01, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x01, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ORA ($44,X)", codeLines[0]);
        }

        [Test]
        public void AssembleORAWithIZY()
        {
            string[] codeLines = new[] { "ORA ($44),Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x11, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x11, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ORA ($44),Y", codeLines[0]);
        }

        [Test]
        public void AssembleORAWithZP0()
        {
            string[] codeLines = new[] { "ORA $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x05, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x05, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ORA $44", codeLines[0]);
        }

        [Test]
        public void AssembleORAWithZPX()
        {
            string[] codeLines = new[] { "ORA $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x15, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x15, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ORA $44,X", codeLines[0]);
        }
        #endregion

        #region Register
        [Test]
        public void AssembleRegisterDEX()
        {
            string[] codeLines = new[] { "DEX ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xCA }, machineCode);

            //byte[] machineCode = new byte[] { 0xCA };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("DEX", codeLines[0]);
        }

        [Test]
        public void AssembleRegisterDEY()
        {
            string[] codeLines = new[] { "DEY ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x88 }, machineCode);

            //byte[] machineCode = new byte[] { 0x88 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("DEY", codeLines[0]);
        }

        [Test]
        public void AssembleRegisterINX()
        {
            string[] codeLines = new[] { "INX ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xE8 }, machineCode);

            //byte[] machineCode = new byte[] { 0xE8 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("INX", codeLines[0]);
        }

        [Test]
        public void AssembleRegisterINY()
        {
            string[] codeLines = new[] { "INY ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xC8 }, machineCode);

            //byte[] machineCode = new byte[] { 0xC8 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("INY", codeLines[0]);
        }

        [Test]
        public void AssembleRegisterTAX()
        {
            string[] codeLines = new[] { "TAX ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xAA }, machineCode);

            //byte[] machineCode = new byte[] { 0xAA };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("TAX", codeLines[0]);
        }

        [Test]
        public void AssembleRegisterTAY()
        {
            string[] codeLines = new[] { "TAY ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xA8 }, machineCode);

            //byte[] machineCode = new byte[] { 0xA8 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("TAY", codeLines[0]);
        }

        [Test]
        public void AssembleRegisterTXA()
        {
            string[] codeLines = new[] { "TXA ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x8A }, machineCode);

            //byte[] machineCode = new byte[] { 0x8A };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("TXA", codeLines[0]);
        }

        [Test]
        public void AssembleRegisterTYA()
        {
            string[] codeLines = new[] { "TYA ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x98 }, machineCode);

            //byte[] machineCode = new byte[] { 0x98 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("TYA", codeLines[0]);
        }
        #endregion

        #region ROL
        [Test]
        public void AssembleROLWithABS()
        {
            string[] codeLines = new[] { "ROL $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x2E, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x2E, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ROL $4400", codeLines[0]);
        }

        [Test]
        public void AssembleROLWithABX()
        {
            string[] codeLines = new[] { "ROL $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x3E, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x3E, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ROL $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleROLWithACC()
        {
            string[] codeLines = new[] { "ROL A ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x2A }, machineCode);

            //byte[] machineCode = new byte[] { 0x2A };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ROL A", codeLines[0]);
        }

        [Test]
        public void AssembleROLWithZP0()
        {
            string[] codeLines = new[] { "ROL $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x26, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x26, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ROL $44", codeLines[0]);
        }

        [Test]
        public void AssembleROLWithZPX()
        {
            string[] codeLines = new[] { "ROL $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x36, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x36, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ROL $44,X", codeLines[0]);
        }
        #endregion

        #region ROR
        [Test]
        public void AssembleRORWithABS()
        {
            string[] codeLines = new[] { "ROR $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x6E, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x6E, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ROR $4400", codeLines[0]);
        }

        [Test]
        public void AssembleRORWithABX()
        {
            string[] codeLines = new[] { "ROR $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x7E, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x7E, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ROR $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleRORWithACC()
        {
            string[] codeLines = new[] { "ROR A ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x6A }, machineCode);

            //byte[] machineCode = new byte[] { 0x6A };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ROR A", codeLines[0]);
        }

        [Test]
        public void AssembleRORWithZP0()
        {
            string[] codeLines = new[] { "ROR $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x66, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x66, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ROR $44", codeLines[0]);
        }

        [Test]
        public void AssembleRORWithZPX()
        {
            string[] codeLines = new[] { "ROR $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x76, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x76, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("ROR $44,X", codeLines[0]);
        }
        #endregion

        #region RTI
        [Test]
        public void AssembleRTI()
        {
            string[] codeLines = new[] { "RTI ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x40 }, machineCode);

            //byte[] machineCode = new byte[] { 0x40 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("RTI", codeLines[0]);
        }
        #endregion

        #region RTS
        [Test]
        public void AssembleRTS()
        {
            string[] codeLines = new[] { "RTS ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x60 }, machineCode);

            //byte[] machineCode = new byte[] { 0x60 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("RTS", codeLines[0]);
        }
        #endregion

        #region SBC
        [Test]
        public void AssembleSBCWithABS()
        {
            string[] codeLines = new[] { "SBC $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xED, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xED, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("SBC $4400", codeLines[0]);
        }

        [Test]
        public void AssembleSBCWithABX()
        {
            string[] codeLines = new[] { "SBC $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xFD, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xFD, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("SBC $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleSBCWithABY()
        {
            string[] codeLines = new[] { "SBC $4400,Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xF9, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xF9, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("SBC $4400,Y", codeLines[0]);
        }

        [Test]
        public void AssembleSBCWithIMM()
        {
            string[] codeLines = new[] { "SBC #$44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xE9, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xE9, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("SBC #$44", codeLines[0]);
        }

        [Test]
        public void AssembleSBCWithIZX()
        {
            string[] codeLines = new[] { "SBC ($44,X) ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xE1, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xE1, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("SBC ($44,X)", codeLines[0]);
        }

        [Test]
        public void AssembleSBCWithIZY()
        {
            string[] codeLines = new[] { "SBC ($44),Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xF1, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xF1, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("SBC ($44),Y", codeLines[0]);
        }

        [Test]
        public void AssembleSBCWithZP0()
        {
            string[] codeLines = new[] { "SBC $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xE5, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xE5, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("SBC $44", codeLines[0]);
        }

        [Test]
        public void AssembleSBCWithZPX()
        {
            string[] codeLines = new[] { "SBC $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xF5, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0xF5, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("SBC $44,X", codeLines[0]);
        }
        #endregion

        #region STA
        [Test]
        public void AssembleSTAWithABS()
        {
            string[] codeLines = new[] { "STA $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x8D, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x8D, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STA $4400", codeLines[0]);
        }

        [Test]
        public void AssembleSTAWithABX()
        {
            string[] codeLines = new[] { "STA $4400,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x9D, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x9D, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STA $4400,X", codeLines[0]);
        }

        [Test]
        public void AssembleSTAWithABY()
        {
            string[] codeLines = new[] { "STA $4400,Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x99, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x99, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STA $4400,Y", codeLines[0]);
        }

        //[Test, Ignore("not working")]
        //public void AssembleSTAWithIMM()
        //{
        //    byte[] machineCode = new byte[] { 0xA9, 0x44 };

        //    string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

        //    Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
        //    Assert.AreEqual("STA #$44", codeLines[0]);
        //}

        [Test]
        public void AssembleSTAWithIZX()
        {
            string[] codeLines = new[] { "STA ($44,X) ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x81, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x81, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STA ($44,X)", codeLines[0]);
        }

        [Test]
        public void AssembleSTAWithIZY()
        {
            string[] codeLines = new[] { "STA ($44),Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x91, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x91, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STA ($44),Y", codeLines[0]);
        }

        [Test]
        public void AssembleSTAWithZP0()
        {
            string[] codeLines = new[] { "STA $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x85, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x85, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STA $44", codeLines[0]);
        }

        [Test]
        public void AssembleSTAWithZPX()
        {
            string[] codeLines = new[] { "STA $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x95, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x95, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STA $44,X", codeLines[0]);
        }
        #endregion

        #region STX
        [Test]
        public void AssembleSTXWithABS()
        {
            string[] codeLines = new[] { "STX $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x8E, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x8E, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STX $4400", codeLines[0]);
        }

        [Test]
        public void AssembleSTXWithZP0()
        {
            string[] codeLines = new[] { "STX $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x86, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x86, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STX $44", codeLines[0]);
        }

        [Test]
        public void AssembleSTXWithZPY()
        {
            string[] codeLines = new[] { "STX $44,Y ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x96, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x96, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STX $44,Y", codeLines[0]);
        }
        #endregion

        #region STY
        [Test]
        public void AssembleSTYWithABS()
        {
            string[] codeLines = new[] { "STY $4400 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x8C, 0x00, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x8C, 0x00, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STY $4400", codeLines[0]);
        }

        [Test]
        public void AssembleSTYWithZP0()
        {
            string[] codeLines = new[] { "STY $44 ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x84, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x84, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STY $44", codeLines[0]);
        }

        [Test]
        public void AssembleSTYWithZPX()
        {
            string[] codeLines = new[] { "STY $44,X ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x94, 0x44 }, machineCode);

            //byte[] machineCode = new byte[] { 0x94, 0x44 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("STY $44,X", codeLines[0]);
        }
        #endregion

        #region Stack
        [Test]
        public void AssembleStackPHA()
        {
            string[] codeLines = new[] { "PHA ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x48 }, machineCode);

            //byte[] machineCode = new byte[] { 0x48 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("PHA", codeLines[0]);
        }

        [Test]
        public void AssembleStackPHP()
        {
            string[] codeLines = new[] { "PHP ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x08 }, machineCode);

            //byte[] machineCode = new byte[] { 0x08 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("PHP", codeLines[0]);
        }

        [Test]
        public void AssembleStackPLA()
        {
            string[] codeLines = new[] { "PLA ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x68 }, machineCode);

            //byte[] machineCode = new byte[] { 0x68 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("PLA", codeLines[0]);
        }

        [Test]
        public void AssembleStackPLP()
        {
            string[] codeLines = new[] { "PLP ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x28 }, machineCode);

            //byte[] machineCode = new byte[] { 0x28 };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("PLP", codeLines[0]);
        }

        [Test]
        public void AssembleStackTSX()
        {
            string[] codeLines = new[] { "TSX ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0xBA }, machineCode);

            //byte[] machineCode = new byte[] { 0xBA };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("TSX", codeLines[0]);
        }

        [Test]
        public void AssembleStackTXS()
        {
            string[] codeLines = new[] { "TXS ; comment" };

            byte[] machineCode = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual(new byte[] { 0x9A }, machineCode);

            //byte[] machineCode = new byte[] { 0x9A };

            //string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            //Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            //Assert.AreEqual("TXS", codeLines[0]);
        }

        #endregion
        
        #endregion

    }
}