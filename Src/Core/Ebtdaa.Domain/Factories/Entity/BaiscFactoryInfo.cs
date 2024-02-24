using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Factories.Entity
{
    public class BaiscFactoryInfo : BaseEntity
    {
        public int Id { get; set; }
        public int FactoryId {  get; set; }
        public int PeriodId {  get; set; }
        public FactoryStatusEnum FactoryStatusId {  get; set; }

        public virtual Factory Factory { get; set; }
        public virtual Period Period { get; set; }
        
    }
}
