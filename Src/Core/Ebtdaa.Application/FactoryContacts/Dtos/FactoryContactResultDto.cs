

namespace Ebtdaa.Application.FactoryContacts.Dtos
{
    public class FactoryContactResultDto
    {
        public int Id { get; set; }
        public PhoneDto OfficerPhone { get; set; }
        public string OfficerEmail { get; set; }
        public PhoneDto ProductionManagerPhone { get; set; }
        public string ProductionManagerEmail { get; set; }
        public PhoneDto FinanceManagerPhone { get; set; }
        public string FinanceManagerEmail { get; set; }
        public int FactoryId { get; set; }
    }
}
