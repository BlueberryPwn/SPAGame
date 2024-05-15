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

        public List<HighscoreDto> GetHighscoresForToday(int amount)
        {
            var today = DateTime.Today;

            var query = _dbContext.Highscores
                // Joins Highscores with Games using AccountId and creates a new anonymous object containing both entities
                .Join(_dbContext.Games, h => h.AccountId, g => g.AccountId, (highscore, game) => new { highscore, game })
                .Where(data => data.game.GameDate.Date == today)
                .GroupBy(data => data.highscore.AccountId)
                .Select(group => new HighscoreDto
                {
                    AccountId = group.Key,
                    AccountName = group.First().highscore.Account.AccountName, // Uses navigation property to access name
                    GameDate = today,
                    Score = group.Sum(x => x.highscore.Score) // Sums scores from today
                })
                .Where(h => h.Score > 0) // Excludes any player with a score of 0
                .OrderByDescending(data => data.Score)
                .Take(amount) // Takes a set amount of players from the database
                .ToList();

            return query;
        }

        public List<HighscoreDto> GetHighscoresForAllTime(int amount)
        {
            var query = _dbContext.Highscores
                .Where(h => h.Score > 0) // Excludes any player with a score of 0
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
