using System;
using Superpower;
using Superpower.Parsers;
using static Superpower.Parse;

namespace SuppaParser
{
    public static class ParserCombinators
    {
        private static readonly TokenListParser<CToken, string> Identifier =
            Token.EqualTo(CToken.Identifier).Select(x => x.ToStringValue());

        private static readonly TokenListParser<CToken, Expression> Expression =
            from i in Identifier
            select (Expression)new IdentifierExpression(i);

        private static readonly TokenListParser<CToken, Statement> ExpressionStatement =
            from e in Identifier
            from sc in Token.EqualTo(CToken.Semicolon)
            select (Statement)new StatementExpression(new IdentifierExpression(e));

        private static readonly TokenListParser<CToken, Statement> SingleStatement =
            ExpressionStatement.Or(Ref(() => IfStatement));

        public static readonly TokenListParser<CToken, Statement> Block =
            from statements in Ref(() => Statement.Many().BetweenBraces())
            select (Statement)new Block(statements);

        public static readonly TokenListParser<CToken, Statement> Statement = SingleStatement.Or(Block);

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

        private static readonly TokenListParser<CToken, Argument> Argument =
            from i in Identifier
            select new Argument(i);

        public static readonly TokenListParser<CToken, Function> Function =
            from name in Identifier
            from arguments in Argument.CommaSeparated().BetweenParenthesis()
            from block in Block
            select new Function(name, arguments, (Block)block);

        public static readonly TokenListParser<CToken, Program> Program = 
            from fs in Function.Many()
            select new Program(fs);
    }
}