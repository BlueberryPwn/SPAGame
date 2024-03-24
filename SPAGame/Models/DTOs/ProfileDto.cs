using System.ComponentModel;

namespace SPAGame.Models.DTOs
{
    public class ProfileDto
    {
        [DefaultValue(0)]
        public int GamesCompleted { get; set; }
        [DefaultValue(0)]
        public int GamesWon { get; set; }
        [DefaultValue(0)]
        public int GamesLost { get; set; }
        public int AccountId { get; set; }
    }
}
