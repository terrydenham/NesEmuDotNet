using System;
using System.Collections.Generic;
using System.Text;

namespace Lib6502
{
    public interface IReadMemory
    {
        byte Read(ushort address);

        byte[] Read(ushort address, short length);
    }

    public interface IWriteMemory
    {
        void Write(ushort address, byte value);

        void Write(ushort address, byte[] data);
    }
}
