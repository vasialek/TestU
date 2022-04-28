namespace TestU.Models
{
    public class Banknote
    {
        public string Name { get; }

        public decimal Value { get; }

        public int Available { get; set; }

        public Banknote(decimal value, string name)
            : this(value, name, 1)
        {
        }

        public Banknote(decimal value, string name, int available)
        {
            Value = value;
            Name = name;
            Available = available;
        }
    }
}
