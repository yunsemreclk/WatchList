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
    public class CreateTierListDto
    {
        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public int AppUserId { get; set; }

    }
    public class CreateTierListItemDto
    {
        public int TierListId { get; set; }

        public string ItemType { get; set; } // Movie or Series
        public int ItemId { get; set; } // MovieId or SeriesId
        public string Tier { get; set; } // S, A, B, C, D, F
        public string Title { get; set; }
        public string PosterUrl { get; set; }
    }
}
