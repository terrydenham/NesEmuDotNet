using System;
using System.Collections.Generic;
using System.Text;

namespace Lib6502
{

    public class ReadOnlyMemory : IReadMemory
    {
        public ReadOnlyMemory(ushort size)
        {
            _data = new byte[size];
        }

        public void Load(System.IO.BinaryReader reader, ushort size)
        {
            reader.Read(_data, 0, size);
        }

        /// <summary>
        /// read the byte at the given address
        /// </summary>
        /// <param name="address">The address to read from</param>
        /// <returns>The byte retrieved at the given address</returns>
        public byte Read(ushort address)
        {
            if (address >= _data.Length )
                throw new ArgumentOutOfRangeException(nameof(address));

            return _data[address];
        }

        public byte[] Read(ushort address, short length)
        {
            throw new NotImplementedException();
        }

        private byte[] _data;
    }
}
