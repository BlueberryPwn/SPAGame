using SPAGame.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPAGame.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string? GameWord { get; set; }
        public string? Guess1 { get; set; }
        public string? Guess2 { get; set; }
        public string? Guess3 { get; set; }
        public string? Guess4 { get; set; }
        public string? Guess5 { get; set; }
        public bool GameWon { get; set; } = false;
        public bool GameLost { get; set; } = false;
        public DateTime GameDate { get; set; } = DateTime.Now;
        public int GamesCompleted { get; set; } = 0;

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account? Account { get; set; }
    }
}
