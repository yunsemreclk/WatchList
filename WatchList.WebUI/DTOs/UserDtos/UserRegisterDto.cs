﻿using System.ComponentModel.DataAnnotations;

namespace WatchList.WebUI.DTOs.UserDtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
