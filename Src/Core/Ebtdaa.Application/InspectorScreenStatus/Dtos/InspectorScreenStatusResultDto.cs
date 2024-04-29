using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectorScreenStatus.Dtos
{
    public class InspectorScreenStatusResultDto
    {
        public bool? InspectorBasicFactoryInfo { get; set; }
        public bool? InspectorFactoryLocation { get; set; }
        public bool? InspectorFactoryContact { get; set; }
        public bool? InspectorProductData { get; set; }
        public bool? InspectorActualProduction { get; set; }
        public bool? InspectorRawMaterial { get; set; }
    }
}
