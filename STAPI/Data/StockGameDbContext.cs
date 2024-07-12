using Microsoft.EntityFrameworkCore;
using STAPI.Models;

namespace STAPI.Data
{
    public class StockGameDbContext : DbContext
    {
        public StockGameDbContext(DbContextOptions<StockGameDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Trade> Trades { get; set; }
    }
}
