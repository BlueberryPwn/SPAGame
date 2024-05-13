using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface IHighscoreRepository
    {
        Highscore AddHighscore(Highscore highscore);
    }
}
