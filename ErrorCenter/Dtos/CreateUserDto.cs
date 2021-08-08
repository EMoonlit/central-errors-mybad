﻿using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
