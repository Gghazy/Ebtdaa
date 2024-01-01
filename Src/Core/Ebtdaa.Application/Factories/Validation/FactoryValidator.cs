using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;


namespace Ebtdaa.Application.Factories.Validation
{
    public class FactoryValidator : AbstractValidator<Factory>
    {
        public FactoryValidator()
        {
            RuleFor(d => d.NameAr)
              .NotEmpty()
              .WithMessage("arabic Name-IsRequired-Field");

            RuleFor(d => d.NameEn)
                .NotEmpty()
                .WithMessage("English Name-IsRequired-Field");

            RuleFor(d => d.Email)
               .NotEmpty()
               .WithMessage("Email-IsRequired-Field");

            RuleFor(d => d.MobileNumber)
               .NotEmpty()
               .WithMessage("Mobile Number-IsRequired-Field");

            RuleFor(d => d.PlantNumber)
               .NotEmpty()
               .WithMessage("Plant Number-IsRequired-Field");

            RuleFor(d => d.CommercialRegister)
               .NotEmpty()
               .WithMessage("Commercial Register-IsRequired-Field");

            RuleFor(d => d.Activity)
               .NotEmpty()
               .WithMessage("Activity-IsRequired-Field");

            RuleFor(d => d.RegistrationDate)
               .NotEmpty()
               .WithMessage("Registration Date-IsRequired-Field");

            RuleFor(d => d.OwnerIdentity)
               .NotEmpty()
               .WithMessage("Owner Identity-IsRequired-Field");

            RuleFor(d => d.FactoryNumber)
               .NotEmpty()
               .WithMessage("Factory Number-IsRequired-Field");

            RuleFor(d => d.LicenseNumber)
               .NotEmpty()
               .WithMessage("License Number-IsRequired-Field");

            RuleFor(d => d.LicenseExpirDate)
               .NotEmpty()
               .WithMessage("License ExpirDate-IsRequired-Field");
            
            RuleFor(d => d.Status)
               .NotEmpty()
               .WithMessage("Status-IsRequired-Field");
        }    
          
    }
}
