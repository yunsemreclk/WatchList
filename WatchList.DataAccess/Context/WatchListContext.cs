using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WatchList.Entity.Entity;

namespace WatchList.DataAccess.Context
{
    public class WatchListContext : DbContext
    {
        public WatchListContext(DbContextOptions options): base(options)//appsettings'de tutmak için base     
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }

        public DbSet<MovieList> MovieLists { get; set; }
        public DbSet<MovieListItem> MovieListItems { get; set; }

        public DbSet<SeriesList> SeriesLists { get; set; }
        public DbSet<SeriesListItem> SeriesListItems { get; set; }

        public DbSet<TierList> TierLists { get; set; }
        public DbSet<TierListItem> TierListItems { get; set; }

        public DbSet<Like> Likes { get; set; }


    }
}
