using AutoMapper;
using MedicinalPlants.BusinessLayer.Abstract;
using MedicinalPlants.DtoLayer.AilmentDto;
using MedicinalPlants.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicinalAilments.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AilmentsController : ControllerBase
    {
        private readonly IAilmentService _ailmentService;
        private readonly IMapper _mapper;

        public AilmentsController(IAilmentService ailmentService, IMapper mapper)
        {
            _ailmentService = ailmentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAilments()
        {
            var values = await _ailmentService.TGetListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAilmentById(int id)
        {
            var value = await _ailmentService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAilment(CreateAilmentDto createAilmentDto)
        {
            var value = _mapper.Map<Ailment>(createAilmentDto);
            await _ailmentService.TInsertAsync(value);
            return Ok("Şikayet Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAilment(int id)
        {
            var value = await _ailmentService.TGetByIdAsync(id);
            await _ailmentService.TDeleteAsync(value);
            return Ok("Şikayet Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAilment(UpdateAilmentDto updateAilmentDto)
        {
            var value = _mapper.Map<Ailment>(updateAilmentDto);
            await _ailmentService.TUpdateAsync(value);
            return Ok("Şikayet Başarıyla Güncellendi");
        }
    }
}
