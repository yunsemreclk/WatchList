using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchList.Business.Absract;
using WatchList.DTO.DTOs.SeriesDtos;
using WatchList.DTO.DTOs.SeriesListDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesListController(IGenericService<SeriesList> _SeriesListService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _SeriesListService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _SeriesListService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _SeriesListService.TDelete(id);
            return Ok("Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateSeriesListDto createSeriesListDto)
        {
            var newValue = _mapper.Map<SeriesList>(createSeriesListDto);
            _SeriesListService.TCreate(newValue);
            return Ok("Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateSeriesListDto updateSeriesListDto)
        {
            var value = _mapper.Map<SeriesList>(updateSeriesListDto);
            _SeriesListService.TUpdate(value);
            return Ok("Güncellendi");
        }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class SeriesListItemController(IGenericService<SeriesListItem> _SeriesListItemService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _SeriesListItemService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _SeriesListItemService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _SeriesListItemService.TDelete(id);
            return Ok("Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateSeriesListItemDto createSeriesListItemDto)
        {
            var newValue = _mapper.Map<SeriesListItem>(createSeriesListItemDto);
            _SeriesListItemService.TCreate(newValue);
            return Ok("Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateSeriesListItemDto updateSeriesListItemDto)
        {
            var value = _mapper.Map<SeriesListItem>(updateSeriesListItemDto);
            _SeriesListItemService.TUpdate(value);
            return Ok("Güncellendi");
        }
    }
}
