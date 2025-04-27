using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchList.Business.Absract;
using WatchList.DTO.DTOs.SeriesDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController(IGenericService<Series> _seriesService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _seriesService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _seriesService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _seriesService.TDelete(id);
            return Ok("Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateSeriesDto createSeriesDto)
        {
            var newValue = _mapper.Map<Series>(createSeriesDto);
            _seriesService.TCreate(newValue);
            return Ok("Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateSeriesDto updateSeriesDto)
        {
            var value = _mapper.Map<Series>(updateSeriesDto);
            _seriesService.TUpdate(value);
            return Ok("Güncellendi");
        }
    }
}
