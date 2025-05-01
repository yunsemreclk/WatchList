using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchList.Business.Absract;
using WatchList.DTO.DTOs.SeriesListDtos;
using WatchList.DTO.DTOs.TierListDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TierListsController(IGenericService<TierList> _tierListService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _tierListService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _tierListService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _tierListService.TDelete(id);
            return Ok("Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateTierListDto createTierListDto)
        {
            var newValue = _mapper.Map<TierList>(createTierListDto);
            _tierListService.TCreate(newValue);
            return Ok("Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateTierListDto updateTierListDto)
        {
            var value = _mapper.Map<TierList>(updateTierListDto);
            _tierListService.TUpdate(value);
            return Ok("Güncellendi");
        }

        [HttpGet("GetSharedTierList")]
        public IActionResult GetSharedTierList(int id)
        {
            var values = _tierListService.TGetFilteredList(x => x.IsShared == true);
            return Ok(values);
        }

        [HttpGet("GetTierListByUserId/{id}")]
        public IActionResult GetMovieListByUserId(int id)
        {
            var values = _tierListService.TGetFilteredList(x => x.AppUserId == id);
            var mappedValues = _mapper.Map<List<ListTierListDto>>(values);
            return Ok(mappedValues);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class TierListItemController(IGenericService<TierListItem> _tierListItemService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _tierListItemService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _tierListItemService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _tierListItemService.TDelete(id);
            return Ok("Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateTierListItemDto createTierListItemDto)
        {
            var newValue = _mapper.Map<TierListItem>(createTierListItemDto);
            _tierListItemService.TCreate(newValue);
            return Ok("Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateTierListItemDto updateTierListItemDto)
        {
            var value = _mapper.Map<TierListItem>(updateTierListItemDto);
            _tierListItemService.TUpdate(value);
            return Ok("Güncellendi");
        }
    }
}
