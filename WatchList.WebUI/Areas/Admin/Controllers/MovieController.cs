﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchList.WebUI.DTOs.MovieDtos;
using WatchList.WebUI.Helpers;

namespace WatchList.WebUI.Areas.Admin.Controllers
{


    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly HttpClient _client;
        public MovieController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("WatchListClient");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ListMovieDto>>("movies");
            return View(values);
        }

        public async Task<IActionResult> DeleteMovie(int id) 
        {
            await _client.DeleteAsync($"movies/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieDto createMovieDto)
        {
            await _client.PostAsJsonAsync("movies", createMovieDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateMovie(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateMovieDto>($"movies/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            await _client.PutAsJsonAsync("movies", updateMovieDto);
            return RedirectToAction(nameof(Index));
        }









    }
}
