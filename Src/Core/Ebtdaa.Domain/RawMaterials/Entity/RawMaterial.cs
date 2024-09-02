using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.InspectorRawMaterials.Entity;
using Ebtdaa.Domain.Periods;
using Ebtdaa.Domain.ProductData.Entity;

namespace Ebtdaa.Domain.RawMaterials.Entity
{
    public class RawMaterial:BaseEntity
    {
        public int Id { get; set; }
        public string RawMaterialName { get; set; }
        public string CustomItemName { get; set; }
        public string Name { get; set; }
        public decimal MaximumMonthlyConsumption { get; set; }
        public int FactoryId { get; set; }
        public Factory Factory { get; set; }
        public int PeriodId { get; set; }
        public Period Period { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public decimal AverageWeightKG { get; set; }
        public string? Description { get; set; }
        public int? PhotoId { get; set; }
        public int? PaperId { get; set; }
        public virtual ICollection<ProductRawMaterial> ProductRawMaterials { get; set; }
        public virtual ICollection<ActualRawMaterial> ActualRawMaterials { get; set; }
        public virtual ICollection<InspectorRawMaterialFile> InspectorRawMaterialFiles { get; set; }
        public virtual ICollection<InspectorRawMaterial> InspectorRawMaterials { get; set; }
  }
   
    }
