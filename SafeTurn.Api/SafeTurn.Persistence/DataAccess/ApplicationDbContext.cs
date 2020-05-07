using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SafeTurn.Domain.Shops;
using SafeTurn.Domain.Turns;
using SafeTurn.Persistence.DataAccess.Identity;

namespace SafeTurn.Persistence.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<User>
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