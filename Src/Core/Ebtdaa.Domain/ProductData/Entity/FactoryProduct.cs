using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;


namespace Ebtdaa.Domain.ProductData.Entity
{
    public class FactoryProduct:BaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FactoryId { get; set; }
        public int? PeperId { get; set; }
        public int? PhototId { get; set; }
        public string? CommericalName { get; set; }


        public virtual Product Product { get; set; }
        public virtual Factory Factory { get; set; }
        public virtual Attachment Peper { get; set; }
        public virtual Attachment Photot { get; set; }
        public virtual ICollection<ProductPeriodActive> ProductPeriodActives { get; set; }
        public virtual ICollection<ActualProductionAndCapacity> ActualProductionAndCapacities { get; set; }


    }
}
