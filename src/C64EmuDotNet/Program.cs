using System;
using Lib6502;

namespace C64EmuDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Memory memory = new Memory(65535);

            Memory rom = new Memory(20 * 1024);
            
            Bus bus = new Bus(memory);
            
            m6502 cpu = new m6502(memory);

            while(true)
            {
                do
                {
                    cpu.Clock();
                } while (cpu.Cycles > 0);

                // if interrupt

                // if break

                // from the video buffer, update the screen
                VideoUpdate();
                
                break;
            }

        }

        static void VideoUpdate()
        {

        }
    }
}
