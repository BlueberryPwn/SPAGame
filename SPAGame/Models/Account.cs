using System.ComponentModel.DataAnnotations;

namespace SPAGame.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string? AccountName { get; set; }
        public string? AccountEmail { get; set;}
        public string? AccountPassword { get; set;}
    }
}
