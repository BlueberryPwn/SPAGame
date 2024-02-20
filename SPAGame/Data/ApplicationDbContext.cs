using Microsoft.EntityFrameworkCore;
using SPAGame.Models;

namespace SPAGame.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Game>  Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity => { entity.HasIndex(e => e.AccountEmail).IsUnique(); });
        }
    }
}
