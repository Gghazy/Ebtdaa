﻿using Ebtdaa.Domain.General;
using Ebtdaa.Domain.RawMaterials.Entity;

namespace Ebtdaa.Domain.ActualRawMaterials.Entity
{
    public class ActualRawMaterial:BaseEntity
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public int RawMaterialId { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public double CurrentStockQuantity_KG { get; set; }
        public double UsedQuantity_KG { get; set; }
        public double IncreasedUsageReason { get; set; }
        public double UsedQuantity { get; set; }
        public double CurrentStockQuantity { get; set; }
        public int StockUnitId { get; set; }
        public int UsageUnitId { get; set; }

    }
}
