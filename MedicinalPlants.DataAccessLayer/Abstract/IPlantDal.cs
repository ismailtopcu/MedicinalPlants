using MedicinalPlants.DtoLayer.PlantDto;
using MedicinalPlants.EntityLayer.Concrete;

namespace MedicinalPlants.DataAccessLayer.Abstract
{
    public interface IPlantDal : IGenericDal<Plant>
    {
         Task<List<ListPlantDto>> PlantList();
         Task CreatePlant(CreatePlantDto createPlantDto);
        Task<GetPlantDto> GetPlantById(int id);
        Task UpdatePlant(UpdatePlantDto updatePlantDto);

	}
}
