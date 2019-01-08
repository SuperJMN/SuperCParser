namespace SuppaParser
{
    internal class IfStatement : Statement
    {
        public Expression Condition { get; }
        public Statement Statement { get; }
        public Statement ElseStatement { get; }

        public IfStatement(Expression condition, Statement statement, Statement elseStatement = null)
        {
            Condition = condition;
            Statement = statement;
            ElseStatement = elseStatement;
        }

        public override string ToString()
        {
            var elseStr = ElseStatement != null ? $" else {ElseStatement}" : "";
            return $"if ({Condition}) {Statement}{elseStr}";
        }
    }
}