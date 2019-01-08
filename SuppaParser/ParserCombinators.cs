using Superpower;
using Superpower.Parsers;
using static Superpower.Parse;

namespace SuppaParser
{
    internal static class ParserCombinators
    {
        private static readonly TokenListParser<CToken, string> Identifier =
            Token.EqualTo(CToken.Identifier).Select(x => x.ToStringValue());

        private static readonly TokenListParser<CToken, Expression> Expression =
            from i in Identifier
            select (Expression)new IdentifierExpression(i);

        private static readonly TokenListParser<CToken, Statement> SingleStatement =
            from e in Expression
            from sc in Token.EqualTo(CToken.Semicolon)
            select (Statement)new StatementExpression(e);

        private static readonly TokenListParser<CToken, Statement> Block =
            from statements in Ref(() => Statement.Many().BetweenBraces())
            select (Statement)new Block(statements);

        private static readonly TokenListParser<CToken, Statement> Statement = SingleStatement.Or(Block);

        private static readonly TokenListParser<CToken, Statement> Else =
            from elsekeyw in Token.EqualTo(CToken.Else)
            from falseStmt in Statement
            select falseStmt;

        private static readonly TokenListParser<CToken, Statement> IfStatement =
            from keyw in Token.EqualTo(CToken.If)
            from condition in Expression.BetweenParenthesis()
            from trueStmt in Statement
            from elseExpr in Else.OptionalOrDefault()
            select (Statement)new IfStatement(condition, trueStmt, elseExpr);
        
        public static readonly TokenListParser<CToken, Program> Program = from st in IfStatement select new Program(st);
    }
}