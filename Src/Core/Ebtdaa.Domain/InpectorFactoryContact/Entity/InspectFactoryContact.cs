using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Periods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.InpectorFactoryContact.Entity
{
    public class InspectFactoryContact : BaseEntity
    {
        public int Id { get; set; }
        public int FactoryId {  get; set; }
        public int PeriodId { get; set; }
        public int OldOfficerPhoneId { get; set; }
        public string OldOfficerEmail { get; set; }
        public bool IsOfficerPhoneCorrect { get; set; }
        public bool IsOfficerMailCorrect { get; set; }
        public int NewOfficerPhoneId { get; set; }
        public string NewOfficerEmail { get; set; }

        public virtual Factory Factory { get; set; }
        public virtual Period Period { get; set; }
    }

}
