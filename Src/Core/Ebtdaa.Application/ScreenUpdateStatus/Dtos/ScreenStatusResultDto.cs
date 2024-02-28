using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ScreenUpdateStatus.Dtos
{
    public class ScreenStatusResultDto
    {
        public int Id { get; set; }
        public int PeriodId { get; set; }
        public int FactoryId { get; set; }
        public bool IsEdit { get; set; }
        public ScreenEnums screenEnums { get; set; }
    }
}
