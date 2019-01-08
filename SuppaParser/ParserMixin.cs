using Superpower;
using Superpower.Parsers;

namespace SuppaParser
{
    public static class ParserMixin
    {
        public static TokenListParser<CToken, T> BetweenParenthesis<T>(this TokenListParser<CToken, T> self)
        {
            return self.Between(Token.EqualTo(CToken.LParen), Token.EqualTo(CToken.RParen));
        }

        public static TokenListParser<CToken, T> BetweenBraces<T>(this TokenListParser<CToken, T> self)
        {
            return self.Between(Token.EqualTo(CToken.LBrace), Token.EqualTo(CToken.RBrace));
        }
    }
}