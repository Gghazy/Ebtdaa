using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Periods;
using Ebtdaa.Domain.RawMaterials.Entity;

namespace Ebtdaa.Domain.InspectorRawMaterials.Entity
{
    public class InspectorRawMaterial:BaseEntity
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public int RawMaterialId { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
        public bool IsClearImage { get; set; }
        public string Comment { get; set; }
        public int? PhotoId { get; set; }
        public int? PaperId { get; set; }
        public virtual Factory Factory { get; set; }
        public virtual Period Period { get; set; }


    }
}
