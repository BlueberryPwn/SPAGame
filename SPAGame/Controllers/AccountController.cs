using Microsoft.AspNetCore.Mvc;
using SPAGame.Data;
using SPAGame.Models.DTOs;
using SPAGame.Repositories;

namespace SPAGame.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHighscoreRepository _highscoreRepository;
        private readonly IProfileRepository _profileRepository;

        public AccountController(ApplicationDbContext applicationDbContext, IHighscoreRepository highscoreRepository, IProfileRepository profileRepository)
        {
            _dbContext = applicationDbContext;
            _highscoreRepository = highscoreRepository;
            _profileRepository = profileRepository;
        }

        [HttpGet("profile")]
        public IActionResult Account(int AccountId)
        {
            var profile = _profileRepository.GetProfileByAccountId(AccountId);

            if (profile == null)
            {
                return NotFound(new { response = "The profile could not be found." });
            }

            _highscoreRepository.GetHighscoreByAccountId(AccountId);

            var profileDto = new ProfileDto
            {
                GamesPlayed = profile.GamesPlayed,
                GamesWon = profile.GamesWon,
                GamesLost = profile.GamesLost
            };

            return Ok(profileDto);
        }
    }
}
