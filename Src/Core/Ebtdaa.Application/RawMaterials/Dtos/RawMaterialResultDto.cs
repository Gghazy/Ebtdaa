namespace Ebtdaa.Application.RawMaterials.Dtos
{
    public class RawMaterialResultDto
    {
        public int Id { get; set; }
        public string CustomItemName { get; set; }
        public string ProductName { get; set; }
        public string Name { get; set; }
        public decimal MaximumMonthlyConsumption { get; set; }
        public decimal AverageWeightKG { get; set; }
        public List<int> FactoryProductId { get; set; }
      //  public List<RawMaterialProductDto> RawMaterialProducts { get; set; }
        public int UnitId { get; set; }
        public string Description { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public int PhotoId { get; set; }
        public int PaperId { get; set; }
    }
}
