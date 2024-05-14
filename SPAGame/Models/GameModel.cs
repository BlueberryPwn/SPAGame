using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPAGame.Models
{
    public class GameModel
    {
        [Key]
        public int GameId { get; set; }
        public int GameNumber { get; set; }
        public int GameAttempts { get; set; }
        public bool GameActive { get; set; }
        public DateTime GameDate { get; set; }
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public AccountModel Account { get; set; }
    }
}
