using Ebtdaa.Common.Enums;


namespace Ebtdaa.Application.ScreenUpdateStatus.Dtos
{
    public class ScreenStatusResultDto
    {
        public bool? BasicFactoryInfo { get; set; }
        public bool? FinancialData { get; set; }
        public bool? FactoryLocation { get; set; }
        public bool? FactoryContact { get; set; }
        public bool? CustomItemsUpdated { get; set; }
        public bool? CustomItemValidity { get; set; }
        public bool? ProductData { get; set; }
        public bool? ActualProduction { get; set; }
        public bool? RawMaterial { get; set; }
        public bool? ActualRawMaterila { get; set; }

    }
}
