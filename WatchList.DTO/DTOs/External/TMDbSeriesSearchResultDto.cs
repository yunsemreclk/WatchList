using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WatchList.DTO.DTOs.External
{
    public class TMDbSeriesSearchResultDto
    {
        public int Id { get; set; } // Dizi Id
        public string Title { get; set; } // Dizi Adı
        public string PosterPath { get; set; } // Poster URL'si

    }
}

