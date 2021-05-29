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
        C = (1 << 0),
        Z = (1 << 1),
        I = (1 << 2),
        D = (1 << 3),
        B = (1 << 4),
        U = (1 << 5),
        V = (1 << 6),
        N = (1 << 7),
        All = C | Z | I | D | B | U | V | N
    }

    //[StructLayout(LayoutKind.Explicit, Size = 1, CharSet = CharSet.Ansi)]
    //public struct CpuStatus
    //{
    //    [FieldOffset(0)] public byte C;
    //    [FieldOffset(1)] public byte Z;
    //    [FieldOffset(2)] public byte I;
    //    [FieldOffset(3)] public byte D;
    //    [FieldOffset(4)] public byte U;
    //    [FieldOffset(5)] public byte B;
    //    [FieldOffset(6)] public byte V;
    //    [FieldOffset(7)] public byte N;
    //}

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memory"></param>
        /// <param name="debugStream"></param>
        public m6502(Memory memory, System.IO.StreamWriter debugStream = null)
        {
            this.debugStream = debugStream;

            Instructions = new ReadOnlyCollection<CpuInstruction>(new[] {
    new CpuInstruction("BRK", this.A_IMP, this.BRK, 1, 7), new CpuInstruction("ORA", this.A_IZX, this.ORA, 2, 6), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("ORA", this.A_ZP0, this.ORA, 2, 3), new CpuInstruction("ASL", this.A_ZP0, this.ASL, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("PHP", this.A_IMP, this.PHP, 1, 3), new CpuInstruction("ORA", this.A_IMM, this.ORA, 2, 2), new CpuInstruction("ASL", this.A_ACC, this.ASL, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("ORA", this.A_ABS, this.ORA, 3, 4), new CpuInstruction("ASL", this.A_ABS, this.ASL, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BPL", this.A_REL, this.BPL, 2, 2), new CpuInstruction("ORA", this.A_IZY, this.ORA, 2, 5), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("ORA", this.A_ZPX, this.ORA, 2, 4), new CpuInstruction("ASL", this.A_ZPX, this.ASL, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CLC", this.A_IMP, this.CLC, 1, 2), new CpuInstruction("ORA", this.A_ABY, this.ORA, 3, 4), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("ORA", this.A_ABX, this.ORA, 3, 4), new CpuInstruction("ASL", this.A_ABX, this.ASL, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("JSR", this.A_ABS, this.JSR, 3, 6), new CpuInstruction("AND", this.A_IZX, this.AND, 2, 6), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("BIT", this.A_ZP0, this.BIT, 2, 3), new CpuInstruction("AND", this.A_ZP0, this.AND, 2, 3), new CpuInstruction("ROL", this.A_ZP0, this.ROL, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("PLP", this.A_IMP, this.PLP, 1, 4), new CpuInstruction("AND", this.A_IMM, this.AND, 2, 2), new CpuInstruction("ROL", this.A_ACC, this.ROL, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("BIT", this.A_ABS, this.BIT, 3, 4), new CpuInstruction("AND", this.A_ABS, this.AND, 3, 4), new CpuInstruction("ROL", this.A_ABS, this.ROL, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BMI", this.A_REL, this.BMI, 2, 2), new CpuInstruction("AND", this.A_IZY, this.AND, 2, 5), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("AND", this.A_ZPX, this.AND, 2, 4), new CpuInstruction("ROL", this.A_ZPX, this.ROL, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("SEC", this.A_IMP, this.SEC, 1, 2), new CpuInstruction("AND", this.A_ABY, this.AND, 3, 4), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("AND", this.A_ABX, this.AND, 3, 4), new CpuInstruction("ROL", this.A_ABX, this.ROL, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("RTI", this.A_IMP, this.RTI, 1, 6), new CpuInstruction("EOR", this.A_IZX, this.EOR, 2, 6), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("EOR", this.A_ZP0, this.EOR, 2, 3), new CpuInstruction("LSR", this.A_ZP0, this.LSR, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("PHA", this.A_IMP, this.PHA, 1, 3), new CpuInstruction("EOR", this.A_IMM, this.EOR, 2, 2), new CpuInstruction("LSR", this.A_ACC, this.LSR, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("JMP", this.A_ABS, this.JMP, 3, 3), new CpuInstruction("EOR", this.A_ABS, this.EOR, 3, 4), new CpuInstruction("LSR", this.A_ABS, this.LSR, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BVC", this.A_REL, this.BVC, 2, 2), new CpuInstruction("EOR", this.A_IZY, this.EOR, 2, 5), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("EOR", this.A_ZPX, this.EOR, 2, 4), new CpuInstruction("LSR", this.A_ZPX, this.LSR, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CLI", this.A_IMP, this.CLI, 1, 2), new CpuInstruction("EOR", this.A_ABY, this.EOR, 3, 4), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("EOR", this.A_ABX, this.EOR, 3, 4), new CpuInstruction("LSR", this.A_ABX, this.LSR, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("RTS", this.A_IMP, this.RTS, 1, 6), new CpuInstruction("ADC", this.A_IZX, this.ADC, 2, 6), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("ADC", this.A_ZP0, this.ADC, 2, 3), new CpuInstruction("ROR", this.A_ZP0, this.ROR, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("PLA", this.A_IMP, this.PLA, 1, 4), new CpuInstruction("ADC", this.A_IMM, this.ADC, 2, 2), new CpuInstruction("ROR", this.A_ACC, this.ROR, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("JMP", this.A_IND, this.JMP, 3, 5), new CpuInstruction("ADC", this.A_ABS, this.ADC, 3, 4), new CpuInstruction("ROR", this.A_ABS, this.ROR, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BVS", this.A_REL, this.BVS, 2, 2), new CpuInstruction("ADC", this.A_IZY, this.ADC, 2, 5), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("ADC", this.A_ZPX, this.ADC, 2, 4), new CpuInstruction("ROR", this.A_ZPX, this.ROR, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("SEI", this.A_IMP, this.SEI, 1, 2), new CpuInstruction("ADC", this.A_ABY, this.ADC, 3, 4), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("ADC", this.A_ABX, this.ADC, 3, 4), new CpuInstruction("ROR", this.A_ABX, this.ROR, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("STA", this.A_IZX, this.STA, 2, 6), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("STY", this.A_ZP0, this.STY, 2, 3), new CpuInstruction("STA", this.A_ZP0, this.STA, 2, 3), new CpuInstruction("STX", this.A_ZP0, this.STX, 2, 3), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("DEY", this.A_IMP, this.DEY, 1, 2), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("TXA", this.A_IMP, this.TXA, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("STY", this.A_ABS, this.STY, 3, 4), new CpuInstruction("STA", this.A_ABS, this.STA, 3, 4), new CpuInstruction("STX", this.A_ABS, this.STX, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BCC", this.A_REL, this.BCC, 2, 2), new CpuInstruction("STA", this.A_IZY, this.STA, 2, 6), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("STY", this.A_ZPX, this.STY, 2, 4), new CpuInstruction("STA", this.A_ZPX, this.STA, 2, 4), new CpuInstruction("STX", this.A_ZPX, this.STX, 2, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("TYA", this.A_IMP, this.TYA, 1, 2), new CpuInstruction("STA", this.A_ABY, this.STA, 3, 5), new CpuInstruction("TXS", this.A_IMP, this.TXS, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("STA", this.A_ABX, this.STA, 3, 5), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("LDY", this.A_IMM, this.LDY, 2, 2), new CpuInstruction("LDA", this.A_IZX, this.LDA, 2, 6), new CpuInstruction("LDX", this.A_IMM, this.LDX, 2, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("LDY", this.A_ZP0, this.LDY, 2, 3), new CpuInstruction("LDA", this.A_ZP0, this.LDA, 2, 3), new CpuInstruction("LDX", this.A_ZP0, this.LDX, 2, 3), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("TAY", this.A_IMP, this.TAY, 1, 2), new CpuInstruction("LDA", this.A_IMM, this.LDA, 2, 2), new CpuInstruction("TAX", this.A_IMP, this.TAX, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("LDY", this.A_ABS, this.LDY, 3, 4), new CpuInstruction("LDA", this.A_ABS, this.LDA, 3, 4), new CpuInstruction("LDX", this.A_ABS, this.LDX, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BCS", this.A_REL, this.BCS, 2, 2), new CpuInstruction("LDA", this.A_IZY, this.LDA, 2, 5), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("LDY", this.A_ZPX, this.LDY, 2, 4), new CpuInstruction("LDA", this.A_ZPX, this.LDA, 2, 4), new CpuInstruction("LDX", this.A_ZPY, this.LDX, 2, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CLV", this.A_IMP, this.CLV, 1, 2), new CpuInstruction("LDA", this.A_ABY, this.LDA, 3, 4), new CpuInstruction("TSX", this.A_IMP, this.TSX, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("LDY", this.A_ABX, this.LDY, 3, 4), new CpuInstruction("LDA", this.A_ABX, this.LDA, 3, 4), new CpuInstruction("LDX", this.A_ABY, this.LDX, 3, 4), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("CPY", this.A_IMM, this.CPY, 2, 2), new CpuInstruction("CMP", this.A_IZX, this.CMP, 2, 5), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CPY", this.A_ZP0, this.CPY, 2, 3), new CpuInstruction("CMP", this.A_ZP0, this.CMP, 2, 3), new CpuInstruction("DEC", this.A_ZP0, this.DEC, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("INY", this.A_IMP, this.INY, 1, 2), new CpuInstruction("CMP", this.A_IMM, this.CMP, 2, 2), new CpuInstruction("DEC", this.A_IMP, this.DEC, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CPY", this.A_ABS, this.CPY, 3, 4), new CpuInstruction("CMP", this.A_ABS, this.CMP, 3, 4), new CpuInstruction("DEC", this.A_ABS, this.DEC, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BNE", this.A_REL, this.BNE, 2, 2), new CpuInstruction("CMP", this.A_IZY, this.CMP, 2, 5), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("CMP", this.A_ZPX, this.CMP, 2, 4), new CpuInstruction("DEC", this.A_ZPX, this.DEC, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CLD", this.A_IMP, this.CLD, 1, 2), new CpuInstruction("CMP", this.A_ABY, this.CMP, 3, 4), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("CMP", this.A_ABX, this.CMP, 3, 4), new CpuInstruction("DEC", this.A_ABX, this.DEC, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("CPX", this.A_IMM, this.CPX, 2, 2), new CpuInstruction("SBC", this.A_IZX, this.SBC, 2, 6), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CPX", this.A_ZP0, this.CPX, 2, 3), new CpuInstruction("SBC", this.A_ZP0, this.SBC, 2, 3), new CpuInstruction("INC", this.A_ZP0, this.INC, 2, 5), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("INX", this.A_IMP, this.INX, 1, 2), new CpuInstruction("SBC", this.A_IMM, this.SBC, 2, 2), new CpuInstruction("NOP", this.A_IMP, this.NOP, 1, 2), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("CPX", this.A_ABS, this.CPX, 3, 4), new CpuInstruction("SBC", this.A_ABS, this.SBC, 3, 4), new CpuInstruction("INC", this.A_ABS, this.INC, 3, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
    new CpuInstruction("BEQ", this.A_REL, this.BEQ, 2, 2), new CpuInstruction("SBC", this.A_IZY, this.SBC, 2, 5), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("SBC", this.A_ZPX, this.SBC, 2, 4), new CpuInstruction("INC", this.A_ZPX, this.INC, 2, 6), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("SED", this.A_IMP, this.SED, 1, 2), new CpuInstruction("SBC", this.A_ABY, this.SBC, 3, 4), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("???", this.XXX, this.XXX, 0, 0), new CpuInstruction("???", this.XXX  , this.XXX, 0, 0), new CpuInstruction("SBC", this.A_ABX, this.SBC, 3, 4), new CpuInstruction("INC", this.A_ABX, this.INC, 3, 7), new CpuInstruction("???", this.XXX, this.XXX, 0, 0),
            });

            bus = new Bus(memory);

            Reset();
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
                // increment the program counter after reading 
                // the instruction at the current program counter location
                byte opcode = bus.Read(PC++);

#if OPTIMIZE_CLOCK
                Cycles += ExecuteOpCode(opcode);
#else
                // lookup the CpuInstruction by the opcode
                CpuInstruction instruction = Instructions[opcode];

                // the cpu instruction default clock cycles before considering address mode
                Cycles = instruction.Cycles;

                byte additionalCpuCyclesFromMemoryMode = instruction.AddressMode();
                byte additionalCpuCyclesFromOperation = instruction.Operation();

                Cycles += (byte)(additionalCpuCyclesFromMemoryMode & additionalCpuCyclesFromOperation);

                if (useAccumulator)
                {
                    A = fetched;
                    useAccumulator = false;
                }
#endif
            }
         
            Cycles--;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Reset() 
        {
            PC = 0x200;
            SP = 0x1FF;
            A = X = Y = 0;
            Status = CpuFlags.Empty;
            Cycles = 0;
            useAccumulator = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Irq() { }

        /// <summary>
        /// 
        /// </summary>
        public void Nmi() { }

        #region Cpu Flags
        public Boolean C
        {
            get { return (Status & CpuFlags.C) != 0; }
            protected set
            {
                if (value)
                    Status |= CpuFlags.C;
                else
                    Status &= ~CpuFlags.C;
            }
        }

        public Boolean Z
        {
            get { return (Status & CpuFlags.Z) != 0; }
            protected set
            {
                if (value)
                    Status |= CpuFlags.Z;
                else
                    Status &= ~CpuFlags.Z;
            }
        }

        public Boolean I
        {
            get { return (Status & CpuFlags.I) != 0; }
            protected set
            {
                if (value)
                    Status |= CpuFlags.I;
                else
                    Status &= ~CpuFlags.I;
            }
        }

        public Boolean D
        {
            get { return (Status & CpuFlags.D) != 0; }
            protected set
            {
                if (value)
                    Status |= CpuFlags.D;
                else
                    Status &= ~CpuFlags.D;
            }
        }

        public Boolean U
        {
            get { return (Status & CpuFlags.U) != 0; }
            protected set
            {
                if (value)
                    Status |= CpuFlags.U;
                else
                    Status &= ~CpuFlags.U;
            }
        }

        public Boolean B
        {
            get { return (Status & CpuFlags.B) != 0; }
            protected set
            {
                if (value)
                    Status |= CpuFlags.B;
                else
                    Status &= ~CpuFlags.B;
            }
        }

        public Boolean V
        {
            get { return (Status & CpuFlags.V) != 0; }
            protected set
            {
                if (value)
                    Status |= CpuFlags.V;
                else
                    Status &= ~CpuFlags.V;
            }
        }

        public Boolean N
        {
            get { return (Status & CpuFlags.N) != 0; }
            protected set
            {
                if (value)
                    Status |= CpuFlags.N;
                else
                    Status &= ~CpuFlags.N;
            }
        }
        #endregion

        /// <summary>
        /// Program counter, the current memory position of the next byte read
        /// </summary>
        public ushort PC { get; internal set; }

        /// <summary>
        /// The current stack pointer
        /// </summary>
        public ushort SP { get; internal set; }

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
        public CpuFlags Status { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyCollection<CpuInstruction> Instructions { get; protected set; }

        #region Address Modes
        // Addressing Modes
        /// <summary>
        /// Absolute addressing mode using the next two bytes after the opcode. 
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>

        internal virtual byte A_ABS()
        {
            var lo = Read(PC);
            PC++;
            var hi = Read(PC);
            PC++;

            addr_abs = (ushort)((hi << 8) + lo);

            fetched = Read(addr_abs);

            return 2;
        }

        /// <summary>
        /// Absolute memory address using the value in the X register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte A_ABX()
        {
            var lo = Read(PC);
            PC++;
            var hi = Read(PC);
            PC++;

            addr_abs = (ushort)((hi << 8) + lo + X) ;

            fetched = Read(addr_abs);

            byte rv = 0;

            // if the referenced address is not on the same page as the current program counter
            if (!AreOnSamePage())
                rv++;

            return rv;
        }

        /// <summary>
        /// Absolute memory address using the value in the Y register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte A_ABY()
        {
            var lo = Read(PC);
            PC++;
            var hi = Read(PC);
            PC++;

            addr_abs = (ushort)((hi << 8) + lo + Y);

            fetched = Read(addr_abs);

            byte rv = 0;

            // if the referenced address is not on the same page as the current program counter
            if (!AreOnSamePage())
                rv++;

            return rv;
        }

        /// <summary>
        /// Accumulator address mode. Read the value from the Accumulator
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte A_ACC()
        {
            fetched = A;

            return 0;
        }

        /// <summary>
        /// Immediate addressing mode
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte A_IMM()
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
        internal virtual byte A_IMP()
        {
            fetched = A;
            
            return 0;
        }

        /// <summary>
        /// Indirect address mode. 
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte A_IND()
        {
            byte pointerLo = Read(PC++);
            byte pointerHi = Read(PC++);

            ushort pointerAddr = (ushort)((pointerHi << 8) + pointerLo);

            byte lo = Read(pointerAddr);
            byte hi = Read((ushort)(pointerAddr + 1));

            addr_abs = (ushort)((hi << 8) + lo);

            fetched = Read(addr_abs);

            return 0; 
        }

        /// <summary>
        /// Indirect Zero Page with X offset
        /// </summary>
        /// <remarks>Uses the zero page as a table of offsets, with the address specified
        /// as the starting address with the X register containing the offset within the table</remarks>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte A_IZX()
        {
            byte b = Read(PC);

            byte pointerLo = (byte)(b + X);
            byte pointerHi = (byte)(b + X + 1);

            byte lo = Read((ushort)pointerLo);
            byte hi = Read((ushort)pointerHi);

            addr_abs = (ushort)((hi << 8) + lo);

            fetched = Read(addr_abs);

            PC++;

            //byte rv = 0;
            //if (!AreOnSamePage())
            //    rv++;

            return 0; 
        }

        /// <summary>
        /// Indirect Zero Page with Y offset
        /// </summary>
        /// <remarks>Uses the zero page as a table of offsets, with the address specified
        /// as the starting 16-bit address with the Y register containing the offset</remarks>
        /// <example>ADC ($86),Y
        /// The processor reads the $86 address as a location within Zero Page, and reads the
        /// following byte to arrive at a 16bit address. This is added with the Y register
        /// to arrive at the final address
        /// </example>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte A_IZY()
        {
            byte baseAddr = Read(PC);

            byte pointerLo = Read(baseAddr);
            byte pointerHi = Read((ushort)(baseAddr + 1));

            addr_abs = (ushort)((pointerHi << 8) + (pointerLo + Y));

            fetched = Read(addr_abs);

            PC++;

            byte rv = 0;
            if (!AreOnSamePage())
                rv++;

            return rv;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte A_REL()
        {
            sbyte lo = (sbyte)(Read(PC));
            
            if ((lo & 0x80) == 0x80)
                addr_abs = (ushort)(PC - lo);
            else
                addr_abs = (ushort)(PC + lo);

            PC++;

            // if the address high order bit is set, then this is a negative offset
            //if ((addr_abs & 0x80) == 0x80)
            //    addr_abs |= 0xFF00;

            byte rv = 0;
            if (!AreOnSamePage())
                rv++;

            return rv;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte A_ZP0()
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
        internal virtual byte A_ZPX()
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
        internal virtual byte A_ZPY()
        {
            addr_abs = (ushort)(Read(PC) + Y);
            PC++;
            addr_abs &= 0x00FF;

            fetched = Read(addr_abs);

            byte rv = 3;

            if (!AreOnSamePage())
                rv++;

            return rv;
        }

        /// <summary>
        /// Invalid addressing mode / operation mode
        /// </summary>
        /// <remarks>Within the CPU instructions member, we make sure we have 255 opcodes, even though not all 
        /// combinations of major / minor hex values are used. For these "missing" instructions, we map the
        /// instruction for both addressing mode function pointer and the operation function pointer
        /// to this function.</remarks>
        /// <returns>Zero</returns>
        internal byte XXX() { return 0; }

        #endregion

        #region Operations
        // Opcodes
        /// <summary>
        /// Add the next byte with the accumulator
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte ADC()
        {
            Int32 newValue = A;
            newValue += fetched;
            newValue += (C ? 1 : 0);

            Z = (byte)newValue == 0x00;

            N = (newValue & 0b_1000_0000) == 0b_1000_0000;

            C = (newValue & 0x100) == 0x100;

            A = (byte)newValue;

            return 1;
        }

        /// <summary>
        /// Performs a bitwise AND operation with the accumulator
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte AND()
        {
            A = (byte)(A & fetched);
            Z = (A == 0x00);
            N = (bool)((byte)(A & 0x80) == 0x80);
            
            // AND has the possible outcoming of needing extra cpu cycles based on the address mode
            return 1;
        }

        /// <summary>
        /// Performs an arithmatic shift left. The most significant digit is copied to the
        /// Carry bit.
        /// </summary>
        /// <returns></returns>
        internal virtual byte ASL()
        {
            C = (fetched & 0x80) == 0x80;
            
            fetched = (byte)(fetched << 1);

            N = (fetched & 0x80) == 0x80;
            Z = fetched == 0;

            return 0;
        } 
        
        /// <summary>
        /// (B)ranch if (C)arry flag (C)lear
        /// </summary>
        /// <returns></returns>
        internal virtual byte BCC()
        { 
            if(!C)
            {
                Cycles++;
                addr_abs = (ushort)(PC + addr_rel);

                // if the new address and the current program counter
                // are not within the same page (255 bytes), then
                // the CPU needs an extra clock cycle to perfomr the operation
                if ((addr_abs & 0xFF00) != (PC & 0xFF00))
                    Cycles++;

                PC = addr_abs;
            }

            return 0;
        }
        
        /// <summary>
        /// (B)ranch if (C)arry flag (S)et
        /// </summary>
        /// <returns></returns>
        internal virtual byte BCS()
        {
            if(C)
            {
                Cycles++;
                addr_abs = (ushort)(PC + addr_rel);

                // if the new address and the current program counter
                // are not within the same page (255 bytes), then
                // the CPU needs an extra clock cycle to perform the operation
                if ((addr_abs & 0xFF00) != (PC & 0xFF00))
                    Cycles++;

                PC = addr_abs;
            }
            return 0;
        } 
        
        /// <summary>
        /// (B)ranch on (EQ)ual
        /// </summary>
        /// <returns></returns>
        internal virtual byte BEQ()
        {
            if(Z)
            {
                Cycles++;
                addr_abs = (ushort)(PC + addr_rel);

                // if the new address and the current program counter
                // are not within the same page (255 bytes), then
                // the CPU needs an extra clock cycle to perform the operation
                if ((addr_abs & 0xFF00) != (PC & 0xFF00))
                    Cycles++;

                PC = addr_abs;
            }
            return 0;
        } 
        
        /// <summary>
        /// Performs as if the value at the fetched address were ANDed with the Accumulator
        /// </summary>
        /// <returns></returns>
        internal virtual byte BIT()
        {
            Z = (fetched & A) == 0x00;

            N = ((fetched & 0x80) == 0x80);

            V = ((fetched & 0x40) == 0x40);

            return 0;
        } 
        
        /// <summary>
        /// (B)ranch if (MI)nus
        /// </summary>
        /// <returns></returns>
        internal virtual byte BMI()
        {
            if (N)
            {
                Cycles++;
                addr_abs = (ushort)(PC + addr_rel);

                // if the new address and the current program counter
                // are not within the same page (255 bytes), then
                // the CPU needs an extra clock cycle to perform the operation
                if ((addr_abs & 0xFF00) != (PC & 0xFF00))
                    Cycles++;

                PC = addr_abs;
            }
            return 0;
        }

        /// <summary>
        /// (B)ranch if (N)ot (E)qual
        /// </summary>
        /// <returns></returns>
        internal virtual byte BNE()
        {
            if (!Z)
            {
                Cycles++;
                addr_abs = (ushort)(PC + addr_rel);

                // if the new address and the current program counter
                // are not within the same page (255 bytes), then
                // the CPU needs an extra clock cycle to perform the operation
                if ((addr_abs & 0xFF00) != (PC & 0xFF00))
                    Cycles++;

                PC = addr_abs;
            }
            return 0;
        }

        /// <summary>
        /// (B)ranch on (PL)us
        /// </summary>
        /// <returns></returns>
        internal virtual byte BPL()
        {
            if(!N)
            {
                Cycles++;
                addr_abs = (ushort)(PC + addr_rel);

                // if the new address and the current program counter
                // are not within the same page (255 bytes), then
                // the CPU needs an extra clock cycle to perform the operation
                if ((addr_abs & 0xFF00) != (PC & 0xFF00))
                    Cycles++;

                PC = addr_abs;
            }
            return 0;
        }

        /// <summary>
        /// Performs a (BR)ea(K)
        /// </summary>
        /// <returns></returns>
        internal virtual byte BRK() 
        {
            PC += 2;
            B = true;

            return 0; 
        }

        /// <summary>
        /// (B)ranch if O(v)erflow (C)lear
        /// </summary>
        /// <returns></returns>
        internal virtual byte BVC()
        {
            if (!V)
            {
                Cycles++;
                addr_abs = (ushort)(PC + addr_rel);

                // if the new address and the current program counter
                // are not within the same page (255 bytes), then
                // the CPU needs an extra clock cycle to perform the operation
                if ((addr_abs & 0xFF00) != (PC & 0xFF00))
                    Cycles++;

                PC = addr_abs;
            }
            return 0;
        }

        /// <summary>
        /// (B)ranch if O(v)erflow (S)et
        /// </summary>
        /// <returns></returns>
        internal virtual byte BVS()
        {
            if (V)
            {
                Cycles++;
                addr_abs = (ushort)(PC + addr_rel);

                // if the new address and the current program counter
                // are not within the same page (255 bytes), then
                // the CPU needs an extra clock cycle to perform the operation
                if ((addr_abs & 0xFF00) != (PC & 0xFF00))
                    Cycles++;

                PC = addr_abs;
            }
            return 0;
        }

        /// <summary>
        /// (CL)ear the (C)arry CPU flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte CLC()
        {
            C = false;

            // this operation requires no additional CPU cycles
            return 0;
        }

        /// <summary>
        /// (CL)ear the (D)ecimal CPU flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte CLD()
        {
            D = false;

            // this operation requires no additional CPU cycles
            return 0;
        }

        /// <summary>
        /// (CL)ear the (I)nterrupt flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte CLI()
        {
            I = false;

            return 0;
        }

        /// <summary>
        /// (CL)ear the O(V)erflow CPU flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte CLV()
        {
            V = false;

            return 0;
        }

        /// <summary>
        /// Performs a CoMPare operation with the Accumulator as if a subtraction operation took place
        /// </summary>
        /// <returns></returns>
        internal virtual byte CMP()
        {
            Z = A == fetched;
            C = A >= fetched;

            byte t = (byte)(A - fetched);
            
            // check if the high order bit is set
            if ((t & 0b_1000_0000) == 0b_1000_0000)
                N = true;

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual byte CPX()
        {
            Z = X == fetched;
            C = X >= fetched;

            byte t = (byte)(X - fetched);

            // check if the high order bit is set
            if ((t & 0b_1000_0000) == 0b_1000_0000)
                N = true;

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual byte CPY()
        {
            Z = Y == fetched;
            C = Y >= fetched;

            byte t = (byte)(Y - fetched);

            // check if the high order bit is set
            if ((t & 0b_1000_0000) == 0b_1000_0000)
                N = true;

            return 0;
        }

        /// <summary>
        /// Decrement by one the given memory address, based on the addressing mode
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte DEC()
        {
            sbyte t = (sbyte)(fetched - 1);

            bus.Write(addr_abs, (byte)t);

            Z = t == 0;

            N = (t & 0x8) == 0x8;

            return 0;
        }

        /// <summary>
        /// Decrement by one the value in the X register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte DEX()
        {
            X--;

            Z = X == 0;

            N = (X & 0x8) == 0x8;

            return 0;
        }

        /// <summary>
        /// Decrement by one the value in the Y register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte DEY()
        {
            Y--;

            Z = Y == 0;

            N = (Y & 0x8) == 0x8;

            return 0;
        }

        /// <summary>
        /// Exclusive OR Memory with Accumulator
        /// </summary>
        /// <returns></returns>
        internal virtual byte EOR()
        {
            byte t = (byte)(A ^ fetched);

            Z = t == 0;

            N = (t & 0b_1000_0000) == 0b_1000_0000;

            A = t;

            return 0;
        }

        /// <summary>
        /// Increment the value in the A register
        /// </summary>
        /// <returns></returns>
        internal virtual byte INC()
        {
            sbyte t = (sbyte)(fetched + 1);

            bus.Write(addr_abs, (byte)t);

            Z = t == 0;

            N = (t & 0b_1000_0000) == 0b_1000_0000;

            return 0;
        }

        /// <summary>
        /// (IN)crement the X register by one (1)
        /// /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte INX()
        {
            X++;

            Z = X == 0;

            N = (X & 0b_1000_0000) == 0b_1000_0000;

            return 0;
        }

        /// <summary>
        /// (IN)crement the Y register by one (1)
        /// </summary>
        /// <returns></returns>
        internal virtual byte INY()
        {
            Y++;

            Z = Y == 0;

            N = (Y & 0b_1000_0000) == 0b_1000_0000;

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual byte JMP()
        {
            PC = addr_abs;

            return 0;
        }

        /// <summary>
        /// Jump to Subroutine specified in Address
        /// </summary>
        /// <returns></returns>
        internal virtual byte JSR()
        {
            byte lo = (byte)(PC & 0xFF);
            byte hi = (byte)(PC >> 8);

            PushStack(lo);
            PushStack(hi);

            PC = addr_abs;

            return 0;
        }

        /// <summary>
        /// Loads the value from memory into the Accumulator
        /// </summary>
        /// <returns></returns>
        internal virtual byte LDA()
        {
            A = fetched;

            return 0;
        }

        /// <summary>
        /// Loads the value from memory into the X register
        /// </summary>
        /// <returns></returns>
        internal virtual byte LDX()
        {
            X = fetched;

            return 0;
        }

        /// <summary>
        /// Loads the value from memory into the Y register
        /// </summary>
        /// <returns></returns>
        internal virtual byte LDY()
        {
            Y = fetched;

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual byte LSR()
        {
            N = false;

            C = (fetched & 0b_0000_0001) == 0b_0000_0001;

            fetched = (byte)(fetched >> 1);

            Z = fetched == 0;

            return 0;
        }

        /// <summary>
        /// Perform a no-op, or non-operation
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte NOP()
        {
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual byte ORA()
        {
            byte t = (byte)(A | fetched);

            N = (t & 0b_1000_0000) == 0b_1000_0000;
            
            Z = t == 0;

            A = t;

            return 0;
        }

        /// <summary>
        /// (P)us(H) the (A)ccumulator onto the Stack
        /// </summary>
        /// <returns></returns>
        internal virtual byte PHA()
        {
            PushStack(A);

            return 3;
        }

        /// <summary>
        /// (P)us(H)es the CPU (P)rocessor status onto the stack
        /// </summary>
        /// <returns></returns>
        internal virtual byte PHP()
        {

            PushStack((byte)Status);

            return 3;
        }

        /// <summary>
        /// (P)ul(L) the stack into the (A)ccumulator
        /// </summary>
        /// <returns></returns>
        internal virtual byte PLA()
        {
            //A = Read(SP);

            //Write(SP, 0x0);

            A = PopStack();

            return 4;
        }

        /// <summary>
        /// (P)ul(L)s the stack into the CPU (P)rocessor status
        /// </summary>
        /// <returns></returns>
        internal virtual byte PLP()
        {
            this.Status = (CpuFlags)PopStack();
            //(CpuFlags)Read(SP);

            //Write(SP, 0x0);

            //PopStack();

            return 4;
        }

        /// <summary>
        /// (RO)tate (L)eft
        /// </summary>
        /// <remarks>ROR shifts all bits left by one position. Bit 7 is shifted into the Carry bit and the original Carry bit is shifted into bit 0</remarks>
        /// <returns></returns>
        internal virtual byte ROL()
        {
            byte oldC = (byte)(C ? 0x1 : 0x0);

            // move the high order bit into the Carry flag
            C = (fetched & 0x80) > 0;

            //unchecked
            //{
            //    // remove the high order bit
            //    fetched &= (byte)~(0x80);
            //}

            // shift everything left
            fetched = (byte)(fetched << 1);

            // move the old Carry bit into the low order bit
            fetched |= oldC;

            Z = fetched == 0;
            
            N = (fetched & 0x80) > 0;

            return 0;
        }

        /// <summary>
        /// (RO)tate (R)ight
        /// </summary>
        /// <remarks>ROR shifts all bits right by one position. The Carry bit is shifted into bit 7 and the original bit 0 is shifted into the Carry</remarks>
        /// <returns></returns>
        internal virtual byte ROR()
        {
            byte lsb = (byte)(fetched & 0x01);

            fetched = (byte)(fetched >> 1);

            fetched |= (byte)((C ? 1 : 0) << 7);

            Z = fetched == 0;

            N = (fetched & 0x80) > 0;

            C = lsb > 0 ? true : false;

            return 0;
        }

        /// <summary>
        /// (R)e(T)urn from (I)nterrupt
        /// </summary>
        /// <returns></returns>
        internal virtual byte RTI(){ return 0;}

        /// <summary>
        /// (R)e(T)urn to (S)ubroutine
        /// </summary>
        /// <returns></returns>
        internal virtual byte RTS()
        {
            byte lo = PopStack();
            //PopStack();
            byte hi = PopStack();
            // PopStack();

            PC = MakeAddress(hi, lo);
                
            return 6;
        }

        /// <summary>
        /// Subtract with Carry
        /// </summary>
        /// <returns></returns>
        internal virtual byte SBC()
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
        internal virtual byte SEC()
        {
            C = true;

            return 0;
        }

        /// <summary>
        /// Sets the Decimal flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte SED()
        {
            D = true;
            return 0;
        }

        /// <summary>
        /// Sets the Interrupt flag
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte SEI()
        {
            I = true;
            return 0;
        }

        /// <summary>
        /// Store the next byte read into the A register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte STA()
        { 
            return 0;
        }

        /// <summary>
        /// Store the next byte read into the X register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte STX()
        { 
            return 0;
        }

        /// <summary>
        /// Store the next byte read into the Y register
        /// </summary>
        /// <returns>Non zero if the operation requires additiona CPU cycles</returns>
        internal virtual byte STY()
        { 
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual byte TAX(){ return 0;}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual byte TAY(){ return 0;}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual byte TSX()
        {
            X = Read(SP);

            SP++;

            return 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual byte TXA(){ return 0;}

        /// <summary>
        /// Transfer the contents of the X register onto the stack and moves the stack down one
        /// </summary>
        /// <returns></returns>
        internal virtual byte TXS()
        {
            Write(SP, X);

            SP--;

            return 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal virtual byte TYA(){ return 0;}
        #endregion

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

        /// <summary>
        /// Executes the current instruction at the program counter
        /// </summary>
        /// <returns>The number of Cycles required for the instruction</returns>
        internal byte Execute()
        {
            byte opCode = bus.Read(PC++);

            // lookup the CpuInstruction by the opcode
            CpuInstruction instruction = Instructions[opCode];

            // the cpu instruction default clock cycles before considering address mode
            Cycles = instruction.Cycles;

            // check if the address mode or the operation requires additional clock cycles
            byte additionalCpuCyclesFromMemoryMode = instruction.AddressMode();
            byte additionalCpuCyclesFromOperation = instruction.Operation();

            Cycles += (byte)(additionalCpuCyclesFromMemoryMode & additionalCpuCyclesFromOperation);

            return Cycles;
        }
/*
        /// <summary>
        /// Calls the internal functions for the given opcode
        /// </summary>
        /// <param name="opcode"></param>
        /// <returns></returns>
        internal byte ExecuteOpCode(byte opcode)
        {
            byte hi = (byte)(opcode & 0xF0);
            byte lo = (byte)(opcode & 0x0F);

            byte evenOdd = (byte)((hi >> 4) & 1);
            byte nibbleHiLo = (byte)((hi >> 4) & 0x8);

            byte ec = 0; // extra cycles;

            bool useAccumulator = false;
            Func<byte> addressFunction = null;
            Func<byte> operationFunction = null;

            switch (lo)
            {
                case 0x00:
                    switch (hi)
                    {
                        case 0x00:
                            addressFunction = A_IMP;
                            operationFunction = BRK;

                            ec += A_IMP();
                            ec += BRK();
                            break;
                        case 0x10:
                            addressFunction = A_REL;
                            operationFunction = BPL;

                            ec += A_REL();
                            ec += BPL();
                            break;
                        case 0x20:
                            addressFunction = A_ABS;
                            operationFunction = JSR;

                            ec += A_ABS();
                            ec += JSR();
                            break;
                        case 0x30:
                            addressFunction = A_REL;
                            operationFunction = BMI;

                            ec += A_REL();
                            ec += BMI();
                            break;
                        case 0x40:
                            addressFunction = A_IMP;
                            operationFunction = RTI;

                            ec += A_IMP();
                            ec += RTI();
                            break;
                        case 0x50:
                            addressFunction = A_REL;
                            operationFunction = BVC;

                            ec += A_REL();
                            ec += BVC();
                            break;
                        case 0x60:
                            addressFunction = A_IMP;
                            operationFunction = RTS;

                            ec += A_IMP();
                            ec += RTS();
                            break;
                        case 0x70:
                            addressFunction = A_REL;
                            operationFunction = BVS;

                            ec += A_REL();
                            ec += BVS();
                            break;
                        //case 0x80:
                        //    break;
                        case 0x90:
                            addressFunction = A_REL;
                            operationFunction = BCC;

                            ec += A_REL();
                            ec += BCC();
                            break;
                        case 0xA0:
                            addressFunction = A_IMM;
                            operationFunction = LDY;

                            ec += A_IMM();
                            ec += LDY();
                            break;
                        case 0xB0:
                            addressFunction = A_REL;
                            operationFunction = BCS;

                            ec += A_REL();
                            ec += BCS();
                            break;
                        case 0xC0:
                            addressFunction = A_IMM;
                            operationFunction = CPY;

                            ec += A_IMM();
                            ec += CPY();
                            break;
                        case 0xD0:
                            addressFunction = A_REL;
                            operationFunction = BNE;

                            ec += A_REL();
                            ec += BNE();
                            break;
                        case 0xE0:
                            addressFunction = A_IMM;
                            operationFunction = CPX;

                            ec += A_IMM();
                            ec += CPX();
                            break;
                        case 0xF0:
                            ec += A_REL();
                            ec += BEQ();
                            break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                case 0x01:
                    if (0 == evenOdd)
                        ec += A_IZX();
                    else
                        ec += A_IZY();

                    switch (hi)
                    {
                        case 0x00:
                        case 0x10:
                            ec += ORA();
                            break;
                        case 0x20:
                        case 0x30:
                            ec += AND();
                            ec += 2;
                            break;
                        case 0x40:
                        case 0x50:
                            ec += EOR();
                            break;
                        case 0x60:
                        case 0x70:
                            ec += ADC();
                            break;
                        case 0x80:
                        case 0x90:
                            ec += STA();
                            break;
                        case 0xA0:
                        case 0xB0:
                            ec += LDA();
                            break;
                        case 0xC0:
                        case 0xD0:
                            ec += CMP();
                            break;
                        case 0xE0:
                        case 0xF0:
                            ec += SBC();
                            break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                case 0x02:
                    switch (hi)
                    {
                        case 0xA0:
                            ec += A_IMM();
                            ec += LDX();
                            break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                //case 0x03:
                //    break;
                case 0x04:
                    if (0 == evenOdd)
                        ec += A_ZP0();
                    else
                        ec += A_ZPX();

                    switch (hi)
                    {
                        case 0x20:
                            ec += BIT();
                            break;
                        case 0x80:
                        case 0x90:
                            ec += STY();
                            break;
                        case 0xA0:
                        case 0xB0:
                            ec += LDY();
                            break;
                        case 0xC0:
                            ec += CPY();
                            break;
                        case 0xE0:
                            ec += CPX();
                            break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                case 0x05:
                    if (0 == evenOdd)
                        ec += A_ZP0();
                    else
                        ec += A_ZPX();

                    switch (hi)
                    {
                        case 0x00:
                        case 0x10:
                            ec += ORA();
                            break;
                        case 0x20:
                        case 0x30:
                            ec += AND();
                            ec += 2;
                            break;
                        case 0x40:
                        case 0x50:
                            ec += EOR();
                            break;
                        case 0x60:
                        case 0x70:
                            ec += ADC();
                            break;
                        case 0x80:
                        case 0x90:
                            ec += STA();
                            break;
                        case 0xA0:
                        case 0xB0:
                            ec += LDA();
                            break;
                        case 0xC0:
                        case 0xD0:
                            ec += CMP();
                            break;
                        case 0xE0:
                        case 0xF0:
                            ec += SBC();
                            break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                case 0x06:
                    if (0 == evenOdd)
                        ec += A_ZP0();
                    else
                    {
                        if (0 == nibbleHiLo)
                            ec += A_ZPX();
                        else
                            ec += A_ZPY();
                    }

                    switch (hi)
                    {
                        case 0x00:
                        case 0x10:
                            ec += ASL();
                            break;
                        case 0x20:
                        case 0x30:
                            ec += ROL();
                            break;
                        case 0x40:
                        case 0x50:
                            ec += LSR();
                            break;
                        case 0x60:
                        case 0x70:
                            ec += ROR();
                            break;
                        case 0x80:
                        case 0x90:
                            ec += STX();
                            break;
                        case 0xA0:
                        case 0xB0:
                            ec += LDX();
                            break;
                        case 0xC0:
                        case 0xD0:
                            ec += DEC();
                            break;
                        case 0xE0:
                        case 0xF0:
                            ec += INC();
                            break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                //case 0x07:
                //    break;
                case 0x08:
                    ec += A_IMP();

                    switch (hi)
                    {
                        case 0x00:
                            ec += PHP();
                            break;
                        case 0x10:
                            ec += CLC();
                            break;
                        case 0x20:
                            ec += PLP();
                            break;
                        case 0x30:
                            ec += SEC();
                            break;
                        case 0x40:
                            ec += PHA();
                            break;
                        case 0x50:
                            ec += CLI();
                            break;
                        case 0x60:
                            ec += PLA();
                            break;
                        case 0x70:
                            ec += SEI();
                            break;
                        case 0x80:
                            ec += DEY();
                            break;
                        case 0x90:
                            ec += TYA();
                            break;
                        case 0xA0:
                            ec += TAY();
                            break;
                        case 0xB0:
                            ec += CLV();
                            break;
                        case 0xC0:
                            ec += INY();
                            break;
                        case 0xD0:
                            ec += CLD();
                            break;
                        case 0xE0:
                            ec += INX();
                            break;
                        case 0xF0:
                            ec += SED();
                            break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                case 0x09:
                    if (0 == evenOdd)
                        ec += A_IMM();
                    else
                        ec += A_ABY();

                    switch (hi)
                    {
                        case 0x00:
                        case 0x10:
                            ec += ORA();
                            break;
                        case 0x20:
                        case 0x30:
                            ec += AND();
                            break;
                        case 0x40:
                        case 0x50:
                            ec += EOR();
                            break;
                        case 0x60:
                        case 0x70:
                            ec += ADC();
                            break;
                        //case 0x80:
                        //    break;
                        case 0x90:
                            ec += STA();
                            break;
                        case 0xA0:
                        case 0xB0:
                            ec += LDA();
                            break;
                        case 0xC0:
                        case 0xD0:
                            ec += CMP();
                            break;
                        case 0xE0:
                        case 0xF0:
                            ec += SBC();
                            break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                case 0x0A:
                    if (0 == nibbleHiLo)
                    {
                        ec += A_ACC();
                        useAccumulator = true;
                    }
                    else
                        ec += A_IMP();

                    switch (hi)
                    {
                        case 0x00:
                            ec += ASL();
                            if (useAccumulator)
                                A = fetched;
                            break;
                        //case 0x10:
                        //    break;
                        case 0x20:
                            ec += ROL();
                            if (useAccumulator)
                                A = fetched;
                            break;
                        //case 0x30:
                        //    break;
                        case 0x40:
                            ec += LSR();
                            if (useAccumulator)
                                A = fetched;
                            break;
                        //case 0x50:
                        //    break;
                        case 0x60:
                            ec += ROR();
                            if (useAccumulator)
                                A = fetched;
                            break;
                        //case 0x70:
                        //    break;
                        case 0x80:
                            ec += TXA();
                            break;
                        case 0x90:
                            ec += TXS();
                            break;
                        case 0xA0:
                            ec += TAX();
                            break;
                        case 0xB0:
                            ec += TSX();
                            break;
                        case 0xC0:
                            ec += DEX();
                            break;
                        //case 0xD0:
                        //    break;
                        case 0xE0:
                            ec += NOP();
                            break;
                        //case 0xF0:
                        //    break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                //case 0x0B:
                //    break;
                case 0x0C:
                    switch (hi)
                    {
                        //case 0x00:
                        //    break;
                        //case 0x10:
                        //    break;
                        case 0x20:
                            ec += A_ABS();
                            ec += BIT();
                            break;
                        //case 0x30:
                        //    break;
                        case 0x40:
                            ec += A_ABS();
                            ec += JMP();
                            break;
                        //case 0x50:
                        //    break;
                        case 0x60:
                            ec += A_IND();
                            ec += JMP();
                            break;
                        //case 0x70:
                        //    break;
                        case 0x80:
                            ec += A_ABS();
                            ec += STY();
                            break;
                        //case 0x90:
                        //    break;
                        case 0xA0:
                            ec += A_ABS();
                            ec += LDY();
                            break;
                        case 0xB0:
                            ec += A_ABX();
                            ec += LDY();
                            break;
                        case 0xC0:
                            ec += A_ABS();
                            ec += CPY();
                            break;
                        //case 0xD0:
                        //    break;
                        case 0xE0:
                            ec += A_ABS();
                            ec += CPX();
                            break;
                        //case 0xF0:
                        //    break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                case 0x0D:
                    if (0 == evenOdd)
                        ec += A_ABS();
                    else
                        ec += A_ABX();

                    switch (hi)
                    {
                        case 0x00:
                        case 0x10:
                            ec += ORA();
                            break;
                        case 0x20:
                        case 0x30:
                            ec += AND();
                            break;
                        case 0x40:
                        case 0x50:
                            ec += EOR();
                            break;
                        case 0x60:
                        case 0x70:
                            ec += ADC();
                            break;
                        case 0x80:
                        case 0x90:
                            ec += STA();
                            break;
                        case 0xA0:
                        case 0xB0:
                            ec += LDA();
                            break;
                        case 0xC0:
                        case 0xD0:
                            ec += CMP();
                            break;
                        case 0xE0:
                        case 0xF0:
                            ec += SBC();
                            break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                case 0x0E:
                    if (0 == evenOdd)
                        ec += A_ABS();
                    else
                    {
                        if (0xB0 == hi)
                            ec += A_ABY();
                        else
                            ec += A_ABX();
                    }

                    switch (hi)
                    {
                        case 0x00:
                        case 0x10:
                            ec += ASL();
                            break;
                        case 0x20:
                        case 0x30:
                            ec += ROL();
                            break;
                        case 0x40:
                        case 0x50:
                            ec += LSR();
                            break;
                        case 0x60:
                        case 0x70:
                            ec += ROR();
                            break;
                        case 0x80:
                            ec += STX();
                            break;
                        //case 0x90:
                        //    break;
                        case 0xA0:
                        case 0xB0:
                            ec += LDX();
                            break;
                        case 0xC0:
                        case 0xD0:
                            ec += DEC();
                            break;
                        case 0xE0:
                        case 0xF0:
                            ec += INC();
                            break;
                        default:
                            goto ExecuteOpCode_UnknownOpCode;
                    }
                    break;
                //case 0x0F:
                //    break;
                default:
                    goto ExecuteOpCode_UnknownOpCode;
            }

            //if(addressFunction != null)
            //    ec += addressFunction();

            //if (operationFunction != null)
            //    ec += operationFunction();

            //if (useAccumulator)
            //    A = fetched;

            goto ExecuteOpCode_Exit;

        ExecuteOpCode_UnknownOpCode:
            var errorString = String.Format("Unknown opcode %d", opcode);

            debugStream?.WriteLine(errorString);

            throw new InvalidProgramException(errorString);

        ExecuteOpCode_Exit:
            return ec;
        }

        internal byte ExecuteOpCode2(byte opcode)
        {
            byte hi = (byte)(opcode & 0xF0);
            byte lo = (byte)(opcode & 0x0F);

            byte evenOdd = (byte)((hi >> 4) & 1);
            byte nibbleHiLo = (byte)((hi >> 4) & 0x8);

            byte ec = 0; // extra cycles;

            bool useAccumulator = false;
            Func<byte> fnAddr = null;
            Func<byte> fnOper = null;


            switch(lo)
            {
                case 0x00:
                    switch(hi)
                    {
                        case 0x00:
                            break;
                        case 0x10:
                            break;
                        case 0x20:
                            break;
                        case 0x30:
                            break;
                        case 0x40:
                            break;
                        case 0x50:
                            break;
                        case 0x60:
                            break;
                        case 0x70:
                            break;
                        case 0x80:
                            break;
                        case 0x90:
                            break;
                        case 0xA0:
                            break;
                        case 0xB0:
                            break;
                        case 0xC0:
                            break;
                        case 0xD0:
                            break;
                        case 0xE0:
                            break;
                        case 0xF0:
                            break;
                        default:
                            goto ExecuteOpCode2_UnknownOpCode;
                    }
                    break;
                case 0x01:
                    break;
                case 0x02:
                    break;
                case 0x03:
                    break;
                case 0x04:
                    break;
                case 0x05:
                    break;
                case 0x06:
                    break;
                case 0x07:
                    break;
                case 0x08:
                    break;
                case 0x09:
                    break;
                case 0x0A:
                    break;
                case 0x0B:
                    break;
                case 0x0C:
                    break;
                case 0x0D:
                    break;
                case 0x0E:
                    break;
                case 0x0F:
                    break;
                default:
                    goto ExecuteOpCode2_UnknownOpCode;
            }

            ec += fnAddr();
            ec += fnOper();

            if (useAccumulator)
                A = fetched;

            goto ExecuteOpCode2_Exit;

        ExecuteOpCode2_UnknownOpCode:
            var errorString = String.Format("Unknown opcode %d", opcode);

            debugStream?.WriteLine(errorString);

            throw new InvalidProgramException(errorString);

        ExecuteOpCode2_Exit:
            return ec;
        }
*/
        /// <summary>
        /// 
        /// </summary>
        internal void Run()
        {
            do
            {
                Clock();
            } while (Cycles > 0);

            PC++;
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
        /// Helper function to determine if the addr_abs member and the program counter (PC) are within the same 256 byte page
        /// </summary>
        /// <returns></returns>
        private bool AreOnSamePage()
        {
            return (addr_abs & 0xFf00) == (PC & 0xFF00);
        }

        /// <summary>
        /// Helper function to push the stack pointer, so we don't have to remember if it is incrementing or decrementing
        /// </summary>
        private void PushStack(byte value) 
        {
            bus.Write(SP, value);

            SP--; 
        }

        /// <summary>
        /// Helper function to pop the stack pointer, so we don't have to remember if it is incrementing or decrementing
        /// </summary>
        private byte PopStack() 
        {
            return bus.Read(SP++);
        }

        /// <summary>
        /// Read a byte at the specified address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private byte Read(ushort address)
        {
            return bus.Read(address);
        }

        /// <summary>
        /// Write a byte at the specified address
        /// </summary>
        /// <param name="address"></param>
        /// <param name="data"></param>
        private void Write(ushort address, byte data)
        {
            bus.Write(address, data);
        }

        private ushort MakeAddress(byte hi, byte lo)
        {
            return (ushort)(((ushort)hi << 8) + (ushort)lo);
        }
//        protected CpuFlags status; // cpu status flags
//        protected byte opcode;      // the current opcode being executed
        internal byte fetched;     // the byte recently Fetched() 
        internal ushort addr_abs;  // absolute address reference
        internal ushort addr_rel;  // relative address reference
        protected Bus bus;
        private bool useAccumulator;
        private System.IO.StreamWriter debugStream;

    }
}
