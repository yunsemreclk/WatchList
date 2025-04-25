using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WatchList.Entity.Entites;

namespace WatchList.DataAccess.Context
{
    public class WatchListContext : DbContext
    {
        public WatchListContext(DbContextOptions options): base(options)//appsettings'de tutmak için base     
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }

        public DbSet<MovieList> MovieLists { get; set; }
        public DbSet<MovieListItem> MovieListItems { get; set; }

        public DbSet<SeriesList> SeriesLists { get; set; }
        public DbSet<SeriesListItem> SeriesListItems { get; set; }

        public DbSet<TierList> TierLists { get; set; }
        public DbSet<TierListItem> TierListItems { get; set; }

        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //MovieListItem tablosunda aynı Movie bir listeye iki kez eklenemesin diye benzersiz indeks
            modelBuilder.Entity<MovieListItem>()
                .HasIndex(m => new { m.MovieListId, m.MovieId })
                .IsUnique();

            //SeriesListItem tablosunda aynı Series bir listeye iki kez eklenemesin diye benzersiz indeks
            modelBuilder.Entity<SeriesListItem>()
                .HasIndex(s => new { s.SeriesListId, s.SeriesId })
                .IsUnique();


            //Movie silindiğinde, MovieListItem üzerinden zincirleme silme olmasın
            modelBuilder.Entity<MovieListItem>()
                .HasOne(m => m.Movie)
                .WithMany(m => m.MovieListItems)
                .HasForeignKey(m => m.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            //MovieList silindiğinde, MovieListItem üzerinden zincirleme silme olmasın
            modelBuilder.Entity<MovieListItem>()
                .HasOne(m => m.MovieList)
                .WithMany(l => l.Movies)
                .HasForeignKey(m => m.MovieListId)
                .OnDelete(DeleteBehavior.NoAction);

            //Series silinince SeriesListItem zincirleme silinmesin
            modelBuilder.Entity<SeriesListItem>()
                .HasOne(s => s.Series)
                .WithMany(s => s.SeriesListItems)
                .HasForeignKey(s => s.SeriesId)
                .OnDelete(DeleteBehavior.NoAction);

            //SeriesList silinince SeriesListItem zincirleme silinmesin
            modelBuilder.Entity<SeriesListItem>()
                .HasOne(s => s.SeriesList)
                .WithMany(l => l.Series)
                .HasForeignKey(s => s.SeriesListId)
                .OnDelete(DeleteBehavior.NoAction);

            //TierList silinince TierListItem zincirleme silinmesin
            modelBuilder.Entity<TierListItem>()
                .HasOne(t => t.TierList)
                .WithMany(l => l.Items)
                .HasForeignKey(t => t.TierListId)
                .OnDelete(DeleteBehavior.NoAction);
        }




    }
}
