using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Periods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.InspectorUpdateStatus.Entity
{
    public class InspectorUpdateStatuses : BaseEntity
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public bool UpdateStatus { get; set; }
        public DateTime? EnteredAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public DataStatus DataStatus { get; set; }
        public virtual Factory Factory { get; set; }
        public virtual Period Period { get; set; }
    }
}
