using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectorUpdateStatus.Dtos
{
    public class InspectorUpdateStatusRequestDto
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public bool UpdateStatus { get; set; }
        public DateTime? EnteredAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DataStatus DataStatus { get; set; }
    }
}
