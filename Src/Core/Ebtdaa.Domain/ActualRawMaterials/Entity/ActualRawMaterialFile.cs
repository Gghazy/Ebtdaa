using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;

namespace Ebtdaa.Domain.ActualRawMaterials.Entity
{
    public class ActualRawMaterialFile : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public virtual Factory Factory { get; set; }

    }
}
