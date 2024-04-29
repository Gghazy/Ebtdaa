using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionProductData.Dtos
{
    public class InspectProductAttachReqDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PeriodId { get; set; }
        public int FactoryId { get; set; }
        public int AttachmentId { get; set; }
        public string Name { get; set; }
    }
}
