using AutoMapper;
using MedicinalPlants.DtoLayer.AilmentDto;
using MedicinalPlants.DtoLayer.PlantDto;
using MedicinalPlants.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinalPlants.DtoLayer.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreatePlantDto,Plant>().ReverseMap();
            CreateMap<UpdatePlantDto,Plant>().ReverseMap();
            CreateMap<ResultPlantDto,Plant>().ReverseMap();
            CreateMap<GetPlantDto,Plant>().ReverseMap();
            CreateMap<ListPlantDto, Plant>().ReverseMap();

            CreateMap<CreateAilmentDto, Ailment>().ReverseMap();
            CreateMap<UpdateAilmentDto, Ailment>().ReverseMap();
            CreateMap<ResultAilmentDto, Ailment>().ReverseMap();
            CreateMap<GetAilmentDto, Ailment>().ReverseMap();

        }
    }
}
