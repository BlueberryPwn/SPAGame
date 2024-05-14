using Microsoft.AspNetCore.Mvc;
using SPAGame.Data;
using SPAGame.Models;
using SPAGame.Models.DTOs;
using SPAGame.Repositories;

namespace SPAGame.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IAccountRepository _accountRepository;
        private readonly IHighscoreRepository _highscoreRepository;
        private readonly IProfileRepository _profileRepository;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(ApplicationDbContext applicationDbContext, IAccountRepository accountRepository, IHighscoreRepository highscoreRepository, IProfileRepository profileRepository, ITokenRepository tokenRepository)
        {
            _dbContext = applicationDbContext;
            _accountRepository = accountRepository;
            _highscoreRepository = highscoreRepository;
            _profileRepository = profileRepository;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var _account = new AccountModel
            {
                AccountName = dto.AccountName,
                AccountEmail = dto.AccountEmail,
                AccountPassword = BCrypt.Net.BCrypt.HashPassword(dto.AccountPassword)
            };

            var existingName = _dbContext.Accounts.FirstOrDefault(a => a.AccountName == _account.AccountName);

            if (existingName != null)
            {
                return BadRequest(new { response = "This name is taken." });
            }

            var existingEmail = _dbContext.Accounts.FirstOrDefault(a => a.AccountEmail == _account.AccountEmail);

            if (existingEmail != null)
            {
                return BadRequest(new { response = "This email address is taken." });
            }

            // Adds new account to the database
            _accountRepository.AddAccount(_account);

            var accountId = _account.AccountId;

            var _highscore = new HighscoreModel
            {
                AccountId = accountId,
                Score = dto.Score
            };

            // Gives default score connected to the new account
            _highscoreRepository.AddHighscore(_highscore);

            var _profile = new ProfileModel
            {
                AccountId = accountId,
                GamesPlayed = dto.GamesPlayed,
                GamesWon = dto.GamesWon,
                GamesLost = dto.GamesLost
            };

            // Gives default profile data connected to the new account
            _profileRepository.AddProfile(_profile);

            return Ok(new { response = "The account has been registered successfully." });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var _account = _accountRepository.GetByEmail(dto.AccountEmail);

            if (_account == null)
            {
                return BadRequest(new { response = "This email address is invalid." });
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.AccountPassword, _account.AccountPassword))
            {
                return BadRequest(new { response = "This password is invalid." });
            }

            var jwt = _tokenRepository.CreateToken(_account);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new { response = "You've logged in successfully.", jwt });

        }

        /*[HttpGet("account")]
        public IActionResult Account()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _tokenRepository.VerifyToken(jwt);

                int AccountId = int.Parse(token.Issuer);

                var _account = _accountRepository.GetById(AccountId);

                return Ok(_account);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }*/

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new { response = "You've logged out successfully." });
        }
    }
}