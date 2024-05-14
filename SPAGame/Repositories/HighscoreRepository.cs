using SPAGame.Data;
using SPAGame.Models;
using SPAGame.Models.DTOs;

namespace SPAGame.Repositories
{
    public class HighscoreRepository : IHighscoreRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HighscoreRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public HighscoreModel AddHighscore(HighscoreModel _highscore)
        {
            _dbContext.Highscores.Add(_highscore);
            _dbContext.SaveChanges();

            return _highscore;
        }

        public HighscoreModel GetById(int HighscoreId)
        {
            return _dbContext.Highscores.Find(HighscoreId);
        }

        public List<HighscoreModel> GetHighscoreByAccountId(int AccountId)
        {
            return _dbContext.Highscores
                .Where(h => h.AccountId == AccountId)
                .ToList();
        }

        public List<HighscoreDto> GetHighscoresForToday(int count)
        {
            var today = DateTime.Today;

            var query = _dbContext.Highscores
                // Joins the Highscores and Games tables
                // h => h.AccountId is the left navigation property, g => g.AccountId is the right navigation property; both properties are used to join the tables
                // (h, g) => new { Highscore = h, Game = g } defines an anonymous type that combines data from both joined tables
                .Join(_dbContext.Games, h => h.AccountId, g => g.AccountId, (h, g) => new { Highscore = h, Game = g })
                .Where(data => data.Game.GameDate.Date == today) // Filters by today's date
                .OrderByDescending(data => data.Highscore.Score)
                .Take(count) // Takes a certain amount of players from the database
                .Select(data => new HighscoreDto
                {
                    AccountName = data.Highscore.Account.AccountName,
                    GameDate = data.Game.GameDate,
                    Score = data.Highscore.Score
                })
                .ToList();

            return query;
        }

        public List<HighscoreDto> GetHighscoresForAllTime(int count)
        {
            var query = _dbContext.Highscores
                .OrderByDescending(h => h.Score)
                .Take(count) // Takes a certain amount of players from the database
                .Select(h => new HighscoreDto
                {
                    AccountName = h.Account.AccountName,
                    Score = h.Score
                })
                .ToList();

            return query;
        }
    }
}
