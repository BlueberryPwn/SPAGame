using System.ComponentModel.DataAnnotations;

namespace SPAGame.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required]
        public string? AccountName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? AccountEmail { get; set; }
        public byte[]? AccountPasswordHash { get; set; }
        public byte[]? AccountPasswordSalt { get; set; }
        public DateTime AccountRegistrationDate { get; set; } = DateTime.UtcNow;
    }
}
