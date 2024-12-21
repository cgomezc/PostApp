namespace PostApp.Domain.Entities
{
    public class Denomination
    {
        public decimal Value { get; set; }
        public Denomination() { }
        public Denomination(decimal value) {   
            Value = value;
        }
    }
}
