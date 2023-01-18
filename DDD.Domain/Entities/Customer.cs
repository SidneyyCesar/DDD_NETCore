using DDD.Domain.Interfaces.Repositories;

namespace DDD.Domain.Entities
{
    public class Customer
    {
        public Customer() { }

        public int  Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
        public virtual IEnumerable<Product>? products { get; set; }

        public bool Active { get; set; }

        public bool SpecialCustomer(Customer customer)
        {
            return customer.Active && (DateTime.Now.Year - customer.CreateAt.Year) >= 5;
        }
    }
}
