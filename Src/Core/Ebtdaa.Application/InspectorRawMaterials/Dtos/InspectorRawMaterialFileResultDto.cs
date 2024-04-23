using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectorRawMaterials.Dtos
{
    public class InspectorRawMaterialFileResultDto
    {
        public int Id { get; set; }
        public int RawMaterialId { get; set; }
        public int AttachmentId { get; set; }
        public string RawMaterialName { get; set; }
        public string Name { get; set; }
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
    }
}
