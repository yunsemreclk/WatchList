using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Entity.Entity
{
    public class Like
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }

        public string TargetType { get; set; } // MovieList, SeriesList, TierList
        public Guid TargetId { get; set; }

        public DateTime LikedDate { get; set; } = DateTime.UtcNow;
    }

}
