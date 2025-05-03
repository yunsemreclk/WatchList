using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WatchList.Entity.Entites;
using WatchList.Entity.Entities;

namespace WatchList.DataAccess.Context
{
    public class WatchListContext : IdentityDbContext<AppUser,AppRole,int>
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

            // 1- Aynı Movie veya Series bir listeye iki kez eklenemesin (UNIQUE INDEX)
            modelBuilder.Entity<MovieListItem>()
                .HasIndex(m => new { m.MovieListId, m.MovieId })
                .IsUnique();

            modelBuilder.Entity<SeriesListItem>()
                .HasIndex(s => new { s.SeriesListId, s.SeriesId })
                .IsUnique();

            // 2- Movie silinirse -> ona bağlı MovieListItem ve TierListItem silinsin
            modelBuilder.Entity<MovieListItem>()
                .HasOne(m => m.Movie)
                .WithMany(m => m.MovieListItems)
                .HasForeignKey(m => m.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TierListItem>()
                .HasOne(t => t.Movie)
                .WithMany(m => m.TierListItems)
                .HasForeignKey(t => t.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            // 3- Series silinirse -> ona bağlı SeriesListItem ve TierListItem silinsin
            modelBuilder.Entity<SeriesListItem>()
                .HasOne(s => s.Series)
                .WithMany(s => s.SeriesListItems)
                .HasForeignKey(s => s.SeriesId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TierListItem>()
                .HasOne(t => t.Series)
                .WithMany(s => s.TierListItems)
                .HasForeignKey(t => t.SeriesId)
                .OnDelete(DeleteBehavior.Cascade);



            // 4- MovieList silinirse -> içindeki MovieListItem'lar silinsin
            modelBuilder.Entity<MovieListItem>()
                .HasOne(m => m.MovieList)
                .WithMany(l => l.Movies)
                .HasForeignKey(m => m.MovieListId)
                .OnDelete(DeleteBehavior.Cascade);

            // 5- SeriesList silinirse -> içindeki SeriesListItem'lar silinsin
            modelBuilder.Entity<SeriesListItem>()
                .HasOne(s => s.SeriesList)
                .WithMany(l => l.Series)
                .HasForeignKey(s => s.SeriesListId)
                .OnDelete(DeleteBehavior.Cascade);

            // 6- TierList silinirse -> içindeki TierListItem'lar silinsin
            modelBuilder.Entity<TierListItem>()
                .HasOne(t => t.TierList)
                .WithMany(l => l.Items)
                .HasForeignKey(t => t.TierListId)
                .OnDelete(DeleteBehavior.Cascade);
        }





    }
}
