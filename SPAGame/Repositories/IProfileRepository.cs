using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface IProfileRepository
    {
        ProfileModel AddProfile(ProfileModel profile);
        ProfileModel GetById(int ProfileId);
        ProfileModel GetProfileByAccountId(int ProfileId);
    }
}
