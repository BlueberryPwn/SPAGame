using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPAGame.Data;
using SPAGame.Models;
using SPAGame.Models.DTOs;

namespace SPAGame.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /*public async Task<Profile> GetByAccountIdAsync(int AccountId)
        {
            return await _dbContext.Profiles.FirstOrDefaultAsync(x => x.AccountId == AccountId);
        }*/

        /*public Profile GetProfileById(int AccountId)
        {
            var profile = _dbContext.Profiles
                .Where(p => p.AccountId == AccountId)
                .Select(p => new
                {
                    p.GamesCompleted,
                    p.GamesWon,
                    p.GamesLost,
                })
                .ToList();

            return GetProfileById(AccountId);
        }*/

        public Profile GetProfileById(int AccountId)
        {
            var profile = from Profile in _dbContext.Profiles
                          select new Profile
                          {
                              GamesCompleted = Profile.GamesCompleted,
                              GamesWon = Profile.GamesWon,
                              GamesLost = Profile.GamesLost
                          };

            return profile.FirstOrDefault();
        }
    }
}
