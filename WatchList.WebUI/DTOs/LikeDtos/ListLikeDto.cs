using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.WebUI.DTOs.LikeDtos
{
    public class ListLikeDto
    {
        public int Id { get; set; }
        public string TargetType { get; set; } // MovieList, SeriesList, TierList
        public int TargetId { get; set; }

        public DateTime LikedDate { get; set; } = DateTime.UtcNow;

        public int AppUserId { get; set; }
    }
}
