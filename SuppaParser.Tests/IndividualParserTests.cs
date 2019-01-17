using FluentAssertions;
using Superpower;
using Xunit;

namespace SuppaParser.Tests
{
    public class IndividualParserTests
    {
        [Theory]
        [InlineData("{}", "{}")]
        [InlineData("{ if (a) a;}", "{if (a) a;}")]
        [InlineData("{ if (a) a; if (b) b; }", "{if (a) a;if (b) b;}")]
        public void Block(string input, string expected)
        {
            AssertParse(input, expected, ParserCombinators.Block);
        }

        [Theory]
        [InlineData("a;", "a;")]
        [InlineData("if (a) b;", "if (a) b;")]
        [InlineData("if (a) b; else c;", "if (a) b; else c;")]
        public void Statement(string input, string expected)
        {
            AssertParse(input, expected, ParserCombinators.Statement);
        }

        [Theory]
        [InlineData("main(a, b) {}", "main(a, b) {}")]
        [InlineData("main() {}", "main() {}")]
        [InlineData("main() { a; }", "main() {a;}")]
        [InlineData("main() { if (a) b; }", "main() {if (a) b;}")]
        public void Function(string input, string expected)
        {
            AssertParse(input, expected, ParserCombinators.Function);
        }

        private void AssertParse<T>(string input, string expected, TokenListParser<CToken, T> parser)
        {
            var tokenizer = Tokenizer.Create();
            var ast = parser.Parse(tokenizer.Tokenize(input));
            ast.ToString().Should().Be(expected);
        }
    }
}