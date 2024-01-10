using Ebtdaa.Domain.General;
using Ebtdaa.Domain.RawMaterials.Entity;

namespace Ebtdaa.Domain.ActualRawMaterials.Entity
{
    public class ActualRawMaterial:BaseEntity
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int RawMaterialId { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public int CurrentStockQuantity_KG { get; set; }
        public int UsedQuantity_KG { get; set; }
        public int IncreasedUsageReason { get; set; }

    }
}
