

namespace Ebtdaa.Application.FactoryFinancials.Dtos
{
    public class FactoryFinancialResultDto
    {
        public int Id { get; set; }
        public decimal Revenues { get; set; }
        public decimal WaterExpenses { get; set; }
        public decimal ElectricityExpenses { get; set; }
        public decimal FuelExpenses { get; set; }
        public decimal RawMterialExpenses { get; set; }
        public decimal EmploymentExpenses { get; set; }
        public decimal OtherOperatingExpenses { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal Assets { get; set; }
        public decimal NonCurrentAssets { get; set; }
        public decimal CurrentLiabilities { get; set; }
        public decimal NonCurrentLiabilities { get; set; }
        public int FactoryId { get; set; }
        public int Year { get; set; }
    }
}
