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
        public string OfficerPhone { get; set; }
        public string OfficerEmail { get; set; }
        public string ProductionManagerPhone { get; set; }
        public string ProductionManagerEmail { get; set; }
        public string FinanceManagerPhone { get; set; }
        public string FinanceManagerEmail { get; set; }
        public int FactoryId { get; set; }


        public Factory Factory { get; set; }

    }
}
