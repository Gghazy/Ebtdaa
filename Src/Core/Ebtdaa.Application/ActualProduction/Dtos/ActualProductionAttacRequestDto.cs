using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Dtos
{
    public class ActualProductionAttacRequestDto
    {
        public int Id { get; set; }
        public int AttachmentId { get; set; }
        public int ActualProductionId { get; set; }
        public ActualProductionFileType Type { get; set; }

    }
}
