using FluentAssertions;
using Xunit;

namespace SuppaParser.Tests
{
    public class CParserSpecs
    {
        [Fact]
        public void If()
        {
            AssertParse("if (a) b;", "if (-) -;");
        }

        [Fact]
        public void IfElse()
        {
            AssertParse("if (a) b; else c;", "if (-) -; else -;");
        }

        [Fact]
        public void IfBlock()
        {
            AssertParse("if (a) {b; c; d; }", "if (-) {-;-;-;}");
        }

        private void AssertParse(string input, string expected)
        {
            var tokenizer = Tokenizer.Create();
            var parser = new CParser(tokenizer);
            parser.Parse(input).ToString().Should().Be(expected);
        }
    }
}
