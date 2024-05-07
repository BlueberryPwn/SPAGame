using Microsoft.AspNetCore.Mvc;
using SPAGame.Data;
using SPAGame.Models;
using SPAGame.Models.DTOs;
using SPAGame.Repositories;

namespace SPAGame.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IAccountRepository _accountRepository;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(ApplicationDbContext applicationDbContext, IAccountRepository accountRepository, ITokenRepository tokenRepository)
        {
            _dbContext = applicationDbContext;
            _accountRepository = accountRepository;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("register")]
        // Uppdatera register till att även skapa
        // en ny rad inuti tabellen Profiles i databasen
        // som stämmer överens med AccountId för det nya kontot
        // samtidigt som kontot skapas
        public IActionResult Register(RegisterDto registerDto)
        {
            var _account = new Account
            {
                AccountName = registerDto.AccountName,
                AccountEmail = registerDto.AccountEmail,
                AccountPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.AccountPassword),
            };

            var existingName = _dbContext.Accounts.FirstOrDefault(a => a.AccountName == _account.AccountName);

            if (existingName != null)
            {
                return BadRequest(new { response = "This name is already in use." });
            }

            var existingEmail = _dbContext.Accounts.FirstOrDefault(a => a.AccountEmail == _account.AccountEmail);

            if (existingEmail != null)
            {
                return BadRequest(new { response = "This email address is already in use." });
            }

            return Created("The account has been registered successfully.", _accountRepository.Create(_account));
        }

        [HttpPost("login")]
        // Implementera kod som gör att AccountId
        // följer med vid inloggningen.
        // På så sätt kan det sättas inuti en useState
        // som kan användas senare för att ta fram datan
        // relaterat till den inloggade användaren (via AccountId).
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

            var jwt = _tokenRepository.CreateToken(_account.AccountId);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            var accountDetails = new
            {
                _account.AccountId,
                _account.AccountName,
            };

            return Ok(new { response = "You've logged in successfully.", accountDetails});

        }

        [HttpGet("account")]
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
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new { response = "You've logged out successfully." });
        }
    }
}