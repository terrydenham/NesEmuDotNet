using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Lib6502
{
    public enum AddressMode
    {
        ABS,
        ABX,
        ABY,
        ACC,
        IMM,
        IMP,
        IND,
        IZX,
        IZY,
        REL,
        ZP0,
        ZPX,
        ZPY,
        XXX
    }

    public struct Instruction
    {
        public string Pnuemonic { get; }
        public AddressMode Mode { get; }
        public byte Opcode { get; }
        public int Length { get; }

        public Instruction(string pnuemonic, byte opcode, AddressMode mode, int length)
        {
            Pnuemonic = pnuemonic;
            Opcode = opcode;
            Mode = mode;
            Length = length;
        }
    }

    public class Assembler
    {
        static Assembler()
        {

            instructions = new ReadOnlyCollection<Instruction>(new[] {
    new Instruction("BRK", 0x00, AddressMode.IMP, 1), new Instruction("ORA", 0x01, AddressMode.IZX, 2), new Instruction("???", 0x02, AddressMode.XXX, 0), new Instruction("???", 0x03, AddressMode.XXX, 0), new Instruction("???", 0x04, AddressMode.XXX, 0), new Instruction("ORA", 0x05, AddressMode.ZP0, 2), new Instruction("ASL", 0x06, AddressMode.ZP0, 2), new Instruction("???", 0x07, AddressMode.XXX, 0), new Instruction("PHP", 0x08, AddressMode.IMP, 1), new Instruction("ORA", 0x09, AddressMode.IMM, 2), new Instruction("ASL", 0x0A, AddressMode.ACC, 1), new Instruction("???", 0x0B, AddressMode.XXX, 0), new Instruction("???", 0x0C, AddressMode.XXX, 0), new Instruction("ORA", 0x0D, AddressMode.ABS, 3), new Instruction("ASL", 0x0E, AddressMode.ABS, 3), new Instruction("???", 0x0F, AddressMode.XXX, 0),
    new Instruction("BPL", 0x10, AddressMode.REL, 2), new Instruction("ORA", 0x11, AddressMode.IZY, 2), new Instruction("???", 0x12, AddressMode.XXX, 0), new Instruction("???", 0x13, AddressMode.XXX, 0), new Instruction("???", 0x14, AddressMode.XXX, 0), new Instruction("ORA", 0x15, AddressMode.ZPX, 2), new Instruction("ASL", 0x16, AddressMode.ZPX, 2), new Instruction("???", 0x17, AddressMode.XXX, 0), new Instruction("CLC", 0x18, AddressMode.IMP, 1), new Instruction("ORA", 0x19, AddressMode.ABY, 3), new Instruction("???", 0x1A, AddressMode.XXX, 0), new Instruction("???", 0x1B, AddressMode.XXX, 0), new Instruction("???", 0x1C, AddressMode.XXX, 0), new Instruction("ORA", 0x1D, AddressMode.ABX, 3), new Instruction("ASL", 0x1E, AddressMode.ABX, 3), new Instruction("???", 0x1F, AddressMode.XXX, 0),
    new Instruction("JSR", 0x20, AddressMode.ABS, 3), new Instruction("AND", 0x21, AddressMode.IZX, 2), new Instruction("???", 0x22, AddressMode.XXX, 0), new Instruction("???", 0x23, AddressMode.XXX, 0), new Instruction("BIT", 0x24, AddressMode.ZP0, 2), new Instruction("AND", 0x25, AddressMode.ZP0, 2), new Instruction("ROL", 0x26, AddressMode.ZP0, 2), new Instruction("???", 0x27, AddressMode.XXX, 0), new Instruction("PLP", 0x28, AddressMode.IMP, 1), new Instruction("AND", 0x29, AddressMode.IMM, 2), new Instruction("ROL", 0x2A, AddressMode.ACC, 1), new Instruction("???", 0x2B, AddressMode.XXX, 0), new Instruction("BIT", 0x2C, AddressMode.ABS, 3), new Instruction("AND", 0x2D, AddressMode.ABS, 3), new Instruction("ROL", 0x2E, AddressMode.ABS, 3), new Instruction("???", 0x2F, AddressMode.XXX, 0),
    new Instruction("BMI", 0x30, AddressMode.REL, 2), new Instruction("AND", 0x31, AddressMode.IZY, 2), new Instruction("???", 0x32, AddressMode.XXX, 0), new Instruction("???", 0x33, AddressMode.XXX, 0), new Instruction("???", 0x34, AddressMode.XXX, 0), new Instruction("AND", 0x35, AddressMode.ZPX, 2), new Instruction("ROL", 0x36, AddressMode.ZPX, 2), new Instruction("???", 0x37, AddressMode.XXX, 0), new Instruction("SEC", 0x38, AddressMode.IMP, 1), new Instruction("AND", 0x39, AddressMode.ABY, 3), new Instruction("???", 0x3A, AddressMode.XXX, 0), new Instruction("???", 0x3B, AddressMode.XXX, 0), new Instruction("???", 0x3C, AddressMode.XXX, 0), new Instruction("AND", 0x3D, AddressMode.ABX, 3), new Instruction("ROL", 0x3E, AddressMode.ABX, 3), new Instruction("???", 0x3F, AddressMode.XXX, 0),
    new Instruction("RTI", 0x40, AddressMode.IMP, 1), new Instruction("EOR", 0x41, AddressMode.IZX, 2), new Instruction("???", 0x42, AddressMode.XXX, 0), new Instruction("???", 0x43, AddressMode.XXX, 0), new Instruction("???", 0x44, AddressMode.XXX, 0), new Instruction("EOR", 0x45, AddressMode.ZP0, 2), new Instruction("LSR", 0x46, AddressMode.ZP0, 2), new Instruction("???", 0x47, AddressMode.XXX, 0), new Instruction("PHA", 0x48, AddressMode.IMP, 1), new Instruction("EOR", 0x49, AddressMode.IMM, 2), new Instruction("LSR", 0x4A, AddressMode.ACC, 1), new Instruction("???", 0x4B, AddressMode.XXX, 0), new Instruction("JMP", 0x4C, AddressMode.ABS, 3), new Instruction("EOR", 0x4D, AddressMode.ABS, 3), new Instruction("LSR", 0x4E, AddressMode.ABS, 3), new Instruction("???", 0x4F, AddressMode.XXX, 0),
    new Instruction("BVC", 0x50, AddressMode.REL, 2), new Instruction("EOR", 0x51, AddressMode.IZY, 2), new Instruction("???", 0x52, AddressMode.XXX, 0), new Instruction("???", 0x53, AddressMode.XXX, 0), new Instruction("???", 0x54, AddressMode.XXX, 0), new Instruction("EOR", 0x55, AddressMode.ZPX, 2), new Instruction("LSR", 0x56, AddressMode.ZPX, 2), new Instruction("???", 0x57, AddressMode.XXX, 0), new Instruction("CLI", 0x58, AddressMode.IMP, 1), new Instruction("EOR", 0x59, AddressMode.ABY, 3), new Instruction("???", 0x5A, AddressMode.XXX, 0), new Instruction("???", 0x5B, AddressMode.XXX, 0), new Instruction("???", 0x5C, AddressMode.XXX, 0), new Instruction("EOR", 0x5D, AddressMode.ABX, 3), new Instruction("LSR", 0x5E, AddressMode.ABX, 3), new Instruction("???", 0x5F, AddressMode.XXX, 0),
    new Instruction("RTS", 0x60, AddressMode.IMP, 1), new Instruction("ADC", 0x61, AddressMode.IZX, 2), new Instruction("???", 0x62, AddressMode.XXX, 0), new Instruction("???", 0x63, AddressMode.XXX, 0), new Instruction("???", 0x64, AddressMode.XXX, 0), new Instruction("ADC", 0x65, AddressMode.ZP0, 2), new Instruction("ROR", 0x66, AddressMode.ZP0, 2), new Instruction("???", 0x67, AddressMode.XXX, 0), new Instruction("PLA", 0x68, AddressMode.IMP, 1), new Instruction("ADC", 0x69, AddressMode.IMM, 2), new Instruction("ROR", 0x6A, AddressMode.ACC, 1), new Instruction("???", 0x6B, AddressMode.XXX, 0), new Instruction("JMP", 0x6C, AddressMode.IND, 3), new Instruction("ADC", 0x6D, AddressMode.ABS, 3), new Instruction("ROR", 0x6E, AddressMode.ABS, 3), new Instruction("???", 0x6F, AddressMode.XXX, 0),
    new Instruction("BVS", 0x70, AddressMode.REL, 2), new Instruction("ADC", 0x71, AddressMode.IZY, 2), new Instruction("???", 0x72, AddressMode.XXX, 0), new Instruction("???", 0x73, AddressMode.XXX, 0), new Instruction("???", 0x74, AddressMode.XXX, 0), new Instruction("ADC", 0x75, AddressMode.ZPX, 2), new Instruction("ROR", 0x76, AddressMode.ZPX, 2), new Instruction("???", 0x77, AddressMode.XXX, 0), new Instruction("SEI", 0x78, AddressMode.IMP, 1), new Instruction("ADC", 0x79, AddressMode.ABY, 3), new Instruction("???", 0x7A, AddressMode.XXX, 0), new Instruction("???", 0x7B, AddressMode.XXX, 0), new Instruction("???", 0x7C, AddressMode.XXX, 0), new Instruction("ADC", 0x7D, AddressMode.ABX, 3), new Instruction("ROR", 0x7E, AddressMode.ABX, 3), new Instruction("???", 0x7F, AddressMode.XXX, 0),
    new Instruction("???", 0x80, AddressMode.XXX, 0), new Instruction("STA", 0x81, AddressMode.IZX, 2), new Instruction("???", 0x82, AddressMode.XXX, 0), new Instruction("???", 0x83, AddressMode.XXX, 0), new Instruction("STY", 0x84, AddressMode.ZP0, 2), new Instruction("STA", 0x85, AddressMode.ZP0, 2), new Instruction("STX", 0x86, AddressMode.ZP0, 2), new Instruction("???", 0x87, AddressMode.XXX, 0), new Instruction("DEY", 0x88, AddressMode.IMP, 1), new Instruction("???", 0x89, AddressMode.XXX, 0), new Instruction("TXA", 0x8A, AddressMode.IMP, 1), new Instruction("???", 0x8B, AddressMode.XXX, 0), new Instruction("STY", 0x8C, AddressMode.ABS, 3), new Instruction("STA", 0x8D, AddressMode.ABS, 3), new Instruction("STX", 0x8E, AddressMode.ABS, 3), new Instruction("???", 0x8F, AddressMode.XXX, 0),
    new Instruction("BCC", 0x90, AddressMode.REL, 2), new Instruction("STA", 0x91, AddressMode.IZY, 2), new Instruction("???", 0x92, AddressMode.XXX, 0), new Instruction("???", 0x93, AddressMode.XXX, 0), new Instruction("STY", 0x94, AddressMode.ZPX, 2), new Instruction("STA", 0x95, AddressMode.ZPX, 2), new Instruction("STX", 0x96, AddressMode.ZPY, 2), new Instruction("???", 0x97, AddressMode.XXX, 0), new Instruction("TYA", 0x98, AddressMode.IMP, 1), new Instruction("STA", 0x99, AddressMode.ABY, 3), new Instruction("TXS", 0x9A, AddressMode.IMP, 1), new Instruction("???", 0x9B, AddressMode.XXX, 0), new Instruction("???", 0x9C, AddressMode.XXX, 0), new Instruction("STA", 0x9D, AddressMode.ABX, 3), new Instruction("???", 0x9E, AddressMode.XXX, 0), new Instruction("???", 0x9F, AddressMode.XXX, 0),
    new Instruction("LDY", 0xA0, AddressMode.IMM, 2), new Instruction("LDA", 0xA1, AddressMode.IZX, 2), new Instruction("LDX", 0xA2, AddressMode.IMM, 2), new Instruction("???", 0xA3, AddressMode.XXX, 0), new Instruction("LDY", 0xA4, AddressMode.ZP0, 2), new Instruction("LDA", 0xA5, AddressMode.ZP0, 2), new Instruction("LDX", 0xA6, AddressMode.ZP0, 2), new Instruction("???", 0xA7, AddressMode.XXX, 0), new Instruction("TAY", 0xA8, AddressMode.IMP, 1), new Instruction("LDA", 0xA9, AddressMode.IMM, 2), new Instruction("TAX", 0xAA, AddressMode.IMP, 1), new Instruction("???", 0xAB, AddressMode.XXX, 0), new Instruction("LDY", 0xAC, AddressMode.ABS, 3), new Instruction("LDA", 0xAD, AddressMode.ABS, 3), new Instruction("LDX", 0xAE, AddressMode.ABS, 3), new Instruction("???", 0xAF, AddressMode.XXX, 0),
    new Instruction("BCS", 0xB0, AddressMode.REL, 2), new Instruction("LDA", 0xB1, AddressMode.IZY, 2), new Instruction("???", 0xB2, AddressMode.XXX, 0), new Instruction("???", 0xB3, AddressMode.XXX, 0), new Instruction("LDY", 0xB4, AddressMode.ZPX, 2), new Instruction("LDA", 0xB5, AddressMode.ZPX, 2), new Instruction("LDX", 0xB6, AddressMode.ZPY, 2), new Instruction("???", 0xB7, AddressMode.XXX, 0), new Instruction("CLV", 0xB8, AddressMode.IMP, 1), new Instruction("LDA", 0xB9, AddressMode.ABY, 3), new Instruction("TSX", 0xBA, AddressMode.IMP, 1), new Instruction("???", 0xBB, AddressMode.XXX, 0), new Instruction("LDY", 0xBC, AddressMode.ABX, 3), new Instruction("LDA", 0xBD, AddressMode.ABX, 3), new Instruction("LDX", 0xBE, AddressMode.ABY, 3), new Instruction("???", 0xBF, AddressMode.XXX, 0),
    new Instruction("CPY", 0xC0, AddressMode.IMM, 2), new Instruction("CMP", 0xC1, AddressMode.IZX, 2), new Instruction("???", 0xC2, AddressMode.XXX, 0), new Instruction("???", 0xC3, AddressMode.XXX, 0), new Instruction("CPY", 0xC4, AddressMode.ZP0, 2), new Instruction("CMP", 0xC5, AddressMode.ZP0, 2), new Instruction("DEC", 0xC6, AddressMode.ZP0, 2), new Instruction("???", 0xC7, AddressMode.XXX, 0), new Instruction("INY", 0xC8, AddressMode.IMP, 1), new Instruction("CMP", 0xC9, AddressMode.IMM, 2), new Instruction("DEX", 0xCA, AddressMode.IMP, 1), new Instruction("???", 0xCB, AddressMode.XXX, 0), new Instruction("CPY", 0xCC, AddressMode.ABS, 3), new Instruction("CMP", 0xCD, AddressMode.ABS, 3), new Instruction("DEC", 0xCE, AddressMode.ABS, 3), new Instruction("???", 0xCF, AddressMode.XXX, 0),
    new Instruction("BNE", 0xD0, AddressMode.REL, 2), new Instruction("CMP", 0xD1, AddressMode.IZY, 2), new Instruction("???", 0xD2, AddressMode.XXX, 0), new Instruction("???", 0xD3, AddressMode.XXX, 0), new Instruction("???", 0xD4, AddressMode.XXX, 0), new Instruction("CMP", 0xD5, AddressMode.ZPX, 2), new Instruction("DEC", 0xD6, AddressMode.ZPX, 2), new Instruction("???", 0xD7, AddressMode.XXX, 0), new Instruction("CLD", 0xD8, AddressMode.IMP, 1), new Instruction("CMP", 0xD9, AddressMode.ABY, 3), new Instruction("???", 0xDA, AddressMode.XXX, 0), new Instruction("???", 0xDB, AddressMode.XXX, 0), new Instruction("???", 0xDC, AddressMode.XXX, 0), new Instruction("CMP", 0xDD, AddressMode.ABX, 3), new Instruction("DEC", 0xDE, AddressMode.ABX, 3), new Instruction("???", 0xDF, AddressMode.XXX, 0),
    new Instruction("CPX", 0xE0, AddressMode.IMM, 2), new Instruction("SBC", 0xE1, AddressMode.IZX, 2), new Instruction("???", 0xE2, AddressMode.XXX, 0), new Instruction("???", 0xE3, AddressMode.XXX, 0), new Instruction("CPX", 0xE4, AddressMode.ZP0, 2), new Instruction("SBC", 0xE5, AddressMode.ZP0, 2), new Instruction("INC", 0xE6, AddressMode.ZP0, 2), new Instruction("???", 0xE7, AddressMode.XXX, 0), new Instruction("INX", 0xE8, AddressMode.IMP, 1), new Instruction("SBC", 0xE9, AddressMode.IMM, 2), new Instruction("NOP", 0xEA, AddressMode.IMP, 1), new Instruction("???", 0xEB, AddressMode.XXX, 0), new Instruction("CPX", 0xEC, AddressMode.ABS, 3), new Instruction("SBC", 0xED, AddressMode.ABS, 3), new Instruction("INC", 0xEE, AddressMode.ABS, 3), new Instruction("???", 0xEF, AddressMode.XXX, 0),
    new Instruction("BEQ", 0xF0, AddressMode.REL, 2), new Instruction("SBC", 0xF1, AddressMode.IZY, 2), new Instruction("???", 0xF2, AddressMode.XXX, 0), new Instruction("???", 0xF3, AddressMode.XXX, 0), new Instruction("???", 0xF4, AddressMode.XXX, 0), new Instruction("SBC", 0xF5, AddressMode.ZPX, 2), new Instruction("INC", 0xF6, AddressMode.ZPX, 2), new Instruction("???", 0xF7, AddressMode.XXX, 0), new Instruction("SED", 0xF8, AddressMode.IMP, 1), new Instruction("SBC", 0xF9, AddressMode.ABY, 3), new Instruction("???", 0xFA, AddressMode.XXX, 0), new Instruction("???", 0xFB, AddressMode.XXX, 0), new Instruction("???", 0xFC, AddressMode.XXX, 0), new Instruction("SBC", 0xFD, AddressMode.ABX, 3), new Instruction("INC", 0xFE, AddressMode.ABX, 3), new Instruction("???", 0xFF, AddressMode.XXX, 0),
});
        }

        public static byte[] Assemble(string[] codeLines) 
        {
            var rv = new Collection<byte>();

            var accumulator = new Regex("A");
            var immediate = new Regex(@"^\#\$(\d\d)$");
            var zeroPage = new Regex(@"^\$(\d\d)(?:,([XY]))?$");
            var absolute = new Regex(@"^\$(\d\d\d\d)(?:,([XY]))?$");
            var indirect = new Regex(@"^\(\$(\d\d)(?:(?:(\d\d)\))|(?:\,([X])\))|(?:\)\,([Y])))");

            foreach(string line in codeLines)
            {
                // break out comments from code
                string[] code_comment_parts = line.Trim().Split(';');

                // break up code / comment parts into code parts (pnuemonic operand [, operand])
                string[] code_parts = code_comment_parts[0].Split(' ');

                string pnuemonic = code_parts[0];
                string operand1 = code_parts[1];
                string operand2 = "";

                byte[] value = null;

                MatchCollection matches = null;

                AddressMode mode = AddressMode.XXX;

                // if the operand starts with a #$, then it is an actual value
                // so use immediate mode
                if (immediate.IsMatch(operand1))
                {
                    matches = immediate.Matches(operand1);

                    value = ConvertToByteArray(matches[0].Groups[1].Value);

                    mode = AddressMode.IMM;
                }
                else if (zeroPage.IsMatch(operand1))
                {
                    matches = zeroPage.Matches(operand1);

                    value = ConvertToByteArray(matches[0].Groups[1].Value);

                    mode = AddressMode.ZP0;

                    if(matches[0].Groups.Count > 2 && matches[0].Groups[2].Length > 0)
                    {
                        operand2 = matches[0].Groups[2].Value;

                        if(operand2 == "X")
                        {
                            mode = AddressMode.ZPX;
                        }
                        else if(operand2 == "Y")
                        {
                            mode = AddressMode.ZPY;
                        }
                        else
                            throw new Exception(String.Format("Invalid register (%s) used with %s pnuemonic", operand2, pnuemonic));
                    }
                }
                else if (absolute.IsMatch(operand1))
                {
                    matches = absolute.Matches(operand1);

                    value = ConvertToByteArray(matches[0].Groups[1].Value);

                    mode = AddressMode.ABS;

                    if (matches[0].Groups.Count > 2 && matches[0].Groups[2].Value != "" )
                    {
                        if(matches[0].Groups[2].Value == "X")
                        {
                            mode = AddressMode.ABX;
                        }
                        else if (matches[0].Groups[2].Value == "Y")
                        {
                            mode = AddressMode.ABY;
                        }
                        else
                            throw new Exception(String.Format("Invalid register (%s) used with %s pnuemonic", operand2, pnuemonic));
                    }
                    else if(matches[0].Groups[1].Value != "")
                    {
                    }
                }
                else if (indirect.IsMatch(operand1))
                {
                    matches = indirect.Matches(operand1);

                    value = ConvertToByteArray(matches[0].Groups[1].Value);

                    mode = AddressMode.IND;

                    if (matches[0].Groups.Count > 2)
                    {
                        if (matches[0].Groups[3].Value == "X")
                        {
                            mode = AddressMode.IZX;
                        }
                        else if (matches[0].Groups[4].Value == "Y")
                        {
                            mode = AddressMode.IZY;
                        }
                        else
                            throw new Exception(String.Format("Invalid register (%s) used with %s pnuemonic", operand2, pnuemonic));
                    }
                    else if (matches[0].Groups[1].Value != "")
                    {
                    }
                }
                else
                {
                    throw new Exception("Unknown addressing pattern");
                }

                Instruction? foundInstruction = instructions
                    .SingleOrDefault(i => i.Pnuemonic == code_parts[0] && i.Mode == mode);

                if(foundInstruction == null)
                    throw new Exception(String.Format("%s is not a valid pnuemonic", code_parts[0]));

                rv.Add(Convert.ToByte(foundInstruction?.Opcode));
                if (value.Length > 1)
                {
                    rv.Add(value[1]);
                    rv.Add(value[0]);
                }
                else
                    rv.Add(value[0]);
            }

            return rv.ToArray();
        }

        public static string[] Disassemble(byte[] machineCode, uint length)
        {
            var rv = new Collection<string>();

            int i = 0;
            do
            {
                byte opcode = machineCode[i++];
                Instruction instruction = instructions[opcode];

                //if (length < instruction.Length)
                //    throw new ArgumentOutOfRangeException("Memory length is less than the instruction length");

                string line = instruction.Pnuemonic;

                if (0 == String.Compare(line, "???", true))
                    throw new InvalidProgramException(String.Format("Unknown instruction opcode {0:X2}", opcode ));

                byte value = 0x00;
                byte lo = 0x00;
                byte hi = 0x00;

                switch (instruction.Mode)
                {
                    case AddressMode.ABS:
                        lo = machineCode[i++];
                        hi = machineCode[i++];
                        line += String.Format(" ${0:X4}", (hi << 8 + lo));
                        break;
                    case AddressMode.ABX:
                        lo = machineCode[i++];
                        hi = machineCode[i++];
                        line += String.Format(" ${0:X4},X", (hi << 8 + lo));
                        break;
                    case AddressMode.ABY:
                        lo = machineCode[i++];
                        hi = machineCode[i++];
                        line += String.Format(" ${0:X4},Y", (hi << 8 + lo));
                        break;
                    case AddressMode.ACC:
                        line += " A";
                        break;
                    case AddressMode.IMM:
                        value = machineCode[i++];
                        line += String.Format(" #${0:X2}", value);
                        break;
                    case AddressMode.IMP:
                        // implied addressmode are one byte operations, there should not be any data
                        break;
                    case AddressMode.IND:
                        lo = machineCode[i++];
                        hi = machineCode[i++];
                        line += String.Format(" (${0:X4})", (hi << 8) + lo);
                        break;
                    case AddressMode.IZX:
                        value = machineCode[i++];
                        line += String.Format(" (${0:X2},X)", value);
                        break;
                    case AddressMode.IZY:
                        value = machineCode[i++];
                        line += String.Format(" (${0:X2}),Y", value);
                        break;
                    case AddressMode.REL:
                        value = machineCode[i++];
                        line += String.Format(" ${0:X2}", value);
                        break;
                    case AddressMode.ZP0:
                        value = machineCode[i++];
                        line += String.Format(" ${0:X2}", value);
                        break;
                    case AddressMode.ZPX:
                        value = machineCode[i++];
                        line += String.Format(" ${0:X2},X", value);
                        break;
                    case AddressMode.ZPY:
                        value = machineCode[i++];
                        line += String.Format(" ${0:X2},Y", value);
                        break;
                    case AddressMode.XXX:
                        break;
                }
                while (i < instruction.Length) ;

                rv.Add(line);
            } while (i < length);
            
            return rv.ToArray();
        }

        public static byte[] ConvertToByteArray(string s)
        {
            byte[] data = new byte[s.Length / 2];

            for(int i = 0; i < data.Length; i++)
            {
                string byteValue = s.Substring(i * 2, 2);
                data[i] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }

        public static ReadOnlyCollection<Instruction> instructions;
    }
}
