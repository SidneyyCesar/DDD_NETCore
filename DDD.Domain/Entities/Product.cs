namespace DDD.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            this.Customer = new Customer();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public bool Avaliable { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}