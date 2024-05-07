using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPAGame.Data;
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
    }
}
