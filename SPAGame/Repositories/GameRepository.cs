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

        public GameModel StartGame(int AccountId)
        {
            //var account = _dbContext.Accounts.Find(AccountId);

            Random random = new Random();

            var game = new GameModel
            {
                GameNumber = random.Next(1,100),
                GameAttempts = 5,
                GameActive = true,
                GameDate = DateTime.Today,
                AccountId = AccountId
            };

            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            return game;
        }

        /*public GameModel MakeGuess(int GameGuess, GameDto gameDto)
        {
            if (gameDto.GameGuess > gameDto.GameNumber)
            {
                gameDto.GameAttempts--;
            }
            else if (gameDto.GameGuess < gameDto.GameNumber)
            {
                gameDto.GameAttempts--;
            }
            else if (gameDto.GameAttempts == 0)
            {
                gameDto.GameActive = false;
                gameDto.GamesPlayed++;
                gameDto.GamesLost++;
                _dbContext.SaveChanges();
            }
            else
            {
                gameDto.GameActive = false;
                gameDto.GamesPlayed++;
                gameDto.GamesWon++;
                _dbContext.SaveChanges();
            }
        }*/
    }
}