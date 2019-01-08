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
                .Match(Character.EqualTo('('), CToken.LParen)
                .Match(Character.EqualTo(')'), CToken.RParen)
                .Match(Character.EqualTo(';'), CToken.Semicolon)
                .Match(Character.EqualTo('{'), CToken.LBrace)
                .Match(Character.EqualTo('}'), CToken.RBrace)
                .Match(Numerics.Integer, CToken.Number)
                .Match(Span.Regex(@"\w[\w\d]*"), CToken.Identifier, true)     
                .Build();
        }
    }
}