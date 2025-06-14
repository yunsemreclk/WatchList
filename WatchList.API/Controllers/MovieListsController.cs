﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchList.Business.Absract;
using WatchList.DTO.DTOs.MovieDtos;
using WatchList.DTO.DTOs.MovieListDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieListsController(IGenericService<MovieList> _movieListService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _movieListService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _movieListService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _movieListService.TDelete(id);
            return Ok("Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateMovieListDto createMovieListDto)
        {
            var newValue = _mapper.Map<MovieList>(createMovieListDto);
            _movieListService.TCreate(newValue);
            return Ok("Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateMovieListDto updateMovieListDto)
        {
            var value = _mapper.Map<MovieList>(updateMovieListDto);
            _movieListService.TUpdate(value);
            return Ok("Güncellendi");
        }

        [HttpGet("GetSharedMovieList")]
        public IActionResult GetSharedMovieList(int id)
        {
            var values = _movieListService.TGetFilteredList(x => x.IsShared == true);
            var mappedValues = _mapper.Map<List<ListMovieListDto>>(values);
            return Ok(mappedValues);
        }

        [HttpGet("GetMovieListByUserId/{id}")]
        public IActionResult GetMovieListByUserId(int id)
        {
            var values = _movieListService.TGetFilteredList(x => x.AppUserId == id);
            var mappedValues = _mapper.Map<List<ListMovieListDto>>(values);
            return Ok(mappedValues);
        }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class MovieListItemController(IGenericService<MovieListItem> _movieListItemService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _movieListItemService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _movieListItemService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _movieListItemService.TDelete(id);
            return Ok("Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateMovieListItemDto createMovieListItemDto)
        {
            var newValue = _mapper.Map<MovieListItem>(createMovieListItemDto);
            _movieListItemService.TCreate(newValue);
            return Ok("Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateMovieListItemDto updateMovieListItemDto)
        {
            var value = _mapper.Map<MovieListItem>(updateMovieListItemDto);
            _movieListItemService.TUpdate(value);
            return Ok("Güncellendi");
        }

        [HttpGet("GetMovieListItemByMovieListId/{id}")]
        public IActionResult GetMovieListByUserId(int id)
        {
            var values = _movieListItemService.TGetFilteredList(x => x.MovieListId == id);
            var mappedValues = _mapper.Map<List<ListMovieListItemDto>>(values);
            return Ok(mappedValues);
        }
    }
}
