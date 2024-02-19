﻿using System.ComponentModel.DataAnnotations;

namespace SPAGame.Models.DTO
{
    public class LoginRequestDto
    {
        [Required]
        public string? AccountName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? AccountEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? AccountPassword { get; set; }
        public string? JwtToken { get; set; }
    }
}