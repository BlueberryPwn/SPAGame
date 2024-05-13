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

        public Profile AddProfile(Profile _profile)
        {
            _dbContext.Profiles.Add(_profile);
            _dbContext.SaveChanges();

            return _profile;
        }

        public Profile GetById(int ProfileId)
        {
            return _dbContext.Profiles.Find(ProfileId);
        }

        public Profile GetProfileByAccountId(int AccountId)
        {
            return _dbContext.Profiles
                .FirstOrDefault(p => p.AccountId == AccountId);
        }
    }
}
