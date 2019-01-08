using Superpower;
using Superpower.Parsers;

namespace SuppaParser
{
    internal static class ParserCombinators
    {
        private static readonly TokenListParser<CToken, string> Identifier =
            Token.EqualTo(CToken.Identifier).Select(x => x.ToStringValue());

        private static readonly TokenListParser<CToken, Expression> Expression =
            from i in Identifier
            select (Expression)new IdentifierExpression(i);

        private static readonly TokenListParser<CToken, Statement> Statement = from e in Expression
            select (Statement) new StatementExpression(e);

        private static readonly TokenListParser<CToken, Statement> IfStatement =
            from keyw in Token.EqualTo(CToken.If)
            from expr in Expression.BetweenParenthesis()
            from st in Statement
            select (Statement)new IfStatement(expr, st);

        public static readonly TokenListParser<CToken, Program> Program = from st in IfStatement select new Program(st);
    }
}