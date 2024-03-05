using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Periods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Factories.Entity
{
    public class FactoryUpdateStatus : BaseEntity
    {
        public int Id {  get; set; }
        public int FactoryId {  get; set; }
        public int PeriodId {  get; set; }
        public bool UpdateStatus {  get; set; }

        public virtual Factory Factory { get; set; }
        public virtual Period Period { get; set; }
    }
}
