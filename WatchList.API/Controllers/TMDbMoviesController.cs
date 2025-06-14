﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchList.Business.Abstract;

namespace WatchList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMDbMoviesController : ControllerBase
    {
        private readonly ITMDbMovieService _tmdbService;

        public TMDbMoviesController(ITMDbMovieService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("searchMovies")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            var results = await _tmdbService.SearchMoviesAsync(query);
            return Ok(results);
        }

    }

}
