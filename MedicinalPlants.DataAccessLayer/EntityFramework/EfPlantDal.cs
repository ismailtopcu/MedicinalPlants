using AutoMapper;
using MedicinalPlants.DataAccessLayer.Abstract;
using MedicinalPlants.DataAccessLayer.Concrete;
using MedicinalPlants.DataAccessLayer.Repositories;
using MedicinalPlants.DtoLayer.PlantDto;
using MedicinalPlants.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinalPlants.DataAccessLayer.EntityFramework
{
	public class EfPlantDal : GenericRepository<Plant>, IPlantDal
	{
		private readonly AppDbContext _appDbContext;
		public EfPlantDal(AppDbContext appDbContext) : base(appDbContext)
		{
			_appDbContext = appDbContext;

		}

		public async Task<List<ListPlantDto>> PlantList()
		{
			var values = await _appDbContext.Plants.Include(x => x.PlantAilments).ThenInclude(y => y.Ailment).ToListAsync();
			var results = values.Select(x => new ListPlantDto
			{
				PlantId = x.PlantId,
				PlantName = x.PlantName,
				PlantImage = x.PlantImage,
				Description = x.Description,
				Ailments = x.PlantAilments.Select(y => y.Ailment.AilmentName).ToList()
			}).ToList();

			return results;

		}

		public async Task CreatePlant(CreatePlantDto createPlantDto)
		{
			var value = new Plant
			{
				PlantName = createPlantDto.PlantName,
				Description = createPlantDto.Description,
				PlantImage = createPlantDto.PlantImage
			};


			await _appDbContext.Plants.AddAsync(value);
			await _appDbContext.SaveChangesAsync();

			if (createPlantDto.AilmentIds != null && createPlantDto.AilmentIds.Any())
			{
				foreach (var x in createPlantDto.AilmentIds)
				{
					var model = new PlantAilment
					{
						AilmentId = x,
						PlantId = value.PlantId
					};
					await _appDbContext.PlantAilments.AddAsync(model);
				}
				await _appDbContext.SaveChangesAsync();
			}
		}

		public async Task<GetPlantDto> GetPlantById(int id)
		{
			var value = await _appDbContext.Plants.Include(x => x.PlantAilments).FirstOrDefaultAsync(x => x.PlantId == id);
			var result = new GetPlantDto
			{
				PlantId = id,
				PlantImage= value.PlantImage,
				Description= value.Description,
				PlantName = value.PlantName,
				AilmentIds = value.PlantAilments.Select(y=>y.AilmentId).ToArray()
			};

			return result;
		}
		public async Task UpdatePlant(UpdatePlantDto updatePlantDto)
		{
			var plant = await _appDbContext.Plants
				.Include(x => x.PlantAilments)
				.FirstOrDefaultAsync(x => x.PlantId == updatePlantDto.PlantId);

			plant.PlantName = updatePlantDto.PlantName;
			plant.PlantImage = updatePlantDto.PlantImage;
			plant.Description = updatePlantDto.Description;
			plant.PlantAilments.Clear();
			await _appDbContext.SaveChangesAsync();

			if (updatePlantDto.AilmentIds != null && updatePlantDto.AilmentIds.Any())
			{
				foreach (var x in updatePlantDto.AilmentIds)
				{
					var model = new PlantAilment
					{
						AilmentId = x,
						PlantId = plant.PlantId
					};
					await _appDbContext.PlantAilments.AddAsync(model);

				}
				await _appDbContext.SaveChangesAsync();
			}
			
		}
	}
}
