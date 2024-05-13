using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IAccountRepository _accountRepository;
        private readonly IProfileRepository _profileRepository;

        public ProfileController(ApplicationDbContext applicationDbContext, IAccountRepository accountRepository, IProfileRepository profileRepository)
        {
            _dbContext = applicationDbContext;
            _accountRepository = accountRepository;
            _profileRepository = profileRepository;
        }

        //[HttpGet("info")]

    }
}
