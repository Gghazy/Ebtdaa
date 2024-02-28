using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Periods;

namespace Ebtdaa.Domain.RawMaterials.Entity
{
    public class RawMaterial:BaseEntity
    {
        public int Id { get; set; }
        public string CustomItemName { get; set; }
        public int CustomItemRawMaterialId { get; set; }
        public virtual CustomItemRawMaterial CustomItemRawMaterial { get; set; }
        public string Name { get; set; }
        public int MaximumMonthlyConsumption { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int AverageWeightKG { get; set; }

        public string Description { get; set; }

        public int FactoryId { get; set; }
        public Factory Factory { get; set; }
        public int PhotoId { get; set; }
        public int PaperId { get; set; }
        public virtual ICollection<ProductRawMaterial> ProductRawMaterials { get; set; }
  }
   
    }
