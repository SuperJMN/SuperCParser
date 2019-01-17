namespace SuppaParser
{
    public class Argument
    {
        public PrimitiveType PrimitiveType { get; }
        public string Name { get; }

        public Argument(PrimitiveType primitiveType, string name)
        {
            PrimitiveType = primitiveType;
            Name = name;
        }

        public override string ToString()
        {
            return $"{PrimitiveType} {Name}";
        }
    }
}