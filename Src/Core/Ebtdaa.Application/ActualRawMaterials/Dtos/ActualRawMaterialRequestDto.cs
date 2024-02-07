using Ebtdaa.Domain.RawMaterials.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualRawMaterials.Dtos
{
    public class ActualRawMaterialRequestDto
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int RawMaterialId { get; set; }
        public int IncreasedUsageReason { get; set; }
        public double CurrentStockQuantity_KG { get; set; }
        public double UsedQuantity_KG { get; set; }
        public double UsedQuantity { get; set; }
        public double CurrentStockQuantity { get; set; }
        public int StockUnitId { get; set; }
        public int UsageUnitId { get; set; }
    }
}
