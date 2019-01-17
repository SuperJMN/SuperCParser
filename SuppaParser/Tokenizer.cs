using Superpower;
using Superpower.Parsers;
using Superpower.Tokenizers;

namespace SuppaParser
{
    public static class Tokenizer
    {
        public static Tokenizer<CToken> Create()
        {
            return new TokenizerBuilder<CToken>()
                .Ignore(Span.WhiteSpace)
                .Match(Span.EqualTo("if"), CToken.If, true)
                .Match(Span.EqualTo("else"), CToken.Else, true)
                .Match(Span.EqualTo("int"), CToken.Int, true)
                .Match(Span.EqualTo("char"), CToken.Char, true)
                .Match(Span.EqualTo("void"), CToken.Void, true)
                .Match(Span.EqualTo("double"), CToken.Double, true)
                .Match(Span.EqualTo("float"), CToken.Float, true)
                .Match(Character.EqualTo('('), CToken.LParen)
                .Match(Character.EqualTo(')'), CToken.RParen)
                .Match(Character.EqualTo(';'), CToken.Semicolon)
                .Match(Character.EqualTo('{'), CToken.LBrace)
                .Match(Character.EqualTo('}'), CToken.RBrace)
                .Match(Character.EqualTo(','), CToken.Comma)
                .Match(Numerics.Integer, CToken.Number)
                .Match(Span.Regex(@"\w[\w\d]*"), CToken.Identifier, true)     
                .Build();
        }
    }
}