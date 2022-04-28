namespace TestU.Models
{
    public class Banknote
    {
        public string Name { get; }

        public decimal Value { get; }

        public Banknote(decimal value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}
