using AutoMapper;
using MedicinalPlants.BusinessLayer.Abstract;
using MedicinalPlants.DtoLayer.PlantDto;
using MedicinalPlants.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicinalPlants.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantService _plantService;
        private readonly IMapper _mapper;

        public PlantsController(IPlantService plantService, IMapper mapper)
        {
            _plantService = plantService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlants()
        {
            var values = await _plantService.TPlantList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlantById(int id)
        {
            var value = await _plantService.TGetPlantById(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlant(CreatePlantDto createPlantDto)
        {            
            await _plantService.TCreatePlant(createPlantDto);
            return Ok("Bitki Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePlant(int id)
        {
            var value = await _plantService.TGetByIdAsync(id);
            await _plantService.TDeleteAsync(value);
            return Ok("Bitki Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePlant(UpdatePlantDto updatePlantDto)
        {
            await _plantService.TUpdatePlant(updatePlantDto);
            return Ok("Bitki Başarıyla Güncellendi");
        }
    }
}
