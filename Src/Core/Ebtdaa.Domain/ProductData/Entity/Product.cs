using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;


namespace Ebtdaa.Domain.ProductData.Entity
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string? CommericalName { get; set; }
        public int? UnitId { get; set; }
        public int? WiegthInKgm { get; set; }
        public int? ProductCount { get; set; }
        public bool AnyNewProducts { get; set; }
        public string? ItemNumber { get; set; }
        public string? CR  { get; set; }
        public string? Status { get; set; }
        public int? FactoryId { get; set; }
        public LevelEnum? Level { get; set; }
        public bool? Review { get; set; }
        public int? ParentId { get; set; }
        public string? Level12Number { get; set; }

        public double? Kilograms_Per_Unit { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Factory factory { get; set; }
        public virtual Product Parent { get; set; }
        public virtual ICollection<ProductAttachment> ProductAttachments { get; set; }
        public virtual ICollection<ActualProductionAndCapacity> ActualProductionAndCapacities { get; set; }

    }
}
