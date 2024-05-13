using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface IProfileRepository
    {
        Profile AddProfile(Profile profile);
        Profile GetById(int ProfileId);
        Profile GetProfileByAccountId(int ProfileId);
    }
}
