using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchList.Business.Absract;
using WatchList.DTO.DTOs.LikeDtos;
using WatchList.Entity.Entites;

namespace WatchList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController(IGenericService<Like> _likeService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _likeService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _likeService.TGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _likeService.TDelete(id);
            return Ok("Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateLikeDto createLikeeDto)
        {
            var newValue = _mapper.Map<Like>(createLikeeDto);
            _likeService.TCreate(newValue);
            return Ok("Oluşturuldu");
        }
        [HttpPut]
        public IActionResult Update(UpdateLikeDto updateLikeDto)
        {
            var value = _mapper.Map<Like>(updateLikeDto);
            _likeService.TUpdate(value);
            return Ok("Güncellendi");
        }
    }
}
