using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Factories.Dtos
{
    public class FactoryResualtDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string PlantNumber { get; set; }
        public string CommercialRegister { get; set; }
        public string Activity { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int OwnerIdentity { get; set; }
        public int FactoryNumber { get; set; }
        public int LicenseNumber { get; set; }
        public int FactoryFinancialId { get; set; }
        public int FactoryLocationId { get; set; }
        public int FactoryContactId { get; set; }
        public DateTime LicenseExpirDate { get; set; }
        public string Status { get; set; }
    }
}
