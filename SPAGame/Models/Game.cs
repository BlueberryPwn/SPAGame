using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPAGame.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [StringLength(5)]
        public string? GameWord { get; set; }

        [StringLength(5)]
        public string? Guess1 { get; set; }

        [StringLength(5)]
        public string? Guess2 { get; set; }

        [StringLength(5)]
        public string? Guess3 { get; set; }

        [StringLength(5)]
        public string? Guess4 { get; set; }

        [StringLength(5)]
        public string? Guess5 { get; set; }
        public bool GameWon { get; set; } = false;
        public bool GameLost { get; set; } = false;
        public DateTime GameDate { get; set; } = DateTime.Now;

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public virtual Account? Account { get; set; }
    }
}
