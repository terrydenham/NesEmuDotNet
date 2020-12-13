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

            Clear();
        }

        byte[] mem;

        public void Dispose()
        {
            if (mem != null)
                mem = null;
        }

        /// <summary>
        /// Clear the memory by resetting it to zero
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < mem.Length; i++)
                mem[i] = 0x00;
        }

        /// <summary>
        /// read the byte at the given address
        /// </summary>
        /// <param name="address">The address to read from</param>
        /// <returns>The byte retrieved at the given address</returns>
        public byte Read(ushort address)
        {
            if (address > mem.Length || address < 0)
                throw new ArgumentOutOfRangeException(nameof(address));

            return mem[address];
        }

        /// <summary>
        /// Store the byte at the given address
        /// </summary>
        /// <param name="address">The address to write to</param>
        /// <param name="data">The byte of data that will be written</param>
        public void Write(ushort address, byte data)
        {
            if (address > mem.Length || address < 0)
                throw new ArgumentOutOfRangeException(nameof(address));

            mem[address] = data;
        }

        public byte[] Write(ushort startAddress, ushort amount, bool forward = true)
        {
            byte[] rv = new byte[amount];
            int direction = forward ? 1 : -1;

            for (int i = 0, a = startAddress; i < amount; i++, a += direction)
            {
                rv[i] = mem[a];
            }

            return rv;
        }

        public void Write(ushort startAddress, byte[] data, bool forward = true)
        {
            int direction = forward ? 1 : -1;
            
            for(int i = 0, a = startAddress; i < data.Length; i++, a += direction)
            {
                mem[a] = data[i];
            }    
        }
    }
}
