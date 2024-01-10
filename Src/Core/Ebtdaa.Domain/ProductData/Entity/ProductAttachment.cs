using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.ProductData.Entity
{
    public class ProductAttachment : BaseEntity
    {
        public int Id { get; set; }
        public int AttachmentId { get; set; }
        public int ProductId { get; set; }
        public ProductAttachmentType Type { get; set; }

        public virtual Attachment Attachment { get; set; }
        public virtual Product Product { get; set; }
    }
}
