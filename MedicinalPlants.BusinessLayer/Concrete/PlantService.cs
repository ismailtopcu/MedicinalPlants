using MedicinalPlants.BusinessLayer.Abstract;
using MedicinalPlants.DataAccessLayer.Abstract;
using MedicinalPlants.DtoLayer.PlantDto;
using MedicinalPlants.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinalPlants.BusinessLayer.Concrete
{
    public class PlantService : IPlantService
    {
        private readonly IPlantDal _plantDal;

        public PlantService(IPlantDal plantDal)
        {
            _plantDal = plantDal;
        }

        public async Task TCreatePlant(CreatePlantDto createPlantDto)
        {
            await _plantDal.CreatePlant(createPlantDto);
        }

        public async Task TDeleteAsync(Plant t)
        {
            await _plantDal.DeleteAsync(t);
        }

        public async Task<Plant> TGetByIdAsync(int id)
        {
            return await _plantDal.GetByIdAsync(id);
        }

        public async Task<List<Plant>> TGetListAsync()
        {
            return await _plantDal.GetListAsync();
        }

		public async Task<GetPlantDto> TGetPlantById(int id)
		{
			return await _plantDal.GetPlantById(id);
		}

		public async Task TInsertAsync(Plant t)
        {
            await _plantDal.InsertAsync(t);
        }

        public async Task<List<ListPlantDto>> TPlantList()
        {
            return await _plantDal.PlantList();
        }

        public async Task TUpdateAsync(Plant t)
        {
            await _plantDal.UpdateAsync(t);
        }

		public async Task TUpdatePlant(UpdatePlantDto updatePlantDto)
		{
            await _plantDal.UpdatePlant(updatePlantDto);
		}
	}
}
