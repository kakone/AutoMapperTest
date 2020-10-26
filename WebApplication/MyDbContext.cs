using Microsoft.EntityFrameworkCore;

namespace WebApplication
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Order> Orders { get; set; }

        public void SeedDatabase()
        {
            var product1 = new Product() { Name = "Product1", Price = 5.55M };
            var product2 = new Product() { Name = "Product2", Price = 10 };

            var order = new Order() { Id = 1, Number = "ORDER_001" };
            order.AddLine(new OrderLine() { Id = 1, Quantity = 1, Product = product1, Order = order });
            order.AddLine(new OrderLine() { Id = 2, Quantity = 2, Product = product2, Order = order });
            Orders.Add(order);

            order = new Order() { Id = 2, Number = "ORDER_002" };
            order.AddLine(new OrderLine() { Id = 3, Quantity = 10, Product = product1, Order = order });
            Orders.Add(order);

            SaveChanges();
        }
    }
}
