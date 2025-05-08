using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.DTO.DTOs.UserDtos
{
    public class ListUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
