using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface IProfileRepository
    {
        int GetAccountId(int AccountId);
        Profile GetProfileData(int AccountId);
    }
}
