namespace SuppaParser
{
    public class Argument
    {
        public string Name { get; }

        public Argument(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}