using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchList.Business.Abstract;
using WatchList.DTO.DTOs.UserDtos;
using WatchList.Entity.Entities;

namespace WatchList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, IJwtService _jwtService, IMapper _mapper) : ControllerBase
    {
        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest("Bu Email Sistemde kayıtlı değil");
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false); //giriş kurallları false false
            if (!result.Succeeded)
            {
                return BadRequest("Kullanıcı Adı vey Şifre Hatalı");
            }
            var token = await _jwtService.CreateTokenAsymc(user);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var user = _mapper.Map<AppUser>(model);
            if(ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
                await _userManager.AddToRoleAsync(user, "User");
                return Ok("Kullanıcı kaydı başarıyla gerçekleştirildi.");
            }

            return BadRequest();
        }
    }
}
