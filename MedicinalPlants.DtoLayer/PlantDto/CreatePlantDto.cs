using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinalPlants.DtoLayer.PlantDto
{
    public class CreatePlantDto
    {
        public string PlantName { get; set; }
        public string Description { get; set; }        
        public int[] AilmentIds{ get; set;}
        public string PlantImage { get; set; }

    }
}
