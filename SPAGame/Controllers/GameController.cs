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

        [HttpGet("getgame")]
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

        [HttpPost("playgame")]
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

        [HttpPost("makeguess")]
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
                    //game.GameActive = false;
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
                    //game.GameActive = false;
                    profile.GamesPlayed++;
                    profile.GamesWon++;
                    highscore.Score++;
                }

                //_dbContext.SaveChanges(); // Saves initial changes to the database before returning a response

                // Returns different responses depending on the guess
                if (game.GameAttempts == 0)
                {
                    game.GameActive = false;
                    _dbContext.SaveChanges();
                    return Ok($"Game over! The correct number was: {game.GameNumber}.");
                }
                else if (GameGuess > game.GameNumber)
                {
                    _dbContext.SaveChanges();
                    return Ok("Too high! Guess lower.");
                }
                else if (GameGuess < game.GameNumber)
                {
                    _dbContext.SaveChanges();
                    return Ok("Too low! Guess higher.");
                }
                else
                {
                    game.GameActive = false;
                    _dbContext.SaveChanges();
                    return Ok($"Congratulations! You guessed the correct number: {game.GameNumber}!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
