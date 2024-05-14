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

        public HighscoreModel AddHighscore(HighscoreModel highscore)
        {
            _dbContext.Highscores.Add(highscore);
            _dbContext.SaveChanges();

            return highscore;
        }

        public HighscoreModel GetById(int HighscoreId)
        {
            return _dbContext.Highscores.Find(HighscoreId);
        }

        public HighscoreModel GetHighscoreByAccountId(int AccountId)
        {
            return _dbContext.Highscores
                .Where(h => h.AccountId == AccountId)
                .FirstOrDefault();
        }

        /*public List<HighscoreModel> GetHighscoreByAccountId(int AccountId)
        {
            return _dbContext.Highscores
                .Where(h => h.AccountId == AccountId)
                .ToList();
        }*/

        public List<HighscoreDto> GetHighscoresForToday(int amount)
        {
            var today = DateTime.Today;

            var query = _dbContext.Highscores
                // This query joins the Highscores and Games tables
                // The h => h.AccountId and g => g.AccountId properties are used for the join
                // (h, g) => new { Highscore = h, Game = g } combines data from both joined tables
                .Join(_dbContext.Games, h => h.AccountId, g => g.AccountId, (h, g) => new { Highscore = h, Game = g })
                .Where(data => data.Game.GameDate.Date == today) // Filters by today's date
                .OrderByDescending(data => data.Highscore.Score)
                .Take(amount) // Takes a set amount of players from the database
                .Select(data => new HighscoreDto
                {
                    AccountId = data.Highscore.AccountId,
                    AccountName = data.Highscore.Account.AccountName,
                    GameDate = data.Game.GameDate,
                    Score = data.Highscore.Score
                })
                .ToList();

            return query;
        }

        public List<HighscoreDto> GetHighscoresForAllTime(int amount)
        {
            var query = _dbContext.Highscores
                .OrderByDescending(h => h.Score)
                .Take(amount) // Takes a set amount of players from the database
                .Select(h => new HighscoreDto
                {
                    AccountId = h.AccountId,
                    AccountName = h.Account.AccountName,
                    Score = h.Score
                })
                .ToList();

            return query;
        }
    }
}
