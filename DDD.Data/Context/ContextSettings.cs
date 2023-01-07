using DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Data.Context
{
    public class ContextSettings: DbContext
    {
        public ContextSettings(DbContextOptions options) :base(options)
        {

        }
       

        public DbSet<Customer> Customers { get; set; }
    }
}
