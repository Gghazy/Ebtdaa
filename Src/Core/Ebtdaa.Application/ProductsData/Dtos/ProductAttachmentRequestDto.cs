using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Dtos
{
    public class ProductAttachmentRequestDto
    {
        public int Id { get; set; }
        public int AttachmentId { get; set; }
        public int ProductId { get; set; }
        public ProductAttachmentType Type { get; set; }
    }
}
