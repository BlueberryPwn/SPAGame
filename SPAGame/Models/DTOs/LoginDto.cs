using System.ComponentModel.DataAnnotations;

namespace SPAGame.Models.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Please enter an email address.")]
        public string? AccountEmail { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        public string? AccountPassword { get; set; }
    }
}
