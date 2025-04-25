using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Entity.Entity
{
    public class MovieList
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<MovieListItem> Movies { get; set; }
        public ICollection<Like> Likes { get; set; }
    }

    public class MovieListItem
    {
        public Guid Id { get; set; }
        public Guid MovieListId { get; set; }
        public MovieList MovieList { get; set; }

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }

}
