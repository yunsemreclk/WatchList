using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Entity.Entites
{
    public class Series
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Rating { get; set; }
        public int CurrentSeason { get; set; }
        public int CurrentEpisode { get; set; }
        public bool IsFinished { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? LastDate { get; set; }

        public string PosterUrl { get; set; }
        public bool IsPlannedToWatch { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<SeriesListItem> SeriesListItems { get; set; }
    }


}
