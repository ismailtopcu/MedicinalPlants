using MedicinalPlants.DtoLayer.PlantDto;
using MedicinalPlants.EntityLayer.Concrete;

namespace MedicinalPlants.BusinessLayer.Abstract
{
    public interface IPlantService : IGenericService<Plant>
    {
        Task<List<ListPlantDto>> TPlantList();
        Task TCreatePlant(CreatePlantDto createPlantDto);
        Task<GetPlantDto> TGetPlantById(int id);
		Task TUpdatePlant(UpdatePlantDto updatePlantDto);

	}
}
