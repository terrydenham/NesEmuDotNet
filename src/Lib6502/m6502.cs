using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml.Schema;

[assembly: InternalsVisibleToAttribute("Lib6502.Tests")]

namespace Lib6502
{
    [Flags]
    public enum CpuFlags
    {
        Empty = 0,
        C = 1,
        Z = 2,
        I = 4,
        D = 8,
        U = 16,
        B = 32,
        V = 64,
        N = 128
    }

    [StructLayout(LayoutKind.Explicit, Size = 1, CharSet = CharSet.Ansi)]
    public struct CpuStatus
    {
        [FieldOffset(0)] public byte C;
        [FieldOffset(1)] public byte Z;
        [FieldOffset(2)] public byte I;
        [FieldOffset(3)] public byte D;
        [FieldOffset(4)] public byte U;
        [FieldOffset(5)] public byte B;
        [FieldOffset(6)] public byte V;
        [FieldOffset(7)] public byte N;
    }

    public struct CpuInstruction
    {
        public string Mnemonic { get; }
        public Func<byte> AddressMode { get; }
        public Func<byte> Operation { get; }
        public int Length { get; }
        public byte Cycles { get; }


        public CpuInstruction(string mnemonic, Func<byte> addressMode, Func<byte> operation, int length, byte cycles)
        {
            Mnemonic = mnemonic;
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

            Instructions = new ReadOnlyCollection<CpuInstruction>(new[] {
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

            Reset();
        }

        internal void SetInitialState(CpuFlags initialState)
        {
            if ((initialState & CpuFlags.B) == CpuFlags.B)
                B = true;

            if ((initialState & CpuFlags.C) == CpuFlags.C)
                C = true;

            if ((initialState & CpuFlags.D) == CpuFlags.D)
                D = true;

            if ((initialState & CpuFlags.I) == CpuFlags.I)
                I = true;

            if ((initialState & CpuFlags.N) == CpuFlags.N)
                N = true;

            if ((initialState & CpuFlags.V) == CpuFlags.V)
                V = true;

            if ((initialState & CpuFlags.Z) == CpuFlags.Z)
                Z = true;

        }

        /// <summary>
        /// Called by the emulator to perform a clock cycle. The CPU emulator 
        /// is not clock specific to the 6502, but it does operate in a functional
        /// manner the same as the 6502.
        /// </summary>
        public void Clock()
        {
            if (Cycles == 0)
            {
                byte opcode = bus.Read(PC++);

                CpuInstruction instruction = Instructions[opcode];

                Cycles = instruction.Cycles;

                byte additionalCpuCyclesFromMemoryMode = instruction.AddressMode();
                byte additionalCpuCyclesFromOperation = instruction.Operation();

                Cycles += (byte)(additionalCpuCyclesFromMemoryMode & additionalCpuCyclesFromOperation);

            }
         
            Cycles--;
        }

        public void Reset() 
        {
            PC = 0x100;
            SP = 0xFF;
            A = X = Y = 0;
            status.B = status.C = status.D = status.I = status.N = status.V = status.U = status.Z = 0;
            Cycles = 0;
            Flags = CpuFlags.Empty;
        }

        public void Irq() { }

        public void Nmi() { }

        #region Cpu Flags
        public Boolean C
        {
            get { return status.C > 0; }
            protected set {
                if (value)
                {
                    status.C = 1;
                    Flags |= CpuFlags.C;
                }
                else
                {
                    status.C = 0;
                    Flags &= ~CpuFlags.C;
                }
            }
        }

        public Boolean Z
        {
            get { return status.Z > 0; }
            protected set
            {
                if (value)
                {
                    status.Z = 1;
                    Flags |= CpuFlags.Z;
                }
                else
                {
                    status.Z = 0;
                    Flags &= ~CpuFlags.Z;
                }
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

        public Boolean V
        {
            get { return status.V > 0; }
            protected set
            {
                if (value)
                    status.V = 1;
                else
                    status.V = 0;
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

        /// <summary>
        /// Program counter, the current memory position of the next byte read
        /// </summary>
        public ushort PC { get; protected set; }

        /// <summary>
        /// The current stack pointer
        /// </summary>
        public byte SP { get; protected set; }

        /// <summary>
        /// The A register, or accumulator
        /// </summary>
        public byte A { get; internal set; }
        
        /// <summary>
        /// The X register. A general purpose register typically used for indexing
        /// </summary>
        public byte X { get; internal set; }

        /// <summary>
        /// The Y register. A general purpose register.
        /// </summary>
        public byte Y { get; internal set; }

        /// <summary>
        /// The number of CPU cycles remaining after the current instruction is executed.
        /// </summary>
        /// <remarks>Cycles are decreased when the <see cref="Clock"/> method is called.</remarks>
        public byte Cycles { get; protected set; }

        /// <summary>
        /// CPU flags represented as an enumeration
        /// </summary>
        public CpuFlags Flags { get; protected set; }


        public ReadOnlyCollection<CpuInstruction> Instructions { get; protected set; }

        #region Address Modes
        // Addressing Modes
        /// <summary>
        /// Absolute addressing mode using the next two bytes after the opcode. 
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte ABS()
        {
            var lo = Read(PC);
            PC++;
            var hi = Read(PC);
            PC++;

            addr_abs = (ushort)((hi << 8) + lo);

            fetched = Read(addr_abs);

            return 0;
        }

        /// <summary>
        /// Absolute memory address using the value in the X register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte ABX()
        {
            var lo = Read(PC);
            PC++;
            var hi = Read(PC);
            PC++;

            addr_abs = (ushort)((hi << 8) + lo + X) ;

            fetched = Read(addr_abs);

            return 1;
        }

        /// <summary>
        /// Absolute memory address using the value in the Y register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte ABY()
        {
            var lo = Read(PC);
            PC++;
            var hi = Read(PC);
            PC++;

            addr_abs = (ushort)((hi << 8) + lo + Y);

            fetched = Read(addr_abs);

            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte ACC()
        {
            fetched = A;
            return 0;
        }

        /// <summary>
        /// Immediate addressing mode
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte IMM()
        {
            addr_abs = PC;
            addr_rel = 0;

            fetched = Read(addr_abs);

            return 0; 
        }

        /// <summary>
        /// Implied addressing mode
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte IMP()
        {
            fetched = A;
            
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte IND()
        { 
            return 0; 
        }

        /// <summary>
        /// Indirect Zero Page with X offset
        /// </summary>
        /// <remarks>Uses the zero page as a table of offsets, with the address specified
        /// as the starting address with the X register containing the offset within the table</remarks>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte IZX()
        {
            byte b = Read(PC);
            byte pointerLo = (byte)(b + X);
            byte pointerHi = (byte)(b + X + 1);

            byte lo = Read((ushort)pointerLo);
            byte hi = Read((ushort)pointerHi);

            addr_abs = (ushort)((hi << 8) + lo);

            fetched = Read(addr_abs);

            PC++;

            return 0; 
        }

        /// <summary>
        /// Indirect Zero Page with Y offset
        /// </summary>
        /// <remarks>Uses the zero page as a table of offsets, with the address specified
        /// as the starting address with the Y register containing the offset within the table</remarks>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte IZY()
        {
            byte b = Read(PC);
            byte pointerLo = (byte)(b + Y);
            byte pointerHi = (byte)(b + Y + 1);

            byte lo = Read((ushort)pointerLo);
            byte hi = Read((ushort)pointerHi);

            addr_abs = (ushort)((hi << 8) + lo);

            fetched = Read(addr_abs);

            PC++;
            // TODO : figure out if the addr_abs is not on the same page. This would 
            // mean we need additional CPU cycles.
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte REL()
        {
            addr_abs = Read(PC);
            PC++;
            // if the address high order bit is set, then this is a negative offset
            if ((addr_abs & 0x80) == 0x80)
                addr_abs |= 0xFF00;

            return 0; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte ZP0()
        {
            addr_abs = Read(PC);
            PC++;
            addr_abs &= 0x00FF;

            fetched = Read(addr_abs);

            return 0; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte ZPX()
        {
            addr_abs = (ushort)(Read(PC) + X);
            PC++;
            addr_abs &= 0x00FF;

            fetched = Read(addr_abs);

            return 0; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte ZPY()
        {
            addr_abs = (ushort)(Read(PC) + Y);
            PC++;
            addr_abs &= 0x00FF;

            fetched = Read(addr_abs);

            return 0;
        }

        /// <summary>
        /// Invalid addressing mode / operation mode
        /// </summary>
        /// <remarks>Within the CPU instructions member, we make sure we have 255 opcodes, even though not all 
        /// combinations of major / minor hex values are used. For these "missing" instructions, we map the
        /// instruction for both addressing mode function pointer and the operation function pointer
        /// to this function.</remarks>
        /// <returns>Zero</returns>
        public byte XXX() { return 0; }

        #endregion

        #region Operations
        // Opcodes
        /// <summary>
        /// Add the next byte with the accumulator
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte ADC()
        {
            Int16 newValue = A;
            newValue += fetched;

            if (newValue == 0)
                Z = true;

            if (newValue < 0)
                N = true;

            if (newValue > 0xFF)
            {
                V = true;
                C = true;
            }

            A = (byte)newValue;

            return 1;
        }

        /// <summary>
        /// Performs a bitwise AND operation with the accumulator
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte AND()
        {
            A = (byte)(A & fetched);
            Z = A == 0x00;
            N = (bool)((byte)(A & 0x80) == 0x80);
            
            // AND has the possible outcoming of needing extra cpu cycles based on the address mode
            return 1;
        }

        /// <summary>
        /// Performs an arithmatic shift left. The most significant digit is copied to the
        /// Carry bit.
        /// </summary>
        /// <returns></returns>
        public byte ASL()
        {
            C = (fetched & 0x80) == 0x80;
            
            fetched = (byte)(fetched << 1);

            N = (fetched & 0x80) == 0x80;
            Z = fetched == 0;

            A = fetched;

            return 0;
        } 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte BCC(){ return 0;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte BCS(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte BEQ(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte BIT(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte BMI(){ return 0;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte BNE(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte BPL(){ return 0;}

        /// <summary>
        /// Performs a BReaK
        /// </summary>
        /// <returns></returns>
        public byte BRK() 
        {
            PC++;
            B = true;

            return 0; 
        } 

        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte BVC(){ return 0;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte BVS(){ return 0;}
        
        /// <summary>
        /// Clear the Carry CPU flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte CLC()
        {
            C = false;

            // this operation requires no additional CPU cycles
            return 0;
        } 

        /// <summary>
        /// Clear the Decimal CPU flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte CLD()
        {
            D = false;

            // this operation requires no additional CPU cycles
            return 0;
        }
        
        /// <summary>
        /// Clear the Interrupt flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte CLI()
        {
            I = false;

            return 0;
        }

        /// <summary>
        /// Clear the Overflow CPU flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte CLV()
        {
            V = false;

            return 0;
        } 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte CMP(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte CPX(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte CPY(){ return 0;}

        /// <summary>
        /// Decrement by one the given memory address, based on the addressing mode
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte DEC(){ return 0;}

        /// <summary>
        /// Decrement by one the value in the X register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte DEX()
        {
            return 0;
        }

        /// <summary>
        /// Decrement by one the value in the Y register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte DEY(){ return 0;} 

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte EOR(){ return 0;}

        /// <summary>
        /// Increment the value in the A register
        /// </summary>
        /// <returns></returns>
        public byte INC(){ return 0;}

        /// <summary>
        /// Increment by one the value stored in the X register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte INX()
        {
            X++;

            return 0;
        } 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte INY(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte JMP(){ return 0;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte JSR(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte LDA(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte LDX(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte LDY(){ return 0;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte LSR(){ return 0;}
        
        /// <summary>
        /// Perform a no-op, or non-operation
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte NOP(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte ORA(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte PHA(){ return 0;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte PHP(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte PLA(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte PLP(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte ROL(){ return 0;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte ROR(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte RTI(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte RTS(){ return 0;} 
        
        /// <summary>
        /// Subtract with Carry
        /// </summary>
        /// <returns></returns>
        public byte SBC()
        {
            Int16 newValue = A;
            newValue -= fetched;

            if (newValue == 0)
                Z = true;

            if (newValue < 0)
                N = true;

            if (newValue > 0xFF)
            {
                V = true;
                C = true;
            }

            A = (byte)newValue;

            return 1;
        }

        /// <summary>
        /// Sets the Clear flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte SEC()
        {
            C = true;

            return 0;
        }
        
        /// <summary>
        /// Sets the Decimal flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte SED()
        {
            D = true;
            return 0;
        }
        
        /// <summary>
        /// Sets the Interrupt flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte SEI()
        {
            I = true;
            return 0;
        }
        
        /// <summary>
        /// Store the next byte read into the A register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte STA()
        { 
            return 0;
        }
        
        /// <summary>
        /// Store the next byte read into the X register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte STX()
        { 
            return 0;
        }
        
        /// <summary>
        /// Store the next byte read into the Y register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        public byte STY()
        { 
            return 0;
        } 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte TAX(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte TAY(){ return 0;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte TSX(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte TXA(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte TXS(){ return 0;} 
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte TYA(){ return 0;}
        #endregion

        byte Read(ushort address)
        {
            return bus.Read(address);
        }

        void Write(ushort address, byte data)
        {
            bus.Write(address, data);
        }

        /// <summary>
        /// Read the next byte from the program counter and advance the program counter
        /// </summary>
        protected void Fetch() 
        {
            if (addr_abs != 0)
                fetched = bus.Read(addr_abs);
            else if (addr_rel != 0)
                fetched = bus.Read(addr_rel);
            else
                fetched = bus.Read(PC++);
        }

        internal void Run()
        {
            do
            {
                Clock();
            } while (Cycles > 0);
        }

        //protected ushort pc;        // program counter
        //protected ushort sp;        // stack pointer
        //protected byte a;           // accumulator
        //protected byte x;           // x register
        //protected byte y;           // y register
        protected CpuStatus status; // cpu status flags
        // protected byte cycles;    // the number of remaining cpu cycles
        protected byte opcode;      // the current opcode being executed
        protected byte fetched;     // the byte recently fetched() 
        protected ushort addr_abs;  // absolute address reference
        protected ushort addr_rel;  // relative address reference
        protected Bus bus;

//        protected ReadOnlyCollection<CpuInstruction> instructions;

    }
}
