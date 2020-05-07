using Microsoft.EntityFrameworkCore;
using SafeTurn.Domain.Shops;
using SafeTurn.Domain.Turns;

namespace SafeTurn.Persistence.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        { }

        public DbSet<Turn> Turns { get; set; }
        public DbSet<Shop> Shops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public void Save()
        {
            SaveChanges();
        }

        //TODO: transactions
    }
}