using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) {}
        public DbSet<Product> Product { get; set; }
        public DbSet<Seller> Seller { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=AGUM2393\\SQLEXPRESS;Database=Ecommerce;Trusted_Connection=True;TrustServerCertificate=True;", builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}