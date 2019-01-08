namespace SuppaParser
{
    public class Program : CSyntax
    {
        public Statement Statement { get; }

        public Program(Statement statement)
        {
            Statement = statement;
        }

        public override string ToString()
        {
            return Statement.ToString();
        }
    }
}