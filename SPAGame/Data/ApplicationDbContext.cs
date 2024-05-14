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

        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<GameModel>  Games { get; set; }
        public DbSet<HighscoreModel> Highscores { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }
    }
}
