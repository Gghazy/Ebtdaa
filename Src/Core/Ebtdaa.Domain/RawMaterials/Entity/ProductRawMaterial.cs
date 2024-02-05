using Ebtdaa.Domain.ProductData.Entity;

namespace Ebtdaa.Domain.RawMaterials.Entity
{
    public class ProductRawMaterial
    {
       // public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int rawMaterialId { get; set; }
        public RawMaterial RawMaterial { get; set; }

    }
}
