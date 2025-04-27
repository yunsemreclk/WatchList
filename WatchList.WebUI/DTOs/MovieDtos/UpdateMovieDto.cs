using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.WebUI.DTOs.MovieDtos
{
    public class UpdateMovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public DateTime? WatchDate { get; set; }
        public string PosterUrl { get; set; }
        public bool IsShared { get; set; }



    }
}