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
        public string OwnerIdentity { get; set; }
        public string FactoryNumber { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpirDate { get; set; }
        public int Status { get; set; }
    }
}
