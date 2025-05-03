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
    public class SeriesListsController(IGenericService<SeriesList> _seriesListService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _seriesListService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _seriesListService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _seriesListService.TDelete(id);
            return Ok("Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateSeriesListDto createSeriesListDto)
        {
            var newValue = _mapper.Map<SeriesList>(createSeriesListDto);
            _seriesListService.TCreate(newValue);
            return Ok("Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateSeriesListDto updateSeriesListDto)
        {
            var value = _mapper.Map<SeriesList>(updateSeriesListDto);
            _seriesListService.TUpdate(value);
            return Ok("Güncellendi");
        }
        [HttpGet("GetSharedSeriesList")]
        public IActionResult GetSharedSeriesList(int id)
        {
            var values = _seriesListService.TGetFilteredList(x => x.IsShared == true);
            var mappedValues = _mapper.Map<List<ListSeriesListDto>>(values);
            return Ok(mappedValues);
        }

        [HttpGet("GetSeriesListByUserId/{id}")]
        public IActionResult GetMovieListByUserId(int id)
        {
            var values = _seriesListService.TGetFilteredList(x => x.AppUserId == id);
            var mappedValues = _mapper.Map<List<ListSeriesListDto>>(values);
            return Ok(mappedValues);
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
