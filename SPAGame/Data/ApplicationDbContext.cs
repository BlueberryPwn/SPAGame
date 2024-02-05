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

        public DbSet<Account> Account { get; set; }
    }
}
