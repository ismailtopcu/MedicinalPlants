namespace MedicinalPlants.DtoLayer.PlantDto
{
    public class GetPlantDto
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public string Description { get; set; }
        public string PlantImage { get; set; }
        public int[] AilmentIds { get; set; }
    }
}
