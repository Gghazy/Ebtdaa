using Ebtdaa.Common.Enums;

namespace Ebtdaa.Application.RawMaterials.Dtos
{
    public class ItemAttachmentsRequestDto
    {
        public int Id { get; set; }
        public int AttachmentId { get; set; }
        public int RawMaterialId { get; set; }
    }
}
