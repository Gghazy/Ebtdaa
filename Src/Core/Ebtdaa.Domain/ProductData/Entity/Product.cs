using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.RawMaterials.Entity;

namespace Ebtdaa.Domain.ProductData.Entity
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? UnitId { get; set; }
        public string? ItemNumber { get; set; }
        public string? CR  { get; set; }
        public string? Status { get; set; }
        public bool? Review { get; set; }
        public string? Level12Number { get; set; }


        public double? Kilograms_Per_Unit { get; set; }
        public virtual Unit Unit { get; set; }  
       public virtual ICollection<FactoryProduct> FactoryProducts { get; set; }



    }
}
