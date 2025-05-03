using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Entity.Entities;

namespace WatchList.Entity.Entites
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int? Rating { get; set; }
        public DateTime? WatchedDate { get; set; }
        public string PosterUrl { get; set; }
        public bool IsPlannedToWatch { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<MovieListItem> MovieListItems { get; set; }

        public ICollection<TierListItem> TierListItems { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }



}
