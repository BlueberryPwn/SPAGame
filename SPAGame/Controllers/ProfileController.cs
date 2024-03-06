using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPAGame.Data;
using SPAGame.Models;
using SPAGame.Models.DTOs;
using SPAGame.Repositories;

namespace SPAGame.Controllers
{
    [Route("profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IProfileRepository _profileRepository;

        public ProfileController(ApplicationDbContext applicationDbContext, IProfileRepository profileRepository)
        {
            _dbContext = applicationDbContext;
            _profileRepository = profileRepository;
        }

        /*[HttpGet("page")]
        public async Task<IActionResult> GetProfileById([FromRoute] int AccountId)
        {
            var profile = await _dbContext.Profiles.Include(p => p.AccountId).Select(p =>
                new ProfileDto()
                {
                    AccountId = p.AccountId,
                    GamesCompleted = p.GamesCompleted,
                    GamesWon = p.GamesWon,
                    GamesLost = p.GamesLost
                }).SingleOrDefaultAsync(p => p.AccountId == AccountId);

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }*/

        [HttpGet("page")]
        public IActionResult GetProfile(ProfileDto dto)
        {
            try
            {
                var profile = _profileRepository.GetProfileById(dto.AccountId);

                return Ok(profile);
            }
            catch (Exception)
            {
                return BadRequest(new { response = "ERROR: Something went wrong." });
            }
            
        }
    }
}