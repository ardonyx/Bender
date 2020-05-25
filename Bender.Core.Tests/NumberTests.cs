using Xunit;

namespace Bender.Core.Tests
{
    public class NumberTests
    {
        [Fact]
        public void TestSignedByte()
        {
            var el = new Element
            {
                PrintFormat = Bender.PrintFormat.Decimal,
                Units = 1,
                IsSigned = true,
            };


            // Test the widest data type because it includes all smaller data types
            Assert.Equal(0, Number.From(el, new byte[] { 0 }).sl);
            Assert.True(127 == Number.From(el, new byte[] { 127 }).sl);
            Assert.Equal(-1, Number.From(el, new byte[] { 255 }).sl);
            Assert.Equal(-128, Number.From(el, new byte[] { 128 }).sl);
        }

        [Fact]
        public void TestUnsignedByte()
        {
            var el = new Element
            {
                PrintFormat = Bender.PrintFormat.Decimal,
                Units = 1,
                IsSigned = false,
            };

            Assert.True(0 ==  Number.From(el, new byte[] { 0 }).ul);
            Assert.True(127 == Number.From(el, new byte[] { 127 }).ul);
            Assert.True(255 == Number.From(el, new byte[] { 255 }).ul);
            Assert.True(128 == Number.From(el, new byte[] { 128 }).ul);
        }

        [Fact]
        public void TestSignedShort()
        {
            var el = new Element
            {
                PrintFormat = Bender.PrintFormat.Decimal,
                Units = 2,
                IsSigned = true,
            };


            // Test the widest data type because it includes all smaller data types
            Assert.Equal(0, Number.From(el, new byte[] { 0, 0 }).sl);
            Assert.Equal(32767, Number.From(el, new byte[] { 0xFF, 0x7F }).sl);
            Assert.Equal(-32768, Number.From(el, new byte[] { 0x00, 0x80 }).sl);
            Assert.Equal(-1, Number.From(el, new byte[] { 0xFF, 0xFF }).sl);
        }

        [Fact]
        public void TestUnsignedShort()
        {
            var el = new Element
            {
                PrintFormat = Bender.PrintFormat.Decimal,
                Units = 2,
                IsSigned = false,
            };

            Assert.True(0 == Number.From(el, new byte[] { 0, 0 }).ul);
            Assert.True(32767 == Number.From(el, new byte[] { 0xFF, 0x7F }).ul);
            Assert.True(32768 == Number.From(el, new byte[] { 0x00, 0x80 }).ul);
            Assert.True(65535 == Number.From(el, new byte[] { 0xFF, 0xFF }).ul);
        }

        [Fact]
        public void TestSignedInt()
        {
            var el = new Element
            {
                PrintFormat = Bender.PrintFormat.Decimal,
                Units = 4,
                IsSigned = true,
            };


            // Test the widest data type because it includes all smaller data types
            Assert.Equal(0, Number.From(el, new byte[] { 0, 0, 0, 0 }).sl);
            Assert.Equal(2147483647, Number.From(el, new byte[] { 0xFF, 0xFF, 0xFF, 0x7F }).sl);
            Assert.Equal(-2147483648, Number.From(el, new byte[] { 0x00, 0x00, 0x00, 0x80 }).sl);
            Assert.Equal(-1, Number.From(el, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }).sl);
        }

        [Fact]
        public void TestUnsignedInt()
        {
            var el = new Element
            {
                PrintFormat = Bender.PrintFormat.Decimal,
                Units = 4,
                IsSigned = false,
            };

            Assert.True(0 == Number.From(el, new byte[] { 0, 0, 0, 0 }).ul);
            Assert.True(2147483647 == Number.From(el, new byte[] { 0xFF, 0xFF, 0xFF, 0x7F }).ul);
            Assert.True(2147483648 == Number.From(el, new byte[] { 0x00, 0x00, 0x00, 0x80 }).ul);
            Assert.True(4294967295 == Number.From(el, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF }).ul);
        }

        [Fact]
        public void TestSignedLong()
        {
            var el = new Element
            {
                PrintFormat = Bender.PrintFormat.Decimal,
                Units = 8,
                IsSigned = true,
            };


            // Test the widest data type because it includes all smaller data types
            Assert.Equal(0, Number.From(el, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }).sl);
            Assert.Equal(9223372036854775807, Number.From(el, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F }).sl);
            Assert.Equal(-9223372036854775808, Number.From(el, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }).sl);
            Assert.Equal(-1, Number.From(el, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }).sl);
        }

        [Fact]
        public void TestUnsignedLong()
        {
            var el = new Element
            {
                PrintFormat = Bender.PrintFormat.Decimal,
                Units = 8,
                IsSigned = false,
            };

            Assert.True(0 == Number.From(el, new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 }).ul);
            Assert.True(9223372036854775807 == Number.From(el, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x7F }).ul);
            Assert.True(9223372036854775808 == Number.From(el, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }).ul);
            Assert.True(18446744073709551615 == Number.From(el, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }).ul);
        }

        [Fact]
        public void TestEqualityOperatorOrder()
        {
            var number = Number.From(4, false, 0, new byte[] {1, 0, 0, 0});

            // Operator order matters, both must be implemented
            Assert.True(number == 1);
            Assert.True(1 == number);
        }
        
        [Fact]
        public void TestInequalityOperatorOrder()
        {
            var number = Number.From(4, false, 0, new byte[] {0, 0, 0, 1});

            // Operator order matters, both must be implemented
            Assert.True(number != 1);
            Assert.True(1 != number);
        }
    }
}
