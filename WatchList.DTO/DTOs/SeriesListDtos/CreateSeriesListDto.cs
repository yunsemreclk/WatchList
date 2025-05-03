using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.DTO.DTOs.LikeDtos;
using WatchList.DTO.DTOs.MovieDtos;
using WatchList.Entity.Entites;

namespace WatchList.DTO.DTOs.SeriesListDtos
{
    public class CreateSeriesListDto
    {
        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<int>? SeriesIds { get; set; }

        public int AppUserId { get; set; }
    }
    public class CreateSeriesListItemDto
    {
        public int SeriesListId { get; set; }
        public int SeriesId { get; set; }
    }
}
