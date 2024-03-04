using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ReverseApproval.Dtos
{
    public class ReverseApprovalResultDto
    {
        public int Id { get; set; }
        public int FactoryId { get; set; }
        public bool UpdateSataus { get; set; } = false;
    }
}
