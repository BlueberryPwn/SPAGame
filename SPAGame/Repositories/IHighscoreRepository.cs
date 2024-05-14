using SPAGame.Models;
using SPAGame.Models.DTOs;

namespace SPAGame.Repositories
{
    public interface IHighscoreRepository
    {
        HighscoreModel AddHighscore(HighscoreModel highscore);
        HighscoreModel GetById(int HighscoreId);
        List<HighscoreModel> GetHighscoreByAccountId(int AccountId);
        List<HighscoreDto> GetHighscoresForToday(int count);
        List<HighscoreDto> GetHighscoresForAllTime(int count);
    }
}
