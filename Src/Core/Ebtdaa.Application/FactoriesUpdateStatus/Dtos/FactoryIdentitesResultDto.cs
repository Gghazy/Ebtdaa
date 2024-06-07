using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoriesUpdateStatus.Dtos
{
    public class FactoryIdentitesResultDto
    {
        public DataStatus DataStatus { get; set; }
        public DataStatus CurrentDataStatus { get; set; }
        public string StatusButton { get; set; }

        public string UserId { get; set; }
        public Boolean isDisable { get; set; }
    }
}
