using Microsoft.Identity.Client;

namespace SPAGame.Models.DTOs
{
    public class HighscoreDto
    {
        public string? AccountName { get; set; }
        public DateTime GameDate { get; set; }
        //public bool IsToday { get; set; }
        public int Score { get; set; }
    }
}
