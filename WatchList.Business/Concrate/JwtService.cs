using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WatchList.Business.Abstract;
using WatchList.Business.Configurations;
using WatchList.DTO.DTOs.LoginDtos;
using WatchList.Entity.Entities;

namespace WatchList.Business.Concrate
{
    public class JwtService : IJwtService
    {
        private readonly JwtTokenOptions _jwtTokenOptions;
        private readonly UserManager<AppUser> _userManager;

        public JwtService(IOptions<JwtTokenOptions> jwtTokenOptions, UserManager<AppUser> userManager)
        {
            _jwtTokenOptions = jwtTokenOptions.Value;
            _userManager = userManager;
        }
        public async Task<LoginResponseDto> CreateTokenAsymc(AppUser user)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOptions.Key));

            var userRoles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim("FullName",user.FirstName+user.LastName),

            };

            foreach (var role in userRoles) 
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtTokenOptions.Issuer,
                audience: _jwtTokenOptions.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_jwtTokenOptions.ExpireInMinutes),
                signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)

                );

            var handler = new JwtSecurityTokenHandler();
            var responseDto = new LoginResponseDto();
            responseDto.Token = handler.WriteToken(jwtSecurityToken);
            responseDto.ExpireDate = DateTime.UtcNow.AddMinutes(_jwtTokenOptions.ExpireInMinutes);

            return responseDto;

        }
    }
}
