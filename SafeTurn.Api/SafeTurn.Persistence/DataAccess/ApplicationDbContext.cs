using Microsoft.EntityFrameworkCore;
using SafeTurn.Domain.Shops;
using SafeTurn.Domain.Turns;
using SafeTurn.Domain.Users;
using SafeTurn.Persistence.Shops;
using SafeTurn.Persistence.Turns;
using SafeTurn.Persistence.Users;

namespace SafeTurn.Persistence.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Shop> Shops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ShopConfiguration());
            modelBuilder.ApplyConfiguration(new TurnConfiguration());
        }

        public void Save()
        {
            SaveChanges();
        }

        //TODO: transactions
    }
}