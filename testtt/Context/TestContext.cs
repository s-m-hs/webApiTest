using Microsoft.EntityFrameworkCore;
using Models;
namespace testtt.Context
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order_Product> Order_Products { get; set; }
    }
}
