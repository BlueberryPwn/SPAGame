using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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
        private readonly IHighscoreRepository _highscoreRepository;
        private readonly IProfileRepository _profileRepository;

        public ProfileController(ApplicationDbContext applicationDbContext, IHighscoreRepository highscoreRepository, IProfileRepository profileRepository)
        {
            _dbContext = applicationDbContext;
            _highscoreRepository = highscoreRepository;
            _profileRepository = profileRepository;
        }

        [HttpGet("{AccountId}")]
        public IActionResult GetProfileData(int AccountId)
        {
            var profile = _profileRepository.GetProfileByAccountId(AccountId);

            if (profile == null)
            {
                return NotFound(new { response = "This profile could not be found." });
            }

            var highscore = _highscoreRepository.GetHighscoreByAccountId(AccountId);

            var profileDto = new ProfileDto
            {
                Score = highscore.Sum(h =>  h.Score),
                GamesPlayed = profile.GamesPlayed,
                GamesWon = profile.GamesWon,
                GamesLost = profile.GamesLost
            };

            return Ok(profileDto);
        }
    }
}
