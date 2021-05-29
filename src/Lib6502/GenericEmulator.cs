using System;
using System.Collections.Generic;
using System.Text;

namespace Lib6502
{
    public class GenericEmulator
    {
        public void Configure(EmulatorConfiguration configuration)
        {
            _rom = new ReadOnlyMemory(configuration.RomSize);
            _ram = new RandomAccessMemory(configuration.RamSize);
            _bus = new Bus(_ram);
            _cpu = new m6502(_ram, configuration.DebugStream);
        }

        public virtual int Run(string[] commandLine)
        {
            return 0;
        }

        protected RandomAccessMemory _ram;
        protected ReadOnlyMemory _rom;
        protected Bus _bus;
        protected m6502 _cpu;

    }
}
