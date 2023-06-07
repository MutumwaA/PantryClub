using Microsoft.EntityFrameworkCore;
using PantryClub.Services.Orders.Models;

namespace PantryClub.Services.Orders.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                ProductName = "Apple",
                Price = 15,
                Quantity = 9
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                ProductName = "Orange",
                Price = 17,
                Quantity = 4
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                ProductName = "Grape",
                Price = 19,
                Quantity = 6
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                ProductName = "Avocado",
                Price = 11,
                Quantity = 8
            });
        }

    }
}
