using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPAGame.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public int GamesCompleted { get; set; } = 0;
        public int GamesWon { get; set; } = 0;
        public int GamesLost { get; set; } = 0;

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
