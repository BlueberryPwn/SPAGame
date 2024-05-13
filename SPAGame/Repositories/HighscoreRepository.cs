using SPAGame.Data;
using SPAGame.Models;

namespace SPAGame.Repositories
{
    public class HighscoreRepository : IHighscoreRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HighscoreRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Highscore AddHighscore(Highscore _highscore)
        {
            _dbContext.HighScores.Add(_highscore);
            _dbContext.SaveChanges();

            return _highscore;
        }
    }
}
