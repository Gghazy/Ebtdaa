using Ebtdaa.Domain.General;
using Ebtdaa.Domain.InspectorProductData.Entity;
using Ebtdaa.Domain.ProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionProductData.Dtos
{
    public class InspectProductAttachResDto
    {
        public int Id {  get; set; }
        public int ProductId { get; set; }
        public int InspectProductId {  get; set; }
        public int AttachmentId { get; set; }
        public string Name {  get; set; }
        public string Path {  get; set; }
        public string Extension {  get; set; }

    }
}
