namespace DDD.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public bool Avaliable { get; set; }
        public int customerId { get; set; }
        public virtual Customer? customer { get; set; }

    }
}