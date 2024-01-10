using Ebtdaa.Domain.RawMaterials.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualRawMaterials.Dtos
{
    public class ActualRawMaterialResultDto
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int RawMaterialId { get; set; }
        public int CurrentStockQuantity_KG { get; set; }
        public int UsedQuantity_KG { get; set; }
        public int IncreasedUsageReason { get; set; }
    }
}
