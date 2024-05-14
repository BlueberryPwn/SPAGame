﻿using Microsoft.AspNetCore.Mvc;
using SPAGame.Data;
using SPAGame.Repositories;

namespace SPAGame.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HighscoreController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHighscoreRepository _highscoreRepository;

        public HighscoreController(ApplicationDbContext applicationDbContext, IHighscoreRepository highscoreRepository)
        {
            _dbContext = applicationDbContext;
            _highscoreRepository = highscoreRepository;
        }

        [HttpGet("today")]
        public IActionResult Today(int amount)
        {
            // Gets top 10 best highscores from today
            var todaysHighscores = _highscoreRepository.GetHighscoresForToday(10);

            return Ok(todaysHighscores);
        }

        [HttpGet("alltime")]
        public IActionResult AllTime(int amount)
        {
            // Gets top 10 best highscores of all-time
            var allTimeHighscores = _highscoreRepository.GetHighscoresForAllTime(10);

            return Ok(allTimeHighscores);
        }
    }
}
