using SPAGame.Models;
using SPAGame.Models.DTOs;

namespace SPAGame.Repositories
{
    public interface IGameRepository
    {
        public bool? ExistingGame(int AccountId);
        GameModel GetActiveGameByAccountId(int AccountId);
        GameModel GetGameByAccountId(int AccountId);
        GameModel GetGameById(int GameId);
        GameModel LoadGame(int AccountId);
        GameModel StartGame(int AccountId);
    }
}
