using FluentAssertions;
using Xunit;

namespace SuppaParser.Tests
{
    public class CParserSpecs
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("if (a) b;", "if (a) b;")]
        [InlineData("if (a) b; else c;", "if (a) b; else c;")]
        [InlineData("if (a) {b; c; d; }", "if (a) {b;c;d;}")]
        public void If(string input, string expected)
        {
            AssertParse(input, expected);
        }

        private static string Wrap(string body)
        {
            return $"int main() {{{body}}}";
        }

        private void AssertParse(string input, string expected)
        {
            var tokenizer = Tokenizer.Create();
            var parser = new CParser(tokenizer);
            var ast = parser.Parse(Wrap(input));
            ast.ToString().Should().Be(Wrap(expected));
        }
    }
}
