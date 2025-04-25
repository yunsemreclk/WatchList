using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Entity.Entity
{
    public class User //Temporery
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public ICollection<Movie> Movies { get; set; }
        public ICollection<Series> Series { get; set; }

        public ICollection<MovieList> MovieLists { get; set; }
        public ICollection<SeriesList> SeriesLists { get; set; }
        public ICollection<TierList> TierLists { get; set; }
    }

}
