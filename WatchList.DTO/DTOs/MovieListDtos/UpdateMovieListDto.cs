using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.DTO.DTOs.MovieListDtos
{
    public class UpdateMovieListDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public bool IsShared { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<int> MovieIds { get; set; } // Sadece MovieId'leri tutuyoruz
    }

    public class UpdateMovieListItemDto
    {
        public int Id { get; set; }
        public int MovieListId { get; set; }
        public int MovieId { get; set; }
    }
}
