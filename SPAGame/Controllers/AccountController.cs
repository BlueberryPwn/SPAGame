using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPAGame.Data;
using SPAGame.Models;
using SPAGame.Models.DTOs;
using SPAGame.Repositories;

namespace SPAGame.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IProfileRepository _profileRepository;

        public AccountController(ApplicationDbContext applicationDbContext, IProfileRepository profileRepository)
        {
            _dbContext = applicationDbContext;
            _profileRepository = profileRepository;
        }

        [HttpGet("profile")]
        public IActionResult Page(Profile profileDto)
            // Med hjälp av AccountId ska denna endpoint
            // skicka all profildata till frontend
            // relaterat till den inloggade användaren.
        {
            try
            {
                var profileData = _profileRepository.GetProfileData(profileDto.AccountId);

                return Ok(new { response = "The profile has been loaded successfully.", profileData });
            }
            catch (Exception)
            {
                return BadRequest(new { response = "ERROR: Something went wrong." });
            }
        }
    }
}