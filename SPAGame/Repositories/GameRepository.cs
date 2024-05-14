using SPAGame.Data;
using SPAGame.Models;
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

        public GameModel LoadGame(int AccountId)
        {
            var game = _dbContext.Games
                .Where(g => g.AccountId == AccountId && g.GameActive)
                .FirstOrDefault();

            return game;
        }

        public GameModel StartGame(int AccountId)
        {
            Random random = new Random();

            var game = new GameModel
            {
                GameNumber = random.Next(1,100),
                GameAttempts = 0,
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
