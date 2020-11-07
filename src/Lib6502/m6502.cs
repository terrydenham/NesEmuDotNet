using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml.Schema;

namespace Lib6502
{
    [StructLayout(LayoutKind.Explicit, Size = 1, CharSet = CharSet.Ansi)]
    public struct CpuStatus
    {
        [FieldOffset(0)] public byte C;
        [FieldOffset(0)] public byte Z;
        [FieldOffset(0)] public byte I;
        [FieldOffset(0)] public byte D;
        [FieldOffset(0)] public byte U;
        [FieldOffset(0)] public byte B;
        [FieldOffset(0)] public byte O;
        [FieldOffset(0)] public byte N;
    }

    public struct CpuInstruction 
    {
        string Pnuemonic { get; }
        Func<byte> AddressMode { get; }
        Func<byte> Operation { get; }
        int Length { get; }
        int Cycles { get; }

        public CpuInstruction(string pnuemonic, Func<byte> addressMode, Func<byte> operation, int length, int cycles)
        {
            Pnuemonic = pnuemonic;
            AddressMode = addressMode;
            Operation = operation;
            Length = length;
            Cycles = cycles;
        }
    }
    public class m6502
    {
        public m6502(Memory memory)
        {

            instructions = new ReadOnlyCollection<CpuInstruction>(new[] {
    new CpuInstruction("BRK", this.IMP, this.BRK, 1, 7), new CpuInstruction("ORA", this.IZX, this.ORA, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("ORA", this.ZP0, this.ORA, 2, 3), new CpuInstruction("ASL", this.ZP0, this.ASL, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("PHP", this.IMP, this.PHP, 1, 3), new CpuInstruction("ORA", this.IMM, this.ORA, 2, 2), new CpuInstruction("ASL", this.ACC, this.ASL, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("ORA", this.ABS, this.ORA, 3, 4), new CpuInstruction("ASL", this.ABS, this.ASL, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BPL", this.REL, this.BPL, 2, 2), new CpuInstruction("ORA", this.IZY, this.ORA, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("ORA", this.ZPX, this.ORA, 2, 4), new CpuInstruction("ASL", this.ZPX, this.ASL, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CLC", this.IMP, this.CLC, 1, 2), new CpuInstruction("ORA", this.ABY, this.ORA, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("ORA", this.ABX, this.ORA, 3, 4), new CpuInstruction("ASL", this.ABX, this.ASL, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("JSR", this.ABS, this.JSR, 3, 6), new CpuInstruction("AND", this.IZX, this.AND, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("BIT", this.ZP0, this.BIT, 2, 3), new CpuInstruction("AND", this.ZP0, this.AND, 2, 3), new CpuInstruction("ROL", this.ZP0, this.ROL, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("PLP", this.IMP, this.PLP, 1, 4), new CpuInstruction("AND", this.IMM, this.AND, 2, 2), new CpuInstruction("ROL", this.ACC, this.ROL, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("BIT", this.ABS, this.BIT, 3, 4), new CpuInstruction("AND", this.ABS, this.AND, 3, 4), new CpuInstruction("ROL", this.ABS, this.ROL, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BMI", this.REL, this.BMI, 2, 2), new CpuInstruction("AND", this.IZY, this.AND, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("AND", this.ZPX, this.AND, 2, 4), new CpuInstruction("ROL", this.ZPX, this.ROL, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("SEC", this.IMP, this.SEC, 1, 2), new CpuInstruction("AND", this.ABY, this.AND, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("AND", this.ABX, this.AND, 3, 4), new CpuInstruction("ROL", this.ABX, this.ROL, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("RTI", this.IMP, this.RTI, 1, 6), new CpuInstruction("EOR", this.IZX, this.EOR, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("EOR", this.ZP0, this.EOR, 2, 3), new CpuInstruction("LSR", this.ZP0, this.LSR, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("PHA", this.IMP, this.PHA, 1, 3), new CpuInstruction("EOR", this.IMM, this.EOR, 2, 2), new CpuInstruction("LSR", this.ACC, this.LSR, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("JMP", this.ABS, this.JMP, 3, 3), new CpuInstruction("EOR", this.ABS, this.EOR, 3, 4), new CpuInstruction("LSR", this.ABS, this.LSR, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BVC", this.REL, this.BVC, 2, 2), new CpuInstruction("EOR", this.IZY, this.EOR, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("EOR", this.ZPX, this.EOR, 2, 4), new CpuInstruction("LSR", this.ZPX, this.LSR, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CLI", this.IMP, this.CLI, 1, 2), new CpuInstruction("EOR", this.ABY, this.EOR, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("EOR", this.ABX, this.EOR, 3, 4), new CpuInstruction("LSR", this.ABX, this.LSR, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("RTS", this.IMP, this.RTS, 1, 6), new CpuInstruction("ADC", this.IZX, this.ADC, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("ADC", this.ZP0, this.ADC, 2, 3), new CpuInstruction("ROR", this.ZP0, this.ROR, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("PLA", this.IMP, this.PLA, 1, 4), new CpuInstruction("ADC", this.IMM, this.ADC, 2, 2), new CpuInstruction("ROR", this.ACC, this.ROR, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("JMP", this.IND, this.JMP, 3, 5), new CpuInstruction("ADC", this.ABS, this.ADC, 3, 4), new CpuInstruction("ROR", this.ABS, this.ROR, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BVS", this.REL, this.BVS, 2, 2), new CpuInstruction("ADC", this.IZY, this.ADC, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("ADC", this.ZPX, this.ADC, 2, 4), new CpuInstruction("ROR", this.ZPX, this.ROR, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("SEI", this.IMP, this.SEI, 1, 2), new CpuInstruction("ADC", this.ABY, this.ADC, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("ADC", this.ABX, this.ADC, 3, 4), new CpuInstruction("ROR", this.ABX, this.ROR, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("STA", this.IZX, this.STA, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("STY", this.ZP0, this.STY, 2, 3), new CpuInstruction("STA", this.ZP0, this.STA, 2, 3), new CpuInstruction("STX", this.ZP0, this.STX, 2, 3), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("DEY", this.IMP, this.DEY, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("TXA", this.IMP, this.TXA, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("STY", this.ABS, this.STY, 3, 4), new CpuInstruction("STA", this.ABS, this.STA, 3, 4), new CpuInstruction("STX", this.ABS, this.STX, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BCC", this.REL, this.BCC, 2, 2), new CpuInstruction("STA", this.IZY, this.STA, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("STY", this.ZPX, this.STY, 2, 4), new CpuInstruction("STA", this.ZPX, this.STA, 2, 4), new CpuInstruction("STX", this.ZPX, this.STX, 2, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("TYA", this.IMP, this.TYA, 1, 2), new CpuInstruction("STA", this.ABY, this.STA, 3, 5), new CpuInstruction("TXS", this.IMP, this.TXS, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("STA", this.ABX, this.STA, 3, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("LDY", this.IMM, this.LDY, 2, 2), new CpuInstruction("LDA", this.IZX, this.LDA, 2, 6), new CpuInstruction("LDX", this.IMM, this.LDX, 2, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("LDY", this.ZP0, this.LDY, 2, 3), new CpuInstruction("LDA", this.ZP0, this.LDA, 2, 3), new CpuInstruction("LDX", this.ZP0, this.LDX, 2, 3), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("TAY", this.IMP, this.TAY, 1, 2), new CpuInstruction("LDA", this.IMM, this.LDA, 2, 2), new CpuInstruction("TAX", this.IMP, this.TAX, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("LDY", this.ABS, this.LDY, 3, 4), new CpuInstruction("LDA", this.ABS, this.LDA, 3, 4), new CpuInstruction("LDX", this.ABS, this.LDX, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BCS", this.REL, this.BCS, 2, 2), new CpuInstruction("LDA", this.IZY, this.LDA, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("LDY", this.ZPX, this.LDY, 2, 4), new CpuInstruction("LDA", this.ZPX, this.LDA, 2, 4), new CpuInstruction("LDX", this.ZPY, this.LDX, 2, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CLV", this.IMP, this.CLV, 1, 2), new CpuInstruction("LDA", this.ABY, this.LDA, 3, 4), new CpuInstruction("TSX", this.IMP, this.TSX, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("LDY", this.ABX, this.LDY, 3, 4), new CpuInstruction("LDA", this.ABX, this.LDA, 3, 4), new CpuInstruction("LDX", this.ABY, this.LDX, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("CPY", this.IMM, this.CPY, 2, 2), new CpuInstruction("CMP", this.IZX, this.CMP, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CPY", this.ZP0, this.CPY, 2, 3), new CpuInstruction("CMP", this.ZP0, this.CMP, 2, 3), new CpuInstruction("DEC", this.ZP0, this.DEC, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("INY", this.IMP, this.INY, 1, 2), new CpuInstruction("CMP", this.IMM, this.CMP, 2, 2), new CpuInstruction("DEC", this.IMP, this.DEC, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CPY", this.ABS, this.CPY, 3, 4), new CpuInstruction("CMP", this.ABS, this.CMP, 3, 4), new CpuInstruction("DEC", this.ABS, this.DEC, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BNE", this.REL, this.BNE, 2, 2), new CpuInstruction("CMP", this.IZY, this.CMP, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CMP", this.ZPX, this.CMP, 2, 4), new CpuInstruction("DEC", this.ZPX, this.DEC, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CLD", this.IMP, this.CLD, 1, 2), new CpuInstruction("CMP", this.ABY, this.CMP, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CMP", this.ABX, this.CMP, 3, 4), new CpuInstruction("DEC", this.ABX, this.DEC, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("CPX", this.IMM, this.CPX, 2, 2), new CpuInstruction("SBC", this.IZX, this.SBC, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CPX", this.ZP0, this.CPX, 2, 3), new CpuInstruction("SBC", this.ZP0, this.SBC, 2, 3), new CpuInstruction("INC", this.ZP0, this.INC, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("INX", this.IMP, this.INX, 1, 2), new CpuInstruction("SBC", this.IMM, this.SBC, 2, 2), new CpuInstruction("NOP", this.IMP, this.NOP, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CPX", this.ABS, this.CPX, 3, 4), new CpuInstruction("SBC", this.ABS, this.SBC, 3, 4), new CpuInstruction("INC", this.ABS, this.INC, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BEQ", this.REL, this.BEQ, 2, 2), new CpuInstruction("SBC", this.IZY, this.SBC, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("SBC", this.ZPX, this.SBC, 2, 4), new CpuInstruction("INC", this.ZPX, this.INC, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("SED", this.IMP, this.SED, 1, 2), new CpuInstruction("SBC", this.ABY, this.SBC, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("SBC", this.ABX, this.SBC, 3, 4), new CpuInstruction("INC", this.ABX, this.INC, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
            });

            bus = new Bus(memory);
        }

        public void Clock() 
        { 
            if(cycles == 0)
            {
                byte opcode = bus.Read(pc);
                CpuInstruction instruction = instructions[opcode];
            }
            else
            {
                cycles--;
            }
        }

        public void Reset() 
        {
            pc = 0xFFFF;
            sp = 0x0100;
            a = x = y = 0;
            status.B = status.C = status.D = status.I = status.N = status.O = status.U = status.Z = 0;
            cycles = 0;
        }

        public void Irq() { }

        public void Nmi() { }

        #region Cpu Flags
        public Boolean C
        {
            get { return status.C > 0; }
            protected set {
                if (value)
                    status.C = 1;
                else
                    status.C = 0;
            }
        }

        public Boolean Z
        {
            get { return status.Z > 0; }
            protected set
            {
                if (value)
                    status.Z = 1;
                else
                    status.Z = 0;
            }
        }

        public Boolean I
        {
            get { return status.I > 0; }
            protected set
            {
                if (value)
                    status.I = 1;
                else
                    status.I = 0;
            }
        }

        public Boolean D
        {
            get { return status.D > 0; }
            protected set
            {
                if (value)
                    status.D = 1;
                else
                    status.D = 0;
            }
        }

        public Boolean U
        {
            get { return status.U > 0; }
            protected set
            {
                if (value)
                    status.U = 1;
                else
                    status.U = 0;
            }
        }

        public Boolean B
        {
            get { return status.B > 0; }
            protected set
            {
                if (value)
                    status.B = 1;
                else
                    status.B = 0;
            }
        }

        public Boolean O
        {
            get { return status.O > 0; }
            protected set
            {
                if (value)
                    status.O = 1;
                else
                    status.O = 0;
            }
        }

        public Boolean N
        {
            get { return status.N > 0; }
            protected set
            {
                if (value)
                    status.N = 1;
                else
                    status.N = 0;
            }
        }
        #endregion

        #region Address Modes
        // Addressing Modes
        public byte ABS()
        {
            return (byte)0;
        }
        public byte ABX(){ return 0; } 
        public byte ABY(){ return 0; }
        public byte ACC(){ return 0; } 
        public byte IMM(){ return 0; } 
        public byte IMP(){ return 0; } 
        public byte IND(){ return 0; } 
        public byte IZX(){ return 0; }
        public byte IZY(){ return 0; } 
        public byte REL(){ return 0; } 
        public byte ZP0(){ return 0; } 
        public byte ZPX(){ return 0; }
        public byte ZPY(){ return 0; }

        // Invalid addressmode / opcode
        public byte XXX() { return 0; }

        #endregion

        #region Operations
        // Opcodes
        public byte ADC(){ return 0;} public byte AND(){ return 0;} public byte ASL(){ return 0;} public byte BCC(){ return 0;}
        public byte BCS(){ return 0;} public byte BEQ(){ return 0;} public byte BIT(){ return 0;} public byte BMI(){ return 0;}
        public byte BNE(){ return 0;} public byte BPL(){ return 0;} public byte BRK(){ return 0;} public byte BVC(){ return 0;}
        public byte BVS(){ return 0;} public byte CLC(){ return 0;} public byte CLD(){ return 0;} public byte CLI(){ return 0;}
        public byte CLV(){ return 0;} public byte CMP(){ return 0;} public byte CPX(){ return 0;} public byte CPY(){ return 0;}
        public byte DEC(){ return 0;} public byte DEY(){ return 0;} public byte EOR(){ return 0;}
        public byte INC(){ return 0;} public byte INX(){ return 0;} public byte INY(){ return 0;} public byte JMP(){ return 0;}
        public byte JSR(){ return 0;} public byte LDA(){ return 0;} public byte LDX(){ return 0;} public byte LDY(){ return 0;}
        public byte LSR(){ return 0;} public byte NOP(){ return 0;} public byte ORA(){ return 0;} public byte PHA(){ return 0;}
        public byte PHP(){ return 0;} public byte PLA(){ return 0;} public byte PLP(){ return 0;} public byte ROL(){ return 0;}
        public byte ROR(){ return 0;} public byte RTI(){ return 0;} public byte RTS(){ return 0;} public byte SBC(){ return 0;}
        public byte SEC(){ return 0;} public byte SED(){ return 0;} public byte SEI(){ return 0;} public byte STA(){ return 0;}
        public byte STX(){ return 0;} public byte STY(){ return 0;} public byte TAX(){ return 0;} public byte TAY(){ return 0;}
        public byte TSX(){ return 0;} public byte TXA(){ return 0;} public byte TXS(){ return 0;} public byte TYA(){ return 0;}
        #endregion

        protected ushort pc;
        protected ushort sp;
        protected byte a;
        protected byte x;
        protected byte y;
        protected CpuStatus status;
        protected ushort cycles;

        Bus bus;

        ReadOnlyCollection<CpuInstruction> instructions;

    }
}
