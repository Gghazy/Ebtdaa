using Ebtdaa.Domain.General;

namespace Ebtdaa.Domain.ActualRawMaterials.Entity
{
    public class ActualRawMaterialFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
        public int ActualRawMaterialId { get; set; }
        public virtual ActualRawMaterial ActualRawMaterial { get; set; }



       
    }
}
