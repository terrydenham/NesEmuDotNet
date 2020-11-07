using NUnit.Framework;
using System.Security.Cryptography;

namespace Lib6502.Tests
{
    public class AssemblerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, Ignore("")]
        public void AssembleAddWithCarryInImmediateMode()
        {

            string[] codeLines = { "ADC #$44 ; add the hex value 44 to the accumulator" };

            byte[] actual = Lib6502.Assembler.Assemble(codeLines);

            Assert.AreEqual(2, actual.Length, "Expected 2 bytes of code");
            Assert.AreEqual(0x69, actual[0], "Did not generate the correct opcode");
            Assert.AreEqual(0x44, actual[1], "Did not generate the correct operand");
            Assert.Fail();

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

    }
}