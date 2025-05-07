using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.DTO.DTOs.LoginDtos;
using WatchList.Entity.Entities;

namespace WatchList.Business.Abstract
{
    public interface IJwtService
    {
        Task<LoginResponseDto> CreateTokenAsymc(AppUser user);

    }
}
