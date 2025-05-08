using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.WebUI.DTOs.UserDtos
{
    public class ListUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
