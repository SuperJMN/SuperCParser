using System.Collections.Generic;

namespace SuppaParser
{
    public class Function
    {
        public string Name { get; }
        public IEnumerable<Argument> Arguments { get; }
        public Block Block { get; }

        public Function(string name, IEnumerable<Argument> arguments, Block block)
        {
            Name = name;
            Arguments = arguments;
            Block = block;
        }

        public override string ToString()
        {
            return $"{Name}({string.Join(", ", Arguments)}) {Block}";
        }
    }
}