using System;
using System.Collections.Generic;
using System.Text;

namespace Lib6502
{
    public class Bus : IReadWriteAddress
    {
        public Bus(Memory memory)
        {
            mem = memory;
        }
        public byte Read(ushort address) 
        {
            return mem.Read(address);
        }

        public void Write(ushort address, byte data) 
        {
            mem.Write(address, data);
        }

        private readonly Memory mem;
    }
}
