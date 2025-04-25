using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Entity.Entity
{
    public class SeriesList
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<SeriesListItem> Series { get; set; }
        public ICollection<Like> Likes { get; set; }
    }

    public class SeriesListItem
    {
        public Guid Id { get; set; }
        public Guid SeriesListId { get; set; }
        public SeriesList SeriesList { get; set; }

        public Guid SeriesId { get; set; }
        public Series Series { get; set; }
    }

}
