using System.Collections.Generic;

namespace SuppaParser
{
    public class Program : CSyntax
    {
        public IEnumerable<Function> Functions { get; }

        public Program(IEnumerable<Function> functions)
        {
            Functions = functions;
        }

        public override string ToString()
        {
            return string.Concat(Functions);
        }
    }
}