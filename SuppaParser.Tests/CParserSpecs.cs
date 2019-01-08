using FluentAssertions;
using Xunit;

namespace SuppaParser.Tests
{
    public class CParserSpecs
    {
        [Fact]
        public void IfStatement()
        {
            AssertParse("if (a) b;", "if (-) -;");
        }

        private void AssertParse(string input, string expected)
        {
            var tokenizer = Tokenizer.Create();
            var parser = new CParser(tokenizer);
            parser.Parse(input).ToString().Should().Be(expected);
        }
    }
}
