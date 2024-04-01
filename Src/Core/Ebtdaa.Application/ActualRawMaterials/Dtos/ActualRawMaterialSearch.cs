using Ebtdaa.Common.Dtos;

namespace Ebtdaa.Application.ActualRawMaterials.Dtos
{
    public class ActualRawMaterialSearch:SearchCriteria
    {
        public int FactoryId { get; set; }
        public int PeriodId { get; set; }

    }
}
