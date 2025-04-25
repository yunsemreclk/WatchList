using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Entity.Entites
{
    public class Like
    {
        public int Id { get; set; }
        public string TargetType { get; set; } // MovieList, SeriesList, TierList
        public int TargetId { get; set; }

        public DateTime LikedDate { get; set; } = DateTime.UtcNow;
    }

}
