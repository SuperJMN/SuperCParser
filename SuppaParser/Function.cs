using System.Collections.Generic;

namespace SuppaParser
{
    public class Function
    {
        public PrimitiveType ReturnType { get; }
        public string Name { get; }
        public IEnumerable<Argument> Arguments { get; }
        public Block Block { get; }

        public Function(PrimitiveType returnType, string name, IEnumerable<Argument> arguments, Block block)
        {
            ReturnType = returnType;
            Name = name;
            Arguments = arguments;
            Block = block;
        }

        public override string ToString()
        {
            return $"{ReturnType} {Name}({string.Join(", ", Arguments)}) {Block}";
        }
    }
}