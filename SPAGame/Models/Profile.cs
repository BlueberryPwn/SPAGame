using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPAGame.Models
{
    public class Profile
    {
        [Key]
        public int AccountProfileId { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

    }
}
