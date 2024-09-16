namespace Ebtdaa.Application.RawMaterials.Dtos
{
    public class RawMaterialResultDto
    {
        public int Id { get; set; }

        public string Hs12Code { get; set; }

        public string CustomItemName { get; set; }
        public string RawMaterialName { get; set; }
        public string Name { get; set; }
        public decimal MaximumMonthlyConsumption { get; set; }
        public decimal AverageWeightKG { get; set; }
      
        public List<FactoryProductInRaw> FactoryProductId { get; set; }
        //  public List<RawMaterialProductDto> RawMaterialProducts { get; set; }
        public int UnitId { get; set; }
        public string Description { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public int PhotoId { get; set; }
        public int PaperId { get; set; }
        public string PhotoName { get; set; }
        public string PaperName { get; set; }
    }
    public class FactoryProductInRaw{
        public string ProductNameInRaw { get; set; }
        public int ProductId { get; set; }


    }
}
