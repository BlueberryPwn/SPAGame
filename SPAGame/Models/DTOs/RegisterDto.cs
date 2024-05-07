using System.ComponentModel.DataAnnotations;

namespace SPAGame.Models.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Please enter a name.")]
        [MinLength(3, ErrorMessage = "Your name has to contain at least 3 characters.")]
        [MaxLength(12, ErrorMessage = "Your name cannot contain more than 12 characters.")]
        public string? AccountName { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "This email address is not valid.")]
        [MinLength(3, ErrorMessage = "Your email address has to contain at least 3 characters.")]
        [MaxLength(320, ErrorMessage = "Your email address cannot contain more than 320 characters.")]
        public string? AccountEmail { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [MinLength(6, ErrorMessage = "Your password has to contain at least 6 characters.")]
        [MaxLength(30, ErrorMessage = "Your password cannot contain more than 30 characters.")]
        public string? AccountPassword { get; set; }

        [Required]
        public int GamesCompleted { get; } = 0;
        [Required]
        public int GamesLost { get; } = 0;
        [Required]
        public int GamesWon { get; } = 0;
    }
}
