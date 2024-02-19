using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SPAGame.Models.DTO;
using SPAGame.Repositories;
using System.Reflection.Metadata.Ecma335;

namespace SPAGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        // Registration
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.AccountName,
                Email = registerRequestDto.AccountEmail
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.AccountPassword);

            if (identityResult.Succeeded)
            {
                return Ok("The user was successfully registered. You may now login.");
            }
            return BadRequest("ERROR: The user could not be registered. Please try again.");
        }

        // Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByNameAsync(loginRequestDto.AccountName);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.AccountPassword);

                if (checkPasswordResult)
                {
                    var jwttoken = tokenRepository.CreateJWTToken(user);
                    var response = new LoginRequestDto
                    {
                        JwtToken = jwttoken
                    };
                    return Ok(response);
                }

            }
            return BadRequest("ERROR: Username or password was incorrect. Please try again.");
        }
    }
}
