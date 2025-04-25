using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchList.Business.Absract;
using WatchList.DTO.DTOs.MovieDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(IGenericService<Movie> _movieService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() 
        {
            var values = _movieService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]   
        public IActionResult GetById(int id)
        {
            var value = _movieService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            
            _movieService.TDelete(id);
            return Ok("Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateMovieDto createMovieDto)
        {
            var newValue = _mapper.Map<Movie>(createMovieDto);  
            _movieService.TCreate(newValue);
            return Ok("Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateMovieDto updateMovieDto)
        {
            var value = _mapper.Map<Movie>(updateMovieDto);
            _movieService.TUpdate(value);
            return Ok("Güncellendi");
        }
    }
}
