using System.ComponentModel.DataAnnotations;

namespace WatchList.WebUI.DTOs.UserDtos
{
    public class UserRegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "'Şifre' ve 'Şifre Tekrar' eşleşmiyor.")]
        public string ConfirmPassword { get; set; }

    }
}
