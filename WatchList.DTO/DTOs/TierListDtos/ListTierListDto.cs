using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.DTO.DTOs.LikeDtos;
using WatchList.DTO.DTOs.MovieDtos;
using WatchList.Entity.Entites;

namespace WatchList.DTO.DTOs.TierListDtos
{
    public class ListTierListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public ICollection<int> SeriesIds { get; set; }
        public int AppUserId { get; set; }

    }
    public class ListTierListItemDto
    {
        public int Id { get; set; }
        public int TierListId { get; set; }
        public string ItemType { get; set; }
        public int? MovieId { get; set; } // Nullable MovieId
        public int? SeriesId { get; set; } // Nullable SeriesId
        public string Tier { get; set; } // S, A, B, C, D, F gibi yada kullanıcının kendi oluşturduğu bir tier
    }
}
