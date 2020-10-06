using Microsoft.EntityFrameworkCore;
using Products.API.Model;

namespace Products.API.Database
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Processor> Processors { get; set; }
        public DbSet<GraphicCard> GraphicCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Processor>().HasIndex(x => x.ID).IsUnique();
            modelBuilder.Entity<GraphicCard>().HasIndex(x => x.ID).IsUnique();
        }
    }
}
