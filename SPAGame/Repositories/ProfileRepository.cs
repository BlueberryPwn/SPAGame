using SPAGame.Data;
using SPAGame.Models;

namespace SPAGame.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ProfileModel AddProfile(ProfileModel profile)
        {
            _dbContext.Profiles.Add(profile);
            _dbContext.SaveChanges();

            return profile;
        }

        public ProfileModel GetById(int ProfileId)
        {
            return _dbContext.Profiles.Find(ProfileId);
        }

        public ProfileModel GetProfileByAccountId(int AccountId)
        {
            return _dbContext.Profiles
                .FirstOrDefault(p => p.AccountId == AccountId);
        }
    }
}
