using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) {}
        public DbSet<Product> Product { get; set; }
        public DbSet<Seller> Seller { get; set; }
    }
}