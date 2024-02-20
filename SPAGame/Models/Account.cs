using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SPAGame.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string? AccountName { get; set; }
        public string? AccountEmail { get; set; }
        [JsonIgnore]
        public string? AccountPassword { get; set; }
    }
}
