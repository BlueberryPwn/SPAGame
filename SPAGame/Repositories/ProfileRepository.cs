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

        public int GetAccountId(int AccountId)
        {
            var profile = _dbContext.Profiles
                .Where(p => p.AccountId == AccountId)
                .Select(p => p.AccountId)
                .FirstOrDefault();

            return profile;
        }

        public Profile GetProfileData(int AccountId)
        {
            var profileData = _dbContext.Profiles
                .Where(p => p.AccountId == AccountId)
                .FirstOrDefault();

            return profileData;
        }
    }
}
