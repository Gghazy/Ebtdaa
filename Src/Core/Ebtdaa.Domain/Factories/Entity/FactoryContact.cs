using Ebtdaa.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Factories.Entity
{
    public class FactoryContact: BaseEntity
    {
        public int Id { get; set; }
        public int OfficerPhoneId { get; set; }
        public string OfficerEmail { get; set; }
        public int ProductionManagerPhoneId { get; set; }
        public string ProductionManagerEmail { get; set; }
        public int FinanceManagerPhoneId { get; set; }
        public string FinanceManagerEmail { get; set; }
        public int FactoryId { get; set; }


        public virtual Factory Factory { get; set; }
        public virtual Phone OfficerPhone { get; set; }
        public virtual Phone ProductionManagerPhone { get; set; }
        public virtual Phone FinanceManagerPhone { get; set; }

    }
}
