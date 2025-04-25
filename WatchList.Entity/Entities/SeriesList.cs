using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Entity.Entites
{
    public class SeriesList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<SeriesListItem> Series { get; set; }
        public ICollection<Like> Likes { get; set; }
    }

    public class SeriesListItem
    {
        public int Id { get; set; }
        public int SeriesListId { get; set; }
        public SeriesList SeriesList { get; set; }

        public int SeriesId { get; set; }
        public Series Series { get; set; }
    }

}
