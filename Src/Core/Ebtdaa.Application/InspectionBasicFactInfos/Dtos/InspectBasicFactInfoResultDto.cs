using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionBasicFactInfos.Dtos
{
    public class InspectBasicFactInfoResultDto
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public bool IsFactNameCorrect { get; set; }
        public bool IsFactStatusCorrect { get; set; }
        public string FactoryName { get; set; }
        public string OwnerIdentity { get; set; }
        public string Comments { get; set; }
        public FactoryStatusEnum FactoryStatus { get; set; }
    }
}
