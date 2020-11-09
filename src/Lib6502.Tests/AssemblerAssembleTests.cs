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

        [Test, Ignore("not working")]
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
        [Test, Ignore("not working")]
        public void AssembleBITWithABS()
        {
            byte[] machineCode = new byte[] { 0x2C, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BIT $4400", codeLines[0]);
        }
        [Test, Ignore("not working")]
        public void AssembleBITWithZP0()
        {
            byte[] machineCode = new byte[] { 0x24, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BIT $44", codeLines[0]);
        }
        #endregion

        #region Branch
        [Test, Ignore("not working")]
        public void AssembleBranchBCC()
        {
            byte[] machineCode = new byte[] { 0x90, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BCC $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleBranchBCS()
        {
            byte[] machineCode = new byte[] { 0xB0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BCS $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleBranchBEQ()
        {
            byte[] machineCode = new byte[] { 0xF0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BEQ $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleBranchBMI()
        {
            byte[] machineCode = new byte[] { 0x30, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BMI $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleBranchBNE()
        {
            byte[] machineCode = new byte[] { 0xD0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BNE $44", codeLines[0]);
        }
        [Test, Ignore("not working")]
        public void AssembleBranchBPL()
        {
            byte[] machineCode = new byte[] { 0x10, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BPL $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleBranchBVC()
        {
            byte[] machineCode = new byte[] { 0x50, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BVC $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleBranchBVS()
        {
            byte[] machineCode = new byte[] { 0x70, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BVS $44", codeLines[0]);
        }
        #endregion

        #region BRK
        [Test, Ignore("not working")]
        public void AssembleBRK()
        {
            byte[] machineCode = new byte[] { 0x00 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BRK", codeLines[0]);
        }
        #endregion

        #region CMP
        [Test, Ignore("not working")]
        public void AssembleCMPWithABS()
        {
            byte[] machineCode = new byte[] { 0xCD, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleCMPWithABX()
        {
            byte[] machineCode = new byte[] { 0xDD, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleCMPWithABY()
        {
            byte[] machineCode = new byte[] { 0xD9, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP $4400,Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleCMPWithIMM()
        {
            byte[] machineCode = new byte[] { 0xC9, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP #$44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleCMPWithIZX()
        {
            byte[] machineCode = new byte[] { 0xC1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP ($44,X)", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleCMPWithIZY()
        {
            byte[] machineCode = new byte[] { 0xD1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP ($44),Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleCMPWithZP0()
        {
            byte[] machineCode = new byte[] { 0xC5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleCMPWithZPX()
        {
            byte[] machineCode = new byte[] { 0xD5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP $44,X", codeLines[0]);
        }
        #endregion

        #region CPX
        [Test, Ignore("not working")]
        public void AssembleCPXWithABS()
        {
            byte[] machineCode = new byte[] { 0xEC, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPX $4400", codeLines[0]);
        }
        [Test, Ignore("not working")]
        public void AssembleCPXWithIMM()
        {
            byte[] machineCode = new byte[] { 0xE0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPX #$44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleCPXWithZP0()
        {
            byte[] machineCode = new byte[] { 0xE4, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPX $44", codeLines[0]);
        }
        #endregion

        #region CPY
        [Test, Ignore("not working")]
        public void AssembleCPYWithABS()
        {
            byte[] machineCode = new byte[] { 0xCC, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPY $4400", codeLines[0]);
        }
        [Test, Ignore("not working")]
        public void AssembleCPYWithIMM()
        {
            byte[] machineCode = new byte[] { 0xC0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPY #$44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleCPYWithZP0()
        {
            byte[] machineCode = new byte[] { 0xC4, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPY $44", codeLines[0]);
        }
        #endregion

        #region DEC
        [Test, Ignore("not working")]
        public void AssembleDECWithABS()
        {
            byte[] machineCode = new byte[] { 0xCE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEC $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleDECWithABX()
        {
            byte[] machineCode = new byte[] { 0xDE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEC $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleDECWithZP0()
        {
            byte[] machineCode = new byte[] { 0xC6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEC $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleDECWithZPX()
        {
            byte[] machineCode = new byte[] { 0xD6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEC $44,X", codeLines[0]);
        }
        #endregion

        #region EOR
        [Test, Ignore("not working")]
        public void AssembleEORWithABS()
        {
            byte[] machineCode = new byte[] { 0x4D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleEORWithABX()
        {
            byte[] machineCode = new byte[] { 0x5D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleEORWithABY()
        {
            byte[] machineCode = new byte[] { 0x59, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR $4400,Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleEORWithIMM()
        {
            byte[] machineCode = new byte[] { 0x49, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR #$44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleEORWithIZX()
        {
            byte[] machineCode = new byte[] { 0x41, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR ($44,X)", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleEORWithIZY()
        {
            byte[] machineCode = new byte[] { 0x51, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR ($44),Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleEORWithZP0()
        {
            byte[] machineCode = new byte[] { 0x45, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleEORWithZPX()
        {
            byte[] machineCode = new byte[] { 0x55, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR $44,X", codeLines[0]);
        }
        #endregion

        #region Flag
        [Test, Ignore("not working")]
        public void AssembleFlagCLC()
        {
            byte[] machineCode = new byte[] { 0x18 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CLC", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleFlagCLD()
        {
            byte[] machineCode = new byte[] { 0xD8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CLD", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleFlagCLI()
        {
            byte[] machineCode = new byte[] { 0x58 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CLI", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleFlagCLV()
        {
            byte[] machineCode = new byte[] { 0xB8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CLV", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleFlagSEC()
        {
            byte[] machineCode = new byte[] { 0x38 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SEC", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleFlagSED()
        {
            byte[] machineCode = new byte[] { 0xF8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SED", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleFlagSEI()
        {
            byte[] machineCode = new byte[] { 0x78 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SEI", codeLines[0]);
        }
        #endregion

        #region INC
        [Test, Ignore("not working")]
        public void AssembleINCWithABS()
        {
            byte[] machineCode = new byte[] { 0xEE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INC $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleINCWithABX()
        {
            byte[] machineCode = new byte[] { 0xFE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INC $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleINCWithZP0()
        {
            byte[] machineCode = new byte[] { 0xE6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INC $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleINCWithZPX()
        {
            byte[] machineCode = new byte[] { 0xF6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INC $44,X", codeLines[0]);
        }
        #endregion

        #region JMP
        [Test, Ignore("not working")]
        public void AssembleJMPWithABS()
        {
            byte[] machineCode = new byte[] { 0x4C, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("JMP $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleJMPWithIND()
        {
            byte[] machineCode = new byte[] { 0x6C, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("JMP ($4400)", codeLines[0]);
        }
        #endregion

        #region JSR
        [Test, Ignore("not working")]
        public void AssembleJSRWithABS()
        {
            byte[] machineCode = new byte[] { 0x20, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("JSR $4400", codeLines[0]);
        }
        #endregion

        #region LDA
        [Test, Ignore("not working")]
        public void AssembleLDAWithABS()
        {
            byte[] machineCode = new byte[] { 0xAD, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDAWithABX()
        {
            byte[] machineCode = new byte[] { 0xBD, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDAWithABY()
        {
            byte[] machineCode = new byte[] { 0xB9, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA $4400,Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDAWithIMM()
        {
            byte[] machineCode = new byte[] { 0xA9, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA #$44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDAWithIZX()
        {
            byte[] machineCode = new byte[] { 0xA1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA ($44,X)", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDAWithIZY()
        {
            byte[] machineCode = new byte[] { 0xB1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA ($44),Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDAWithZP0()
        {
            byte[] machineCode = new byte[] { 0xA5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDAWithZPX()
        {
            byte[] machineCode = new byte[] { 0xB5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA $44,X", codeLines[0]);
        }
        #endregion

        #region LDX
        [Test, Ignore("not working")]
        public void AssembleLDXWithABS()
        {
            byte[] machineCode = new byte[] { 0xAE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDX $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDXWithABY()
        {
            byte[] machineCode = new byte[] { 0xBE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDX $4400,Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDXWithIMM()
        {
            byte[] machineCode = new byte[] { 0xA2, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDX #$44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDXWithZP0()
        {
            byte[] machineCode = new byte[] { 0xA6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDX $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDXWithZPY()
        {
            byte[] machineCode = new byte[] { 0xB6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDX $44,Y", codeLines[0]);
        }
        #endregion

        #region LDY
        [Test, Ignore("not working")]
        public void AssembleLDYWithABS()
        {
            byte[] machineCode = new byte[] { 0xAC, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDY $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDYWithABX()
        {
            byte[] machineCode = new byte[] { 0xBC, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDY $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDYWithIMM()
        {
            byte[] machineCode = new byte[] { 0xA0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDY #$44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDYWithZP0()
        {
            byte[] machineCode = new byte[] { 0xA4, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDY $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLDYWithZPX()
        {
            byte[] machineCode = new byte[] { 0xB4, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDY $44,X", codeLines[0]);
        }
        #endregion

        #region LSR
        [Test, Ignore("not working")]
        public void AssembleLSRWithACC()
        {
            byte[] machineCode = new byte[] { 0x4A };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LSR A", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLSRWithABS()
        {
            byte[] machineCode = new byte[] { 0x4E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LSR $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLSRWithABX()
        {
            byte[] machineCode = new byte[] { 0x5E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LSR $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLSRWithZP0()
        {
            byte[] machineCode = new byte[] { 0x46, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LSR $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleLSRWithZPX()
        {
            byte[] machineCode = new byte[] { 0x56, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LSR $44,X", codeLines[0]);
        }
        #endregion

        #region NOP
        [Test, Ignore("not working")]
        public void AssembleNOP()
        {
            byte[] machineCode = new byte[] { 0xEA };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("NOP", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleNOPofTwo()
        {
            byte[] machineCode = new byte[] { 0xEA, 0xEA };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(2, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("NOP", codeLines[0]);
            Assert.AreEqual("NOP", codeLines[1]);
        }

        #endregion

        #region ORA
        [Test, Ignore("not working")]
        public void AssembleORAWithABS()
        {
            byte[] machineCode = new byte[] { 0x0D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleORAWithABX()
        {
            byte[] machineCode = new byte[] { 0x1D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleORAWithABY()
        {
            byte[] machineCode = new byte[] { 0x19, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA $4400,Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleORAWithIMM()
        {
            byte[] machineCode = new byte[] { 0x09, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA #$44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleORAWithIZX()
        {
            byte[] machineCode = new byte[] { 0x01, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA ($44,X)", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleORAWithIZY()
        {
            byte[] machineCode = new byte[] { 0x11, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA ($44),Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleORAWithZP0()
        {
            byte[] machineCode = new byte[] { 0x05, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleORAWithZPX()
        {
            byte[] machineCode = new byte[] { 0x15, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA $44,X", codeLines[0]);
        }
        #endregion

        #region Register
        [Test, Ignore("not working")]
        public void AssembleRegisterDEX()
        {
            byte[] machineCode = new byte[] { 0xCA };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEX", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleRegisterDEY()
        {
            byte[] machineCode = new byte[] { 0x88 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEY", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleRegisterINX()
        {
            byte[] machineCode = new byte[] { 0xE8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INX", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleRegisterINY()
        {
            byte[] machineCode = new byte[] { 0xC8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INY", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleRegisterTAX()
        {
            byte[] machineCode = new byte[] { 0xAA };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TAX", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleRegisterTAY()
        {
            byte[] machineCode = new byte[] { 0xA8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TAY", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleRegisterTXA()
        {
            byte[] machineCode = new byte[] { 0x8A };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TXA", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleRegisterTYA()
        {
            byte[] machineCode = new byte[] { 0x98 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TYA", codeLines[0]);
        }
        #endregion

        #region ROL
        [Test, Ignore("not working")]
        public void AssembleROLWithABS()
        {
            byte[] machineCode = new byte[] { 0x2E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROL $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleROLWithABX()
        {
            byte[] machineCode = new byte[] { 0x3E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROL $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleROLWithACC()
        {
            byte[] machineCode = new byte[] { 0x2A };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROL A", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleROLWithZP0()
        {
            byte[] machineCode = new byte[] { 0x26, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROL $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleROLWithZPX()
        {
            byte[] machineCode = new byte[] { 0x36, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROL $44,X", codeLines[0]);
        }
        #endregion

        #region ROR
        [Test, Ignore("not working")]
        public void AssembleRORWithABS()
        {
            byte[] machineCode = new byte[] { 0x6E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROR $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleRORWithABX()
        {
            byte[] machineCode = new byte[] { 0x7E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROR $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleRORWithACC()
        {
            byte[] machineCode = new byte[] { 0x6A };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROR A", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleRORWithZP0()
        {
            byte[] machineCode = new byte[] { 0x66, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROR $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleRORWithZPX()
        {
            byte[] machineCode = new byte[] { 0x76, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROR $44,X", codeLines[0]);
        }
        #endregion

        #region RTI
        [Test, Ignore("not working")]
        public void AssembleRTI()
        {
            byte[] machineCode = new byte[] { 0x40 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("RTI", codeLines[0]);
        }
        #endregion

        #region RTS
        [Test, Ignore("not working")]
        public void AssembleRTS()
        {
            byte[] machineCode = new byte[] { 0x60 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("RTS", codeLines[0]);
        }
        #endregion

        #region SBC
        [Test, Ignore("not working")]
        public void AssembleSBCWithABS()
        {
            byte[] machineCode = new byte[] { 0xED, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSBCWithABX()
        {
            byte[] machineCode = new byte[] { 0xFD, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSBCWithABY()
        {
            byte[] machineCode = new byte[] { 0xF9, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC $4400,Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSBCWithIMM()
        {
            byte[] machineCode = new byte[] { 0xE9, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC #$44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSBCWithIZX()
        {
            byte[] machineCode = new byte[] { 0xE1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC ($44,X)", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSBCWithIZY()
        {
            byte[] machineCode = new byte[] { 0xF1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC ($44),Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSBCWithZP0()
        {
            byte[] machineCode = new byte[] { 0xE5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSBCWithZPX()
        {
            byte[] machineCode = new byte[] { 0xF5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC $44,X", codeLines[0]);
        }
        #endregion

        #region STA
        [Test, Ignore("not working")]
        public void AssembleSTAWithABS()
        {
            byte[] machineCode = new byte[] { 0x8D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSTAWithABX()
        {
            byte[] machineCode = new byte[] { 0x9D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA $4400,X", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSTAWithABY()
        {
            byte[] machineCode = new byte[] { 0x99, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA $4400,Y", codeLines[0]);
        }

        //[Test, Ignore("not working")]
        //public void AssembleSTAWithIMM()
        //{
        //    byte[] machineCode = new byte[] { 0xA9, 0x44 };

        //    string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

        //    Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
        //    Assert.AreEqual("STA #$44", codeLines[0]);
        //}

        [Test, Ignore("not working")]
        public void AssembleSTAWithIZX()
        {
            byte[] machineCode = new byte[] { 0x81, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA ($44,X)", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSTAWithIZY()
        {
            byte[] machineCode = new byte[] { 0x91, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA ($44),Y", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSTAWithZP0()
        {
            byte[] machineCode = new byte[] { 0x85, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSTAWithZPX()
        {
            byte[] machineCode = new byte[] { 0x95, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA $44,X", codeLines[0]);
        }
        #endregion

        #region Stack
        [Test, Ignore("not working")]
        public void AssembleStackPHA()
        {
            byte[] machineCode = new byte[] { 0x48 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("PHA", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleStackPHP()
        {
            byte[] machineCode = new byte[] { 0x08 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("PHP", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleStackPLA()
        {
            byte[] machineCode = new byte[] { 0x68 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("PLA", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleStackPLP()
        {
            byte[] machineCode = new byte[] { 0x28 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("PLP", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleStackTSX()
        {
            byte[] machineCode = new byte[] { 0xBA };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TSX", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleStackTXS()
        {
            byte[] machineCode = new byte[] { 0x9A };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TXS", codeLines[0]);
        }

        #endregion

        #region STX
        [Test, Ignore("not working")]
        public void AssembleSTXWithABS()
        {
            byte[] machineCode = new byte[] { 0x8E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STX $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSTXWithZP0()
        {
            byte[] machineCode = new byte[] { 0x86, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STX $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSTXWithZPY()
        {
            byte[] machineCode = new byte[] { 0x96, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STX $44,Y", codeLines[0]);
        }
        #endregion

        #region STY
        [Test, Ignore("not working")]
        public void AssembleSTYWithABS()
        {
            byte[] machineCode = new byte[] { 0x8C, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STY $4400", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSTYWithZP0()
        {
            byte[] machineCode = new byte[] { 0x84, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STY $44", codeLines[0]);
        }

        [Test, Ignore("not working")]
        public void AssembleSTYWithZPX()
        {
            byte[] machineCode = new byte[] { 0x94, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STY $44,X", codeLines[0]);
        }
        #endregion
        #endregion

    }
}