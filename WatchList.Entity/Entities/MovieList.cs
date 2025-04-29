using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Entity.Entities;

namespace WatchList.Entity.Entites
{
    public class MovieList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<MovieListItem> Movies { get; set; }
        public ICollection<Like> Likes { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }

    public class MovieListItem
    {
        public int Id { get; set; }
        public int MovieListId { get; set; }
        public MovieList MovieList { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }


}
