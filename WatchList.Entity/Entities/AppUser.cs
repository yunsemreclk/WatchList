using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WatchList.Entity.Entites;

namespace WatchList.Entity.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public ICollection<Series> Series { get; set; }
        public ICollection<MovieList> MovieLists { get; set; }
        public ICollection<SeriesList> SeriesLists { get; set; }
        public ICollection<TierList> TierLists { get; set; }
    }
}
