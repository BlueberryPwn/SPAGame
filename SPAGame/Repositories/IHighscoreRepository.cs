using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface IHighscoreRepository
    {
        Highscore AddHighscore(Highscore highscore);
        Highscore GetById(int HighscoreId);
        List<Highscore> GetHighscoreByAccountId(int AccountId);
    }
}
