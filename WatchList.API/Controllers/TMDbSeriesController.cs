using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchList.Business.Abstract;

namespace WatchList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMDbSeriesController : ControllerBase
    {
        private readonly ITMDbSeriesService _tmdbService;

        public TMDbSeriesController(ITMDbSeriesService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("searchSeries")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var results = await _tmdbService.SearchSeriesAsync(query);
            return Ok(results);
        }
    }
}
