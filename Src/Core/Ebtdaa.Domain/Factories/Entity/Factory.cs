using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.ProductData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Domain.Factories.Entity
{
    public class Factory:BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? PlantNumber { get; set; }
        public string? CommercialRegister { get; set; }
        public string? Activity { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? OwnerIdentity { get; set; }
        public string? FactoryNumber { get; set; }
        public string? LicenseNumber { get; set; }
        public DateTime? LicenseExpirDate { get; set; }
        public FactoryStatusEnum? Status  { get; set; }

        public virtual ICollection<FactoryFinancial> FactoryFinancials { get; set; }
        public virtual ICollection<FactoryLocation> FactoryLocations { get; set; }
        public virtual ICollection<FactoryContact> FactoryContacts { get; set; }
        public virtual ICollection<FactoryFile> FactoryFiles { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
