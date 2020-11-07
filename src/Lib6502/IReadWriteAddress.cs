using System;
using System.Collections.Generic;
using System.Text;

namespace Lib6502
{
    public interface IReadWriteAddress
    {
        byte Read(ushort address);
        void Write(ushort address, byte data);
    }
}
