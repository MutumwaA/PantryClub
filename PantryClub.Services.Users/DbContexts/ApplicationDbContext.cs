using Microsoft.EntityFrameworkCore;
using PantryClub.Services.Users.Models;

namespace PantryClub.Services.Users.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = Guid.NewGuid(),
                FirstName = "Anesu",
                LastName = "Mutumwa",
                Email = "anesu@gmail.com",
                DateOfBirth = new DateTime(1990, 1, 1),
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = Guid.NewGuid(),
                FirstName = "Angel",
                LastName = "Mutumwa",
                Email = "angel@gmail.com",
                DateOfBirth = new DateTime(1980, 1, 1),
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = Guid.NewGuid(),
                FirstName = "Tendai",
                LastName = "Mutumwa",
                Email = "tendai@gmail.com",
                DateOfBirth = new DateTime(1970, 1, 1),
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = Guid.NewGuid(),
                FirstName = "Arielle",
                LastName = "Mutumwa",
                Email = "arielle@gmail.com",
                DateOfBirth = new DateTime(1960, 1, 1),
            });
        }

    }
}