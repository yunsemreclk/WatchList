using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.DTO.DTOs.External;

namespace WatchList.Business.Abstract
{
    public interface ITMDbMovieService
    {
        Task<List<TMDbMovieSearchResultDto>> SearchMoviesAsync(string query);

    }
}
