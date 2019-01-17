using FluentAssertions;
using Xunit;

namespace SuppaParser.Tests
{
    public class CParserSpecs
    {
        [Fact]
        public void If()
        {
            AssertParse("if (a) b;", "if (a) b;");
        }

        [Fact]
        public void Empty()
        {
            AssertParse("", "");
        }

        private static string Wrap(string body)
        {
            return $"main() {{{body}}}";
        }

        [Fact]
        public void IfElse()
        {
            AssertParse("if (a) b; else c;", "if (a) b; else c;");
        }

        [Fact]
        public void IfBlock()
        {
            AssertParse("if (a) {b; c; d; }", "if (a) {b;c;d;}");
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
