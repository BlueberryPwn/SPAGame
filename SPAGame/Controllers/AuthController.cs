using Microsoft.AspNetCore.Mvc;
using SPAGame.Data;
using SPAGame.Models;
using SPAGame.Models.DTO;
using SPAGame.Models.Helpers;
using SPAGame.Repositories;

namespace SPAGame.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;
        private readonly IAccountRepository _repository;

        public AuthController(ApplicationDbContext applicationDbContext, JwtService jwtService, IAccountRepository repository)
        {
            _context = applicationDbContext;
            _jwtService = jwtService;
            _repository = repository;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var account = new Account
            {
                AccountName = dto.AccountName,
                AccountEmail = dto.AccountEmail,
                AccountPassword = BCrypt.Net.BCrypt.HashPassword(dto.AccountPassword)
            };

            var existingName = _context.Accounts.FirstOrDefault(a => a.AccountName == account.AccountName);

            if (existingName != null)
            {
                return BadRequest(new { message = "This name is already in use. Please try another." });
            }

            var existingEmail = _context.Accounts.FirstOrDefault(a => a.AccountEmail == account.AccountEmail);

            if (existingEmail != null)
            {
                return BadRequest(new { message = "This email address is already in use. Please try another." });
            }

            return Created("Success! The account has been registered.", _repository.Create(account));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var account = _repository.GetByEmail(dto.AccountEmail);

            if (account == null)
            {
                return BadRequest(new { message = "This email address is incorrect. Please try again." });
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.AccountPassword, account.AccountPassword))
            {
                return BadRequest(new { message = "This password is incorrect. Please try again." });
            }

            var jwt = _jwtService.Generate(account.AccountId);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "Success! You're now logged in."
            });
        }

        [HttpGet("account")]
        public IActionResult Account()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int accountId = int.Parse(token.Issuer);

                var account = _repository.GetById(accountId);

                return Ok(account);
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

            return Ok(new
            {
                message = "Success! You've been logged out."
            });
        }
    }
}