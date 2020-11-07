using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

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
        public int Length { get; }

        public Instruction(string pnuemonic, AddressMode mode, int length)
        {
            Pnuemonic = pnuemonic;
            Mode = mode;
            Length = length;
        }
    }

    public class Assembler
    {
        static Assembler()
        {

            instructions = new ReadOnlyCollection<Instruction>(new[] {
    new Instruction("BRK", AddressMode.IMP, 1), new Instruction("ORA", AddressMode.IZX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("ORA", AddressMode.ZP0, 2), new Instruction("ASL", AddressMode.ZP0, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("PHP", AddressMode.IMP, 1), new Instruction("ORA", AddressMode.IMM, 2), new Instruction("ASL", AddressMode.ACC, 1), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("ORA", AddressMode.ABS, 3), new Instruction("ASL", AddressMode.ABS, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("BPL", AddressMode.REL, 2), new Instruction("ORA", AddressMode.IZY, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("ORA", AddressMode.ZPX, 2), new Instruction("ASL", AddressMode.ZPX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("CLC", AddressMode.IMP, 1), new Instruction("ORA", AddressMode.ABY, 3), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("ORA", AddressMode.ABX, 3), new Instruction("ASL", AddressMode.ABX, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("JSR", AddressMode.ABS, 3), new Instruction("AND", AddressMode.IZX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("BIT", AddressMode.ZP0, 2), new Instruction("AND", AddressMode.ZP0, 2), new Instruction("ROL", AddressMode.ZP0, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("PLP", AddressMode.IMP, 1), new Instruction("AND", AddressMode.IMM, 2), new Instruction("ROL", AddressMode.ACC, 1), new Instruction("???", AddressMode.XXX, 0), new Instruction("BIT", AddressMode.ABS, 3), new Instruction("AND", AddressMode.ABS, 3), new Instruction("ROL", AddressMode.ABS, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("BMI", AddressMode.REL, 2), new Instruction("AND", AddressMode.IZY, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("AND", AddressMode.ZPX, 2), new Instruction("ROL", AddressMode.ZPX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("SEC", AddressMode.IMP, 1), new Instruction("AND", AddressMode.ABY, 3), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("AND", AddressMode.ABX, 3), new Instruction("ROL", AddressMode.ABX, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("RTI", AddressMode.IMP, 1), new Instruction("EOR", AddressMode.IZX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("EOR", AddressMode.ZP0, 2), new Instruction("LSR", AddressMode.ZP0, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("PHA", AddressMode.IMP, 1), new Instruction("EOR", AddressMode.IMM, 2), new Instruction("LSR", AddressMode.ACC, 1), new Instruction("???", AddressMode.XXX, 0), new Instruction("JMP", AddressMode.ABS, 3), new Instruction("EOR", AddressMode.ABS, 3), new Instruction("LSR", AddressMode.ABS, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("BVC", AddressMode.REL, 2), new Instruction("EOR", AddressMode.IZY, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("EOR", AddressMode.ZPX, 2), new Instruction("LSR", AddressMode.ZPX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("CLI", AddressMode.IMP, 1), new Instruction("EOR", AddressMode.ABY, 3), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("EOR", AddressMode.ABX, 3), new Instruction("LSR", AddressMode.ABX, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("RTS", AddressMode.IMP, 1), new Instruction("ADC", AddressMode.IZX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("ADC", AddressMode.ZP0, 2), new Instruction("ROR", AddressMode.ZP0, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("PLA", AddressMode.IMP, 1), new Instruction("ADC", AddressMode.IMM, 2), new Instruction("ROR", AddressMode.ACC, 1), new Instruction("???", AddressMode.XXX, 0), new Instruction("JMP", AddressMode.IND, 3), new Instruction("ADC", AddressMode.ABS, 3), new Instruction("ROR", AddressMode.ABS, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("BVS", AddressMode.REL, 2), new Instruction("ADC", AddressMode.IZY, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("ADC", AddressMode.ZPX, 2), new Instruction("ROR", AddressMode.ZPX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("SEI", AddressMode.IMP, 1), new Instruction("ADC", AddressMode.ABY, 3), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("ADC", AddressMode.ABX, 3), new Instruction("ROR", AddressMode.ABX, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("???", AddressMode.XXX, 0), new Instruction("STA", AddressMode.IZX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("STY", AddressMode.ZP0, 2), new Instruction("STA", AddressMode.ZP0, 2), new Instruction("STX", AddressMode.ZP0, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("DEY", AddressMode.IMP, 1), new Instruction("???", AddressMode.XXX, 0), new Instruction("TXA", AddressMode.IMP, 1), new Instruction("???", AddressMode.XXX, 0), new Instruction("STY", AddressMode.ABS, 3), new Instruction("STA", AddressMode.ABS, 3), new Instruction("STX", AddressMode.ABS, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("BCC", AddressMode.REL, 2), new Instruction("STA", AddressMode.IZY, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("STY", AddressMode.ZPX, 2), new Instruction("STA", AddressMode.ZPX, 2), new Instruction("STX", AddressMode.ZPX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("TYA", AddressMode.IMP, 1), new Instruction("STA", AddressMode.ABY, 3), new Instruction("TXS", AddressMode.IMP, 1), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("STA", AddressMode.ABX, 3), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("LDY", AddressMode.IMM, 2), new Instruction("LDA", AddressMode.IZX, 2), new Instruction("LDX", AddressMode.IMM, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("LDY", AddressMode.ZP0, 2), new Instruction("LDA", AddressMode.ZP0, 2), new Instruction("LDX", AddressMode.ZP0, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("TAY", AddressMode.IMP, 1), new Instruction("LDA", AddressMode.IMM, 2), new Instruction("TAX", AddressMode.IMP, 1), new Instruction("???", AddressMode.XXX, 0), new Instruction("LDY", AddressMode.ABS, 3), new Instruction("LDA", AddressMode.ABS, 3), new Instruction("LDX", AddressMode.ABS, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("BCS", AddressMode.REL, 2), new Instruction("LDA", AddressMode.IZY, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("LDY", AddressMode.ZPX, 2), new Instruction("LDA", AddressMode.ZPX, 2), new Instruction("LDX", AddressMode.ZPY, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("CLV", AddressMode.IMP, 1), new Instruction("LDA", AddressMode.ABY, 3), new Instruction("TSX", AddressMode.IMP, 1), new Instruction("???", AddressMode.XXX, 0), new Instruction("LDY", AddressMode.ABX, 3), new Instruction("LDA", AddressMode.ABX, 3), new Instruction("LDX", AddressMode.ABY, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("CPY", AddressMode.IMM, 2), new Instruction("CMP", AddressMode.IZX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("CPY", AddressMode.ZP0, 2), new Instruction("CMP", AddressMode.ZP0, 2), new Instruction("DEC", AddressMode.ZP0, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("INY", AddressMode.IMP, 1), new Instruction("CMP", AddressMode.IMM, 2), new Instruction("DEC", AddressMode.IMP, 1), new Instruction("???", AddressMode.XXX, 0), new Instruction("CPY", AddressMode.ABS, 3), new Instruction("CMP", AddressMode.ABS, 3), new Instruction("DEC", AddressMode.ABS, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("BNE", AddressMode.REL, 2), new Instruction("CMP", AddressMode.IZY, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("CMP", AddressMode.ZPX, 2), new Instruction("DEC", AddressMode.ZPX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("CLD", AddressMode.IMP, 1), new Instruction("CMP", AddressMode.ABY, 3), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("CMP", AddressMode.ABX, 3), new Instruction("DEC", AddressMode.ABX, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("CPX", AddressMode.IMM, 2), new Instruction("SBC", AddressMode.IZX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("CPX", AddressMode.ZP0, 2), new Instruction("SBC", AddressMode.ZP0, 2), new Instruction("INC", AddressMode.ZP0, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("INX", AddressMode.IMP, 1), new Instruction("SBC", AddressMode.IMM, 2), new Instruction("NOP", AddressMode.IMP, 1), new Instruction("???", AddressMode.XXX, 0), new Instruction("CPX", AddressMode.ABS, 3), new Instruction("SBC", AddressMode.ABS, 3), new Instruction("INC", AddressMode.ABS, 3), new Instruction("???", AddressMode.XXX, 0),
    new Instruction("BEQ", AddressMode.REL, 2), new Instruction("SBC", AddressMode.IZY, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("SBC", AddressMode.ZPX, 2), new Instruction("INC", AddressMode.ZPX, 2), new Instruction("???", AddressMode.XXX, 0), new Instruction("SED", AddressMode.IMP, 1), new Instruction("SBC", AddressMode.ABY, 3), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("???", AddressMode.XXX, 0), new Instruction("SBC", AddressMode.ABX, 3), new Instruction("INC", AddressMode.ABX, 3), new Instruction("???", AddressMode.XXX, 0),
});
        }

        public static byte[] Assemble(string[] codeLines) 
        {
            var rv = new Collection<byte>();

            foreach(string line in codeLines)
            {
                // break out comments from code
                string[] code_comment_parts = line.Split(';');


                string[] code_parts = code_comment_parts[0].Split(' ');

                foreach(string part in code_parts)
                {
                    
                }
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

        public static ReadOnlyCollection<Instruction> instructions;
    }
}
