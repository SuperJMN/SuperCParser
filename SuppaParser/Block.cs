using System.Collections.Generic;

namespace SuppaParser
{
    public class Block : Statement
    {
        public IEnumerable<Statement> Statements { get; }

        public Block(IEnumerable<Statement> statements)
        {
            Statements = statements;
        }

        public override string ToString()
        {
            return "{" + string.Concat(Statements) + "}";
        }
    }
}