namespace SuppaParser
{
    internal class StatementExpression : Statement
    {
        public Expression Expression { get; }

        public StatementExpression(Expression expression)
        {
            Expression = expression;
        }

        public override string ToString()
        {
            return Expression + ";";
        }
    }
}