using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinalPlants.EntityLayer.Concrete
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public string Description { get; set; }
        public string PlantImage { get; set; }
        public ICollection<PlantAilment> PlantAilments { get; set; }

        public Plant()
        {
            PlantAilments = new HashSet<PlantAilment>();
        }
    }
}
