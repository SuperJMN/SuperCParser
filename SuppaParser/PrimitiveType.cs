namespace SuppaParser
{
    public class PrimitiveType
    {
        public string Name { get; }
        public static PrimitiveType Int = new PrimitiveType("int");
        public static PrimitiveType Char = new PrimitiveType("char");
        public static PrimitiveType Float = new PrimitiveType("float");
        public static PrimitiveType Double = new PrimitiveType("double");
        public static PrimitiveType Void = new PrimitiveType("void");

        private PrimitiveType(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}