using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lib6502
{
    public class AssemblyParser
    {
        public static byte[] Parse(StreamReader reader)
        {
            var rv = new Collection<byte>();

            var pnuemonic = new StringBuilder();

            bool foundPnuemonic = false;
            AddressMode addressMode = AddressMode.IMP;

            do
            {
                char c = (char)reader.Read();

                if (Char.IsWhiteSpace(c))
                    continue;

                if (Char.IsPunctuation(c))
                    continue;

                if (c == '#')
                {
                    addressMode = AddressMode.IMM;
                    continue;
                }

                if( c == '(')
                {
                    addressMode = AddressMode.IND;

                }

                if(Char.IsLetter(c))
                {
                    pnuemonic.Append(c);

                    if(pnuemonic.Length == 3)
                    {

                    }
                }
                
                if(c == '\r' || c == '\n')
                {
                }

            } while (!reader.EndOfStream);

            return rv.ToArray();
        }
    }
}
