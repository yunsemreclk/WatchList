using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchList.Business.Abstract;

namespace WatchList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMDbMoviesController : ControllerBase
    {
        private readonly ITMDbService _tmdbService;

        public TMDbMoviesController(ITMDbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var results = await _tmdbService.SearchMoviesAsync(query);
            return Ok(results);
        }

    }

}
