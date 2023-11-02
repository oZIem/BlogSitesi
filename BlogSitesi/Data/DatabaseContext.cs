using BlogSitesi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlogSitesi.Data
{
    public class DatabaseContext : DbContext

    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Genel",
                    IsActive = true
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    IsActive = true,
                    IsAdmin = true,
                    Name = "Admin",
                    SurName = "User",
                    Email = "admin@bloger.com",
                    Password = "1234",
                    UserName = "Admin",
                });
            base.OnModelCreating(modelBuilder);
        }
    


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB ; database=BlogSitesi ; integrated security=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
