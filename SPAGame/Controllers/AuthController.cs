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
        public IActionResult Register(RegisterDto registerDto)
        {
            var _account = new Account
            {
                AccountName = registerDto.AccountName,
                AccountEmail = registerDto.AccountEmail,
                AccountPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.AccountPassword),
                GamesCompleted = registerDto.GamesCompleted,
                GamesLost = registerDto.GamesLost,
                GamesWon = registerDto.GamesWon
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