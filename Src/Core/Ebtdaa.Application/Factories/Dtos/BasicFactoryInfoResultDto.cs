using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Factories.Dtos
{
    public class BasicFactoryInfoResultDto
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public FactoryStatusEnum? FactoryStatusId { get; set; }
        public string DataEntry { get; set; }
        public DateTime EnterDate { get; set; }
        public string DataReviewer { get; set; }
        public DateTime ReviewDate { get; set; }
        public string DataApprover { get; set; }
        public DateTime DateApprove { get; set; }
    }
}
