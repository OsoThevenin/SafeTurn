using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SafeTurn.Domain.Shops;
using SafeTurn.Domain.Turns;
using SafeTurn.Persistence.DataAccess.Identity;
using ZNetCS.AspNetCore.Logging.EntityFrameworkCore;

namespace SafeTurn.Persistence.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        { }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Shop> Shops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Logs table
            LogModelBuilderHelper.Build(modelBuilder.Entity<Log>());
            modelBuilder.Entity<Log>().ToTable("Logs");
        }

        public void Save()
        {
            SaveChanges();
        }

        //TODO: transactions
    }
}