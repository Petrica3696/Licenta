using DataAccess.Write.Configurations.Entities;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace DataAccess.Write
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Recommendations> Recommendations { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RecommendationsConfiguration());
            modelBuilder.ApplyConfiguration(new WishlistConfiguration());
            modelBuilder.ApplyConfiguration(new CommentsConfiguration());
        }
    }
}