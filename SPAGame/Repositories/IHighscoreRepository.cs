using SPAGame.Models;
using SPAGame.Models.DTOs;

namespace SPAGame.Repositories
{
    public interface IHighscoreRepository
    {
        HighscoreModel AddHighscore(HighscoreModel highscore);
        HighscoreModel GetById(int HighscoreId);
        HighscoreModel GetHighscoreByAccountId(int AccountId);
        //List<HighscoreModel> GetHighscoreByAccountId(int AccountId);
        List<HighscoreDto> GetHighscoresForToday(int amount);
        List<HighscoreDto> GetHighscoresForAllTime(int amount);
    }
}
