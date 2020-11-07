using System;
using System.Collections.Generic;
using System.Text;

namespace Lib6502
{
    public class Memory : IDisposable
    {
        public Memory(ushort size)
        {
            mem = new byte[size];
        }

        byte[] mem;

        public void Dispose()
        {
            if (mem != null)
                mem = null;
        }

        public byte Read(ushort address)
        {
            if (address > mem.Length || address < 0)
                throw new ArgumentOutOfRangeException(nameof(address));

            return mem[address];
        }

        public void Write(ushort address, byte data)
        {
            if (address > mem.Length || address < 0)
                throw new ArgumentOutOfRangeException(nameof(address));

            mem[address] = data;
        }
    }
}
