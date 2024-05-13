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
        public DbSet<Highscore> HighScores { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
