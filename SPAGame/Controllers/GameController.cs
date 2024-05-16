using Microsoft.AspNetCore.Mvc;
using SPAGame.Data;
using SPAGame.Models;
using SPAGame.Models.DTOs;
using SPAGame.Repositories;

namespace SPAGame.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IAccountRepository _accountRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IHighscoreRepository _highscoreRepository;
        private readonly IProfileRepository _profileRepository;

        public GameController(ApplicationDbContext dbContext, IAccountRepository accountRepository, IGameRepository gameRepository, IHighscoreRepository highscoreRepository, IProfileRepository profileRepository)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
            _gameRepository = gameRepository;
            _highscoreRepository = highscoreRepository;
            _profileRepository = profileRepository;
        }

        [HttpGet("gamecheck")] // Checks if AccountId has an entry inside the table and returns the GameActive of their last entry
        public IActionResult GameActiveCheck(int AccountId)
        {
            var game = _gameRepository.ExistingGame(AccountId);

            return Ok(game);
        }

        [HttpGet("getgame")] // Gets the ongoing game's details
        public IActionResult GetGame(int AccountId)
        {
            var account = _accountRepository.GetById(AccountId);

            if (account == null)
            {
                return NotFound(new { response = "The account could not be found." });
            }

            var game = _gameRepository.LoadGame(AccountId);

            if (game == null)
            {
                return NotFound("The account does not have an active game.");
            }

            return Ok(game);
        }

        [HttpPost("playgame")] // Starts a new game for the player
        public IActionResult PlayGame(int AccountId)
        {
            var existingGame = _gameRepository.GetActiveGameByAccountId(AccountId);

            if (existingGame != null)
            {
                return BadRequest(new { response = "The account already has an active game." });
            }

            var account = _accountRepository.GetById(AccountId);

            if (account == null)
            {
                return NotFound(new { response = "The account could not be found." });
            }

            var game = _gameRepository.StartGame(AccountId);

            return Ok(game);
        }

        [HttpPost("makeguess")] // Game returns different results depending on the guess
        public IActionResult MakeGuess(int AccountId, int GameId, int GameGuess)
        {
            var game = _gameRepository.GetGameById(GameId);

            if (game == null)
            {
                return NotFound(new { response = "The game could not be found." });
            }
            else if (game.GameActive == false)
            {
                return NotFound(new { response = "The game has already finished." });
            }

            var highscore = _highscoreRepository.GetHighscoreByAccountId(AccountId);

            if (highscore == null)
            {
                return NotFound(new { response = "The highscore could not be found." });
            }

            var profile = _profileRepository.GetProfileByAccountId(AccountId);

            if (profile == null)
            {
                return NotFound(new { response = "The profile could not be found." });
            }

            try
            {
                if (game.GameAttempts == 0)
                {
                    profile.GamesPlayed++;
                    profile.GamesLost++;
                }
                else if (GameGuess > game.GameNumber)
                {
                    game.GameAttempts--;
                }
                else if (GameGuess < game.GameNumber)
                {
                    game.GameAttempts--;
                }
                else
                {
                    profile.GamesPlayed++;
                    profile.GamesWon++;
                    highscore.Score++;
                }

                // Returns different responses depending on the guess
                if (game.GameAttempts == 0)
                {
                    game.GameActive = false;
                    _dbContext.SaveChanges();
                    return Ok( new { response = $"Game over! The correct number was: {game.GameNumber}.", game.GameActive, game.GameNumber });
                }
                else if (GameGuess > game.GameNumber)
                {
                    _dbContext.SaveChanges();
                    return Ok(new { response = "Too high! Guess lower.", game.GameActive, game.GameAttempts });
                }
                else if (GameGuess < game.GameNumber)
                {
                    _dbContext.SaveChanges();
                    return Ok(new { response = "Too low! Guess higher.", game.GameActive, game.GameAttempts });
                }
                else
                {
                    game.GameActive = false;
                    _dbContext.SaveChanges();
                    return Ok( new { response = $"Congratulations! You guessed the correct number: {game.GameNumber}!", game.GameActive, game.GameNumber });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
