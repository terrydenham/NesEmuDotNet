using NUnit.Framework;
using System.Security.Cryptography;

namespace Lib6502.Tests
{
    public class AssemblerDisassembleTests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region ADC
        [Test]
        public void DisassembleADCWithABS()
        {
            byte[] machineCode = new byte[] { 0x6D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ADC $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleADCWithABX()
        {
            byte[] machineCode = new byte[] { 0x7D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ADC $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleADCWithABY()
        {
            byte[] machineCode = new byte[] { 0x79, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ADC $4400,Y", codeLines[0]);
        }

        [Test]
        public void DisassembleADCWithIMM()
        {
            byte[] machineCode = new byte[] { 0x69, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ADC #$44", codeLines[0]);
        }

        [Test]
        public void DisassembleADCWithIZX()
        {
            byte[] machineCode = new byte[] { 0x61, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ADC ($44,X)", codeLines[0]);
        }

        [Test]
        public void DisassembleADCWithIZY()
        {
            byte[] machineCode = new byte[] { 0x71, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ADC ($44),Y", codeLines[0]);
        }

        [Test]
        public void DisassembleADCWithZP0()
        {
            byte[] machineCode = new byte[] { 0x65, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ADC $44", codeLines[0]);
        }

        [Test]
        public void DisassembleADCWithZPX()
        {
            byte[] machineCode = new byte[] { 0x75, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ADC $44,X", codeLines[0]);
        }
        #endregion

        #region AND
        [Test]
        public void DisassembleANDWithABS()
        {
            byte[] machineCode = new byte[] { 0x2D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("AND $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleANDWithABX()
        {
            byte[] machineCode = new byte[] { 0x3D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("AND $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleANDWithABY()
        {
            byte[] machineCode = new byte[] { 0x39, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("AND $4400,Y", codeLines[0]);
        }

        [Test]
        public void DisassembleANDWithIMM()
        {
            byte[] machineCode = new byte[] { 0x29, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("AND #$44", codeLines[0]);
        }

        [Test]
        public void DisassembleANDWithIZX()
        {
            byte[] machineCode = new byte[] { 0x21, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("AND ($44,X)", codeLines[0]);
        }
        [Test]
        public void DisassembleANDWithIZY()
        {
            byte[] machineCode = new byte[] { 0x31, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("AND ($44),Y", codeLines[0]);
        }
        [Test]
        public void DisassembleANDWithZP0()
        {
            byte[] machineCode = new byte[] { 0x25, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("AND $44", codeLines[0]);
        }

        [Test]
        public void DisassembleANDWithZPX()
        {
            byte[] machineCode = new byte[] { 0x35, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("AND $44,X", codeLines[0]);
        }

        #endregion

        #region ASL
        [Test]
        public void DisassembleASLWithABS()
        {
            byte[] machineCode = new byte[] { 0x0E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ASL $4400", codeLines[0]);
        }
        [Test]
        public void DisassembleASLWithABX()
        {
            byte[] machineCode = new byte[] { 0x1E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ASL $4400,X", codeLines[0]);
        }
        [Test]
        public void DisassembleASLWithACC()
        {
            byte[] machineCode = new byte[] { 0x0A };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ASL A", codeLines[0]);
        }

        [Test]
        public void DisassembleASLWithZP0()
        {
            byte[] machineCode = new byte[] { 0x06, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ASL $44", codeLines[0]);
        }

        [Test]
        public void DisassembleASLWithZPX()
        {
            byte[] machineCode = new byte[] { 0x16, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ASL $44,X", codeLines[0]);
        }

        #endregion

        #region BIT
        [Test]
        public void DisassembleBITWithABS()
        {
            byte[] machineCode = new byte[] { 0x2C, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BIT $4400", codeLines[0]);
        }
        [Test]
        public void DisassembleBITWithZP0()
        {
            byte[] machineCode = new byte[] { 0x24, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BIT $44", codeLines[0]);
        }
        #endregion

        #region Branch
        [Test]
        public void DisassembleBCC()
        {
            byte[] machineCode = new byte[] { 0x90, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BCC $44", codeLines[0]);
        }

        [Test]
        public void DisassembleBCS()
        {
            byte[] machineCode = new byte[] { 0xB0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BCS $44", codeLines[0]);
        }

        [Test]
        public void DisassembleBEQ()
        {
            byte[] machineCode = new byte[] { 0xF0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BEQ $44", codeLines[0]);
        }

        [Test]
        public void DisassembleBMI()
        {
            byte[] machineCode = new byte[] { 0x30, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BMI $44", codeLines[0]);
        }

        [Test]
        public void DisassembleBNE()
        {
            byte[] machineCode = new byte[] { 0xD0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BNE $44", codeLines[0]);
        }
        [Test]
        public void DisassembleBPL()
        {
            byte[] machineCode = new byte[] { 0x10, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BPL $44", codeLines[0]);
        }

        [Test]
        public void DisassembleBVC()
        {
            byte[] machineCode = new byte[] { 0x50, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BVC $44", codeLines[0]);
        }

        [Test]
        public void DisassembleBVS()
        {
            byte[] machineCode = new byte[] { 0x70, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BVS $44", codeLines[0]);
        }
        #endregion

        #region BRK
        [Test]
        public void DisassembleBRK()
        {
            byte[] machineCode = new byte[] { 0x00 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("BRK", codeLines[0]);
        }
        #endregion

        #region CMP
        [Test]
        public void DisassembleCMPWithABS()
        {
            byte[] machineCode = new byte[] { 0xCD, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleCMPWithABX()
        {
            byte[] machineCode = new byte[] { 0xDD, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleCMPWithABY()
        {
            byte[] machineCode = new byte[] { 0xD9, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP $4400,Y", codeLines[0]);
        }

        [Test]
        public void DisassembleCMPWithIMM()
        {
            byte[] machineCode = new byte[] { 0xC9, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP #$44", codeLines[0]);
        }

        [Test]
        public void DisassembleCMPWithIZX()
        {
            byte[] machineCode = new byte[] { 0xC1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP ($44,X)", codeLines[0]);
        }

        [Test]
        public void DisassembleCMPWithIZY()
        {
            byte[] machineCode = new byte[] { 0xD1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP ($44),Y", codeLines[0]);
        }

        [Test]
        public void DisassembleCMPWithZP0()
        {
            byte[] machineCode = new byte[] { 0xC5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP $44", codeLines[0]);
        }

        [Test]
        public void DisassembleCMPWithZPX()
        {
            byte[] machineCode = new byte[] { 0xD5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CMP $44,X", codeLines[0]);
        }
        #endregion

        #region CPX
        [Test]
        public void DisassembleCPXWithABS()
        {
            byte[] machineCode = new byte[] { 0xEC, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPX $4400", codeLines[0]);
        }
        [Test]
        public void DisassembleCPXWithIMM()
        {
            byte[] machineCode = new byte[] { 0xE0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPX #$44", codeLines[0]);
        }

        [Test]
        public void DisassembleCPXWithZP0()
        {
            byte[] machineCode = new byte[] { 0xE4, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPX $44", codeLines[0]);
        }
        #endregion

        #region CPY
        [Test]
        public void DisassembleCPYWithABS()
        {
            byte[] machineCode = new byte[] { 0xCC, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPY $4400", codeLines[0]);
        }
        [Test]
        public void DisassembleCPYWithIMM()
        {
            byte[] machineCode = new byte[] { 0xC0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPY #$44", codeLines[0]);
        }

        [Test]
        public void DisassembleCPYWithZP0()
        {
            byte[] machineCode = new byte[] { 0xC4, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CPY $44", codeLines[0]);
        }
        #endregion

        #region DEC
        [Test]
        public void DisassembleDECWithABS()
        {
            byte[] machineCode = new byte[] { 0xCE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEC $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleDECWithABX()
        {
            byte[] machineCode = new byte[] { 0xDE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEC $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleDECWithZP0()
        {
            byte[] machineCode = new byte[] { 0xC6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEC $44", codeLines[0]);
        }

        [Test]
        public void DisassembleDECWithZPX()
        {
            byte[] machineCode = new byte[] { 0xD6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEC $44,X", codeLines[0]);
        }
        #endregion

        #region EOR
        [Test]
        public void DisassembleEORWithABS()
        {
            byte[] machineCode = new byte[] { 0x4D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleEORWithABX()
        {
            byte[] machineCode = new byte[] { 0x5D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleEORWithABY()
        {
            byte[] machineCode = new byte[] { 0x59, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR $4400,Y", codeLines[0]);
        }

        [Test]
        public void DisassembleEORWithIMM()
        {
            byte[] machineCode = new byte[] { 0x49, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR #$44", codeLines[0]);
        }

        [Test]
        public void DisassembleEORWithIZX()
        {
            byte[] machineCode = new byte[] { 0x41, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR ($44,X)", codeLines[0]);
        }

        [Test]
        public void DisassembleEORWithIZY()
        {
            byte[] machineCode = new byte[] { 0x51, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR ($44),Y", codeLines[0]);
        }

        [Test]
        public void DisassembleEORWithZP0()
        {
            byte[] machineCode = new byte[] { 0x45, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR $44", codeLines[0]);
        }

        [Test]
        public void DisassembleEORWithZPX()
        {
            byte[] machineCode = new byte[] { 0x55, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("EOR $44,X", codeLines[0]);
        }
        #endregion

        #region Flag
        [Test]
        public void DisassembleCLC()
        {
            byte[] machineCode = new byte[] { 0x18 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CLC", codeLines[0]);
        }

        [Test]
        public void DisassembleCLD()
        {
            byte[] machineCode = new byte[] { 0xD8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CLD", codeLines[0]);
        }

        [Test]
        public void DisassembleCLI()
        {
            byte[] machineCode = new byte[] { 0x58 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CLI", codeLines[0]);
        }

        [Test]
        public void DisassembleCLV()
        {
            byte[] machineCode = new byte[] { 0xB8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("CLV", codeLines[0]);
        }

        [Test]
        public void DisassembleSEC()
        {
            byte[] machineCode = new byte[] { 0x38 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SEC", codeLines[0]);
        }

        [Test]
        public void DisassembleSED()
        {
            byte[] machineCode = new byte[] { 0xF8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SED", codeLines[0]);
        }

        [Test]
        public void DisassembleSEI()
        {
            byte[] machineCode = new byte[] { 0x78 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SEI", codeLines[0]);
        }
        #endregion

        #region INC
        [Test]
        public void DisassembleINCWithABS()
        {
            byte[] machineCode = new byte[] { 0xEE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INC $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleINCWithABX()
        {
            byte[] machineCode = new byte[] { 0xFE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INC $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleINCWithZP0()
        {
            byte[] machineCode = new byte[] { 0xE6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INC $44", codeLines[0]);
        }

        [Test]
        public void DisassembleINCWithZPX()
        {
            byte[] machineCode = new byte[] { 0xF6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INC $44,X", codeLines[0]);
        }
        #endregion

        #region JMP
        [Test]
        public void DisassembleJMPWithABS()
        {
            byte[] machineCode = new byte[] { 0x4C, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("JMP $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleJMPWithIND()
        {
            byte[] machineCode = new byte[] { 0x6C, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("JMP ($4400)", codeLines[0]);
        }
        #endregion

        #region JSR
        [Test]
        public void DisassembleJSRWithABS()
        {
            byte[] machineCode = new byte[] { 0x20, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("JSR $4400", codeLines[0]);
        }
        #endregion

        #region LDA
        [Test]
        public void DisassembleLDAWithABS()
        {
            byte[] machineCode = new byte[] { 0xAD, 0x00, 0x44};

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleLDAWithABX()
        {
            byte[] machineCode = new byte[] { 0xBD, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleLDAWithABY()
        {
            byte[] machineCode = new byte[] { 0xB9, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA $4400,Y", codeLines[0]);
        }

        [Test]
        public void DisassembleLDAWithIMM()
        {
            byte[] machineCode = new byte[] { 0xA9, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA #$44", codeLines[0]);
        }

        [Test]
        public void DisassembleLDAWithIZX()
        {
            byte[] machineCode = new byte[] { 0xA1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA ($44,X)", codeLines[0]);
        }

        [Test]
        public void DisassembleLDAWithIZY()
        {
            byte[] machineCode = new byte[] { 0xB1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA ($44),Y", codeLines[0]);
        }

        [Test]
        public void DisassembleLDAWithZP0()
        {
            byte[] machineCode = new byte[] { 0xA5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA $44", codeLines[0]);
        }

        [Test]
        public void DisassembleLDAWithZPX()
        {
            byte[] machineCode = new byte[] { 0xB5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDA $44,X", codeLines[0]);
        }
        #endregion

        #region LDX
        [Test]
        public void DisassembleLDXWithABS()
        {
            byte[] machineCode = new byte[] { 0xAE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDX $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleLDXWithABY()
        {
            byte[] machineCode = new byte[] { 0xBE, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDX $4400,Y", codeLines[0]);
        }

        [Test]
        public void DisassembleLDXWithIMM()
        {
            byte[] machineCode = new byte[] { 0xA2, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDX #$44", codeLines[0]);
        }

        [Test]
        public void DisassembleLDXWithZP0()
        {
            byte[] machineCode = new byte[] { 0xA6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDX $44", codeLines[0]);
        }

        [Test]
        public void DisassembleLDXWithZPY()
        {
            byte[] machineCode = new byte[] { 0xB6, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDX $44,Y", codeLines[0]);
        }
        #endregion

        #region LDY
        [Test]
        public void DisassembleLDYWithABS()
        {
            byte[] machineCode = new byte[] { 0xAC, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDY $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleLDYWithABX()
        {
            byte[] machineCode = new byte[] { 0xBC, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDY $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleLDYWithIMM()
        {
            byte[] machineCode = new byte[] { 0xA0, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDY #$44", codeLines[0]);
        }

        [Test]
        public void DisassembleLDYWithZP0()
        {
            byte[] machineCode = new byte[] { 0xA4, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDY $44", codeLines[0]);
        }

        [Test]
        public void DisassembleLDYWithZPX()
        {
            byte[] machineCode = new byte[] { 0xB4, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LDY $44,X", codeLines[0]);
        }
        #endregion

        #region LSR
        [Test]
        public void DisassembleLSRWithACC()
        {
            byte[] machineCode = new byte[] { 0x4A };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LSR A", codeLines[0]);
        }

        [Test]
        public void DisassembleLSRWithABS()
        {
            byte[] machineCode = new byte[] { 0x4E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LSR $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleLSRWithABX()
        {
            byte[] machineCode = new byte[] { 0x5E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LSR $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleLSRWithZP0()
        {
            byte[] machineCode = new byte[] { 0x46, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LSR $44", codeLines[0]);
        }

        [Test]
        public void DisassembleLSRWithZPX()
        {
            byte[] machineCode = new byte[] { 0x56, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("LSR $44,X", codeLines[0]);
        }
        #endregion

        #region NOP
        [Test]
        public void DisassembleNOP()
        {
            byte[] machineCode = new byte[] { 0xEA };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("NOP", codeLines[0]);
        }

        [Test]
        public void DisassembleNOPofTwo()
        {
            byte[] machineCode = new byte[] { 0xEA, 0xEA };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(2, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("NOP", codeLines[0]);
            Assert.AreEqual("NOP", codeLines[1]);
        }

        #endregion

        #region ORA
        [Test]
        public void DisassembleORAWithABS()
        {
            byte[] machineCode = new byte[] { 0x0D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleORAWithABX()
        {
            byte[] machineCode = new byte[] { 0x1D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleORAWithABY()
        {
            byte[] machineCode = new byte[] { 0x19, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA $4400,Y", codeLines[0]);
        }

        [Test]
        public void DisassembleORAWithIMM()
        {
            byte[] machineCode = new byte[] { 0x09, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA #$44", codeLines[0]);
        }

        [Test]
        public void DisassembleORAWithIZX()
        {
            byte[] machineCode = new byte[] { 0x01, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA ($44,X)", codeLines[0]);
        }

        [Test]
        public void DisassembleORAWithIZY()
        {
            byte[] machineCode = new byte[] { 0x11, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA ($44),Y", codeLines[0]);
        }

        [Test]
        public void DisassembleORAWithZP0()
        {
            byte[] machineCode = new byte[] { 0x05, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA $44", codeLines[0]);
        }

        [Test]
        public void DisassembleORAWithZPX()
        {
            byte[] machineCode = new byte[] { 0x15, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ORA $44,X", codeLines[0]);
        }
        #endregion

        #region Register
        [Test]
        public void DisassembleDEX()
        {
            byte[] machineCode = new byte[] { 0xCA };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEX", codeLines[0]);
        }

        [Test]
        public void DisassembleDEY()
        {
            byte[] machineCode = new byte[] { 0x88 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("DEY", codeLines[0]);
        }

        [Test]
        public void DisassembleINX()
        {
            byte[] machineCode = new byte[] { 0xE8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INX", codeLines[0]);
        }

        [Test]
        public void DisassembleINY()
        {
            byte[] machineCode = new byte[] { 0xC8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("INY", codeLines[0]);
        }

        [Test]
        public void DisassembleTAX()
        {
            byte[] machineCode = new byte[] { 0xAA };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TAX", codeLines[0]);
        }

        [Test]
        public void DisassembleTAY()
        {
            byte[] machineCode = new byte[] { 0xA8 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TAY", codeLines[0]);
        }

        [Test]
        public void DisassembleTXA()
        {
            byte[] machineCode = new byte[] { 0x8A };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TXA", codeLines[0]);
        }

        [Test]
        public void DisassembleTYA()
        {
            byte[] machineCode = new byte[] { 0x98 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TYA", codeLines[0]);
        }
        #endregion

        #region ROL
        [Test]
        public void DisassembleROLWithABS()
        {
            byte[] machineCode = new byte[] { 0x2E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROL $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleROLWithABX()
        {
            byte[] machineCode = new byte[] { 0x3E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROL $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleROLWithACC()
        {
            byte[] machineCode = new byte[] { 0x2A };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROL A", codeLines[0]);
        }

        [Test]
        public void DisassembleROLWithZP0()
        {
            byte[] machineCode = new byte[] { 0x26, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROL $44", codeLines[0]);
        }

        [Test]
        public void DisassembleROLWithZPX()
        {
            byte[] machineCode = new byte[] { 0x36, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROL $44,X", codeLines[0]);
        }
        #endregion

        #region ROR
        [Test]
        public void DisassembleRORWithABS()
        {
            byte[] machineCode = new byte[] { 0x6E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROR $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleRORWithABX()
        {
            byte[] machineCode = new byte[] { 0x7E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROR $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleRORWithACC()
        {
            byte[] machineCode = new byte[] { 0x6A };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROR A", codeLines[0]);
        }

        [Test]
        public void DisassembleRORWithZP0()
        {
            byte[] machineCode = new byte[] { 0x66, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROR $44", codeLines[0]);
        }

        [Test]
        public void DisassembleRORWithZPX()
        {
            byte[] machineCode = new byte[] { 0x76, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("ROR $44,X", codeLines[0]);
        }
        #endregion

        #region RTI
        [Test]
        public void DisassembleRTI()
        {
            byte[] machineCode = new byte[] { 0x40 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("RTI", codeLines[0]);
        }
        #endregion

        #region RTS
        [Test]
        public void DisassembleRTS()
        {
            byte[] machineCode = new byte[] { 0x60 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("RTS", codeLines[0]);
        }
        #endregion

        #region SBC
        [Test]
        public void DisassembleSBCWithABS()
        {
            byte[] machineCode = new byte[] { 0xED, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleSBCWithABX()
        {
            byte[] machineCode = new byte[] { 0xFD, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleSBCWithABY()
        {
            byte[] machineCode = new byte[] { 0xF9, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC $4400,Y", codeLines[0]);
        }

        [Test]
        public void DisassembleSBCWithIMM()
        {
            byte[] machineCode = new byte[] { 0xE9, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC #$44", codeLines[0]);
        }

        [Test]
        public void DisassembleSBCWithIZX()
        {
            byte[] machineCode = new byte[] { 0xE1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC ($44,X)", codeLines[0]);
        }

        [Test]
        public void DisassembleSBCWithIZY()
        {
            byte[] machineCode = new byte[] { 0xF1, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC ($44),Y", codeLines[0]);
        }

        [Test]
        public void DisassembleSBCWithZP0()
        {
            byte[] machineCode = new byte[] { 0xE5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC $44", codeLines[0]);
        }

        [Test]
        public void DisassembleSBCWithZPX()
        {
            byte[] machineCode = new byte[] { 0xF5, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, 2);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("SBC $44,X", codeLines[0]);
        }
        #endregion

        #region STA
        [Test]
        public void DisassembleSTAWithABS()
        {
            byte[] machineCode = new byte[] { 0x8D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleSTAWithABX()
        {
            byte[] machineCode = new byte[] { 0x9D, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA $4400,X", codeLines[0]);
        }

        [Test]
        public void DisassembleSTAWithABY()
        {
            byte[] machineCode = new byte[] { 0x99, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA $4400,Y", codeLines[0]);
        }

        //[Test]
        //public void DisassembleSTAWithIMM()
        //{
        //    byte[] machineCode = new byte[] { 0xA9, 0x44 };

        //    string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

        //    Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
        //    Assert.AreEqual("STA #$44", codeLines[0]);
        //}

        [Test]
        public void DisassembleSTAWithIZX()
        {
            byte[] machineCode = new byte[] { 0x81, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA ($44,X)", codeLines[0]);
        }

        [Test]
        public void DisassembleSTAWithIZY()
        {
            byte[] machineCode = new byte[] { 0x91, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA ($44),Y", codeLines[0]);
        }

        [Test]
        public void DisassembleSTAWithZP0()
        {
            byte[] machineCode = new byte[] { 0x85, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA $44", codeLines[0]);
        }

        [Test]
        public void DisassembleSTAWithZPX()
        {
            byte[] machineCode = new byte[] { 0x95, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STA $44,X", codeLines[0]);
        }
        #endregion

        #region Stack
        [Test]
        public void DisassemblePHA()
        {
            byte[] machineCode = new byte[] { 0x48 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("PHA", codeLines[0]);
        }

        [Test]
        public void DisassemblePHP()
        {
            byte[] machineCode = new byte[] { 0x08 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("PHP", codeLines[0]);
        }

        [Test]
        public void DisassemblePLA()
        {
            byte[] machineCode = new byte[] { 0x68 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("PLA", codeLines[0]);
        }

        [Test]
        public void DisassemblePLP()
        {
            byte[] machineCode = new byte[] { 0x28 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("PLP", codeLines[0]);
        }

        [Test]
        public void DisassembleTSX()
        {
            byte[] machineCode = new byte[] { 0xBA };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TSX", codeLines[0]);
        }

        [Test]
        public void DisassembleTXS()
        {
            byte[] machineCode = new byte[] { 0x9A };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("TXS", codeLines[0]);
        }

        #endregion

        #region STX
        [Test]
        public void DisassembleSTXWithABS()
        {
            byte[] machineCode = new byte[] { 0x8E, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STX $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleSTXWithZP0()
        {
            byte[] machineCode = new byte[] { 0x86, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STX $44", codeLines[0]);
        }

        [Test]
        public void DisassembleSTXWithZPY()
        {
            byte[] machineCode = new byte[] { 0x96, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STX $44,Y", codeLines[0]);
        }
        #endregion

        #region STY
        [Test]
        public void DisassembleSTYWithABS()
        {
            byte[] machineCode = new byte[] { 0x8C, 0x00, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STY $4400", codeLines[0]);
        }

        [Test]
        public void DisassembleSTYWithZP0()
        {
            byte[] machineCode = new byte[] { 0x84, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STY $44", codeLines[0]);
        }

        [Test]
        public void DisassembleSTYWithZPX()
        {
            byte[] machineCode = new byte[] { 0x94, 0x44 };

            string[] codeLines = Lib6502.Assembler.Disassemble(machineCode, (uint)machineCode.Length);

            Assert.AreEqual(1, codeLines.Length, "Expected 1 line of code");
            Assert.AreEqual("STY $44,X", codeLines[0]);
        }
        #endregion
    }
}