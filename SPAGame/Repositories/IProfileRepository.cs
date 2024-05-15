using SPAGame.Models;

namespace SPAGame.Repositories
{
    public interface IProfileRepository
    {
        ProfileModel AddProfile(ProfileModel profile);
        ProfileModel GetById(int ProfileId);
        ProfileModel GetProfileByAccountId(int AccountId); // Note: changed from ProfileId to AccountId, if it doesn't work anymore change it back
    }
}
