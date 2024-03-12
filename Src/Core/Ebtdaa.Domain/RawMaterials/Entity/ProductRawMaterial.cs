using Ebtdaa.Domain.ProductData.Entity;

namespace Ebtdaa.Domain.RawMaterials.Entity
{
    public class ProductRawMaterial
    {
      
        public int FactoryProductId { get; set; }
        public FactoryProduct FactoryProduct { get; set; }
        public int rawMaterialId { get; set; }
        public RawMaterial RawMaterial { get; set; }

    }
}
