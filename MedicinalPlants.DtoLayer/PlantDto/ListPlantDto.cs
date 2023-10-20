using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinalPlants.DtoLayer.PlantDto
{
    public class ListPlantDto
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public string Description { get; set; }
        public string PlantImage { get; set; }
        public List<string> Ailments { get; set; }
    }
}
