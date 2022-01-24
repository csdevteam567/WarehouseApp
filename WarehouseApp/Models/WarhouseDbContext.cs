using Microsoft.EntityFrameworkCore;

namespace WarehouseApp.Models
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext()
        {}

        public WarehouseDbContext(DbContextOptions options) : base(options){}

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Good> Goods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=HOMEPC\\SQLEXPRESS;Initial Catalog=WarehouseDb;Persist Security Info=True;User ID=sa;Password=Admin1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
