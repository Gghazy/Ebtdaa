using Ebtdaa.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Integration
{
    public class FactoryIntegration
    {
        public int Id { get; set; }
        public string? CR { get; set; }
        public string? FactoryName_ar { get; set; }
        public string? FactoryName_en { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? PlantNumber { get; set; }
        public string? Activity { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string OwnerIdentity { get; set; }
        public string? FactoryNumber { get; set; }
        public string? LicenseNumber { get; set; }
        public string? City { get; set; }
        public DateTime? LicenseExpirDate { get; set; }
        public string? Status { get; set; }
    }
}
