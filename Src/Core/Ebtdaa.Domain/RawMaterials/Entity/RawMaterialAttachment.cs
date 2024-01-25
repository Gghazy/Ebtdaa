using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.ProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.RawMaterials.Entity
{
    public class RawMaterialAttachment:BaseEntity
    {
        public int Id { get; set; }
        public int AttachmentId { get; set; }

        public virtual Attachment Attachment { get; set; }
        public int RawMaterialId { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
        public ProductAttachmentType Type { get; set; }

      

    }
}
