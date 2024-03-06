using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface IProfileRepository
    {
        /*Task<Profile> GetByAccountIdAsync(int AccountId);*/

        Profile GetProfileById(int AccountId);
    }
}
