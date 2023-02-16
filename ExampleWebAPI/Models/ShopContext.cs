using Microsoft.EntityFrameworkCore;

namespace ExampleWebAPI.Models
{
    public class ShopContext: DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(a => a.Category)
                .HasForeignKey(a => a.CategoryId);

            modelBuilder.Seed();
        }
        public DbSet<Product> Products { get; set; } //advises entity framework this is a table in the database and write queries against the Product table
        public DbSet<Category> Categories  { get; set; }
    }

}
