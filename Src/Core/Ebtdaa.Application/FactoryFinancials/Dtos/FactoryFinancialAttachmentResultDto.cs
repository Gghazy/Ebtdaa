using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryFinancials.Dtos
{
    public class FactoryFinancialAttachmentResultDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int AttachmentId { get; set; }
        public int FactoryFinancialId { get; set; }
    }
}
