namespace SuppaParser
{
    internal class IfStatement : Statement
    {
        public Expression Condition { get; }
        public Statement Statement { get; }

        public IfStatement(Expression condition, Statement statement)
        {
            Condition = condition;
            Statement = statement;
        }

        public override string ToString()
        {
            return $"if ({Condition}) {Statement};";
        }
    }
}