using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lib6502
{
    public class EmulatorConfiguration
    {
        public ushort RomSize { get; internal set; }
        public ushort RamSize { get; internal set; }
        public StreamWriter DebugStream { get; internal set; }

        public EmulatorConfiguration SetRandomAccessMemorySize(ushort size)
        {
            return this;
        }
    }
}
