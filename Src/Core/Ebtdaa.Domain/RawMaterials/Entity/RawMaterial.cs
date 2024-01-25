using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.ProductData.Entity;

namespace Ebtdaa.Domain.RawMaterials.Entity
{
    public class RawMaterial:BaseEntity
    {
        public int Id { get; set; }
        public string CustomItemName { get; set; }
        public string Name { get; set; }
        public int MaximumMonthlyConsumption { get; set; }
        public int AverageWeightKG { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string Description { get; set; }

        public int FactoryId { get; set; }
        public Factory Factory { get; set; }
        public int AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }

    }
}
