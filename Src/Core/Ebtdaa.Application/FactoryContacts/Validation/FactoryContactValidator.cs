using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;


namespace Ebtdaa.Application.FactoryContacts.Validation
{
    public class FactoryContactValidator : AbstractValidator<FactoryContact>
    {
        public FactoryContactValidator()
        {
            RuleFor(d => d.OfficerPhone)
              .NotEmpty()
              .WithMessage("Officer Phone-IsRequired-Field");

            RuleFor(d => d.OfficerEmail)
                .NotEmpty()
                .WithMessage("Officer Email-IsRequired-Field");


            RuleFor(d => d.ProductionManagerPhone)
              .NotEmpty()
              .WithMessage("Production Manager Phone-IsRequired-Field");

            RuleFor(d => d.ProductionManagerEmail)
              .NotEmpty()
              .WithMessage("Production Manager Email-IsRequired-Field");

            RuleFor(d => d.FinanceManagerPhone)
              .NotEmpty()
              .WithMessage("Finance Manager Phone-IsRequired-Field");

            RuleFor(d => d.FinanceManagerEmail)
              .NotEmpty()
              .WithMessage("Finance Manager Email-IsRequired-Field");

            RuleFor(d => d.FactoryId)
             .NotEmpty()
             .WithMessage("Factory-IsRequired-Field");


        }
    }
}
