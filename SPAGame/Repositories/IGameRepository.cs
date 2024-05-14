using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface IGameRepository
    {
        GameModel LoadGame(int AccountId);
        GameModel StartGame(int AccountId);
    }
}
