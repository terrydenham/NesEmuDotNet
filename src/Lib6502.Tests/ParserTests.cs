using NUnit.Framework;
using System.IO;
using System.Text;

namespace Lib6502.Tests
{
    public class ParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, Ignore("Not ready yet")]
        public void CanParseImpliedInstruction()
        {
            byte[] actual = null;

            using (var ms = new MemoryStream())
            {
                using var writer = new StreamWriter(ms, Encoding.ASCII);
                writer.WriteLine("BRK");
                writer.Flush();
                ms.Position = 0;

                using var reader = new StreamReader(ms, Encoding.ASCII);
                actual = AssemblyParser.Parse(reader);
            }

            Assert.AreEqual(actual.Length, 1);
            Assert.AreEqual(0x00, actual[0]);
        }

        [Test, Ignore("Not ready yet")]
        public void CanParseImpliedInstructionWithLeadingTab()
        {
            byte[] actual = null;

            using (var ms = new MemoryStream())
            {
                using var writer = new StreamWriter(ms, Encoding.ASCII);
                writer.WriteLine("\tBRK");
                writer.Flush();
                ms.Position = 0;

                using var reader = new StreamReader(ms, Encoding.ASCII);
                actual = AssemblyParser.Parse(reader);
            }

            Assert.AreEqual(actual.Length, 1);
            Assert.AreEqual(0x00, actual[0]);
        }

        [Test, Ignore("Not ready yet")]
        public void CanParseImpliedInstructionWithLeadingSpaces()
        {
            byte[] actual = null;

            using (var ms = new MemoryStream())
            {
                using var writer = new StreamWriter(ms, Encoding.ASCII);
                writer.WriteLine("    BRK");
                writer.Flush();
                ms.Position = 0;

                using var reader = new StreamReader(ms, Encoding.ASCII);
                actual = AssemblyParser.Parse(reader);
            }

            Assert.AreEqual(actual.Length, 1);
            Assert.AreEqual(0x00, actual[0]);
        }

        [Test, Ignore("Not ready yet")]
        public void CanParseImpliedInstructionWithTrailingComment()
        {
            byte[] actual = null;

            using (var ms = new MemoryStream())
            {
                using var writer = new StreamWriter(ms, Encoding.ASCII);
                writer.WriteLine("BRK; comment");
                writer.Flush();
                ms.Position = 0;

                using var reader = new StreamReader(ms, Encoding.ASCII);
                actual = AssemblyParser.Parse(reader);
            }

            Assert.AreEqual(actual.Length, 1);
            Assert.AreEqual(0x00, actual[0]);
        }

        [Test, Ignore("Not ready yet")]
        public void CanParseImpliedInstructionWithTrailingSpaces()
        {
            byte[] actual = null;

            using (var ms = new MemoryStream())
            {
                using var writer = new StreamWriter(ms, Encoding.ASCII);
                writer.WriteLine("BRK    ");
                writer.Flush();
                ms.Position = 0;

                using var reader = new StreamReader(ms, Encoding.ASCII);
                actual = AssemblyParser.Parse(reader);
            }

            Assert.AreEqual(actual.Length, 1);
            Assert.AreEqual(0x00, actual[0]);
        }


    }
}