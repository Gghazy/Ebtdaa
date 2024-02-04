using Ebtdaa.Domain.ProductData.Entity;

namespace Ebtdaa.Application.RawMaterials.Dtos
{
    public class RawMaterialRequestDto
    {
        public int Id { get; set; }
        public string CustomItemName { get; set; }
        public string Name { get; set; }
        public int MaximumMonthlyConsumption { get; set; }
        public int AverageWeightKG { get; set; }
      //  public List<RawMaterialProductDto> RawMaterialProductDtos { get; set; }
         public int ProductId { get; set; }
        public int UnitId { get; set; }

        public string Description { get; set; }

        public int FactoryId { get; set; }
        public int PhotoId { get; set; }
        public int PaperId { get; set; }
    }
}
