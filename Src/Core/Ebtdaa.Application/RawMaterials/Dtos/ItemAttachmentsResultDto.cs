using Ebtdaa.Common.Enums;

namespace Ebtdaa.Application.RawMaterials.Dtos
{
    public class ItemAttachmentsResultDto
    {
        public int Id { get; set; }
        public int AttachmentId { get; set; }
        public int RawMaterialId { get; set; }
        public ProductAttachmentType Type { get; set; }
    }
}
