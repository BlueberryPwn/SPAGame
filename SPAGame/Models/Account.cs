using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPAGame.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [StringLength(12)]
        public string? AccountName { get; set; }

        [StringLength(320)]
        public string? AccountEmail { get; set; }

        [JsonIgnore]
        [StringLength(100)]
        public string? AccountPassword { get; set; }

        public int GamesCompleted { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }

        //public Profile? Profile { get; set; }
    }
}
