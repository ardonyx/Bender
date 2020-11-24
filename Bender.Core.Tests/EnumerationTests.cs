namespace Bender.Core.Tests
{
    using System.Collections.Generic;
    using Layouts;
    using Nodes;
    using Xunit;

    public class EnumerationTests
    {
        private static readonly Element _element = new()
        {
            Enumeration = new Enumeration
            {
                Name = "Test Enumeration",
                Values = new Dictionary<int, string>
                {
                    {0, "Foo"},
                    {1, "Bar"},
                    {2, "Baz"}
                }
            },
            Name = "Element w/ Enumeration",
            Units = 1
        };

        [Theory]
        [InlineData(new byte[] {0}, "Foo")]
        [InlineData(new byte[] {1}, "Bar")]
        [InlineData(new byte[] {2}, "Baz")]
        public void CanFormatElement(byte[] buff, string expected)
        {
            var context = new ReaderContext(buff);
            var actual = _element.BuildNode(context, buff);

            var asPrimitive = actual as BPrimitive<Phrase>;
            Assert.NotNull(asPrimitive);

            Assert.Equal(new Phrase(expected), asPrimitive.Value);
        }
    }
}