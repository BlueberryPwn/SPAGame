using SPAGame.Data;
using SPAGame.Models;
using SPAGame.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace SPAGame.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GameRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool? ExistingGame(int AccountId) // If AccountId exists in the table, proceeds to order by their last GameId and checks its GameActive; otherwise returns false
        {
            var game = _dbContext.Games
                .Where(g => g.AccountId == AccountId)
                .OrderByDescending(g => g.GameId)
                .Select(g => g.GameActive)
                .FirstOrDefault();

            return game;
        }


        public GameModel GetActiveGameByAccountId(int AccountId)
        {
            return _dbContext.Games.FirstOrDefault(g => g.AccountId == AccountId && g.GameActive);
        }

        public GameModel GetGameByAccountId(int AccountId)
        {
            return _dbContext.Games
                .FirstOrDefault(g => g.AccountId == AccountId);
        }

        public GameModel GetGameById(int GameId)
        {
            return _dbContext.Games
                .FirstOrDefault(g => g.GameId == GameId);
        }

        public GameModel LoadGame(int AccountId)
        {
            var game = _dbContext.Games
                .Where(g => g.AccountId == AccountId && g.GameActive)
                .FirstOrDefault();

            return game;
        }

        public GameModel StartGame(int AccountId) // Creates a new game; gives a random number for the user to guess in 5 attempts
        {
            Random random = new Random();

            var game = new GameModel
            {
                GameNumber = random.Next(1, 100),
                GameAttempts = 5,
                GameActive = true,
                GameDate = DateTime.Today,
                AccountId = AccountId
            };

            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            return game;
        }
    }
}