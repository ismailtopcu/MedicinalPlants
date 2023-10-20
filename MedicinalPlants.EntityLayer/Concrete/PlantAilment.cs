namespace MedicinalPlants.EntityLayer.Concrete
{
    public class PlantAilment
    {
        public int PlantAilmentId { get; set; }

        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        public int AilmentId { get; set; }
        public Ailment Ailment { get; set; }
    }
}
