﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPAGame.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string? GameWord { get; set; }
        public int GameAttempts { get; set; }
        public bool GameActive { get; set; }
        public DateTime GameDate { get; set; } = DateTime.Now;
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
