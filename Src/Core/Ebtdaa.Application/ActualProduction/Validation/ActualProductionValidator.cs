using Ebtdaa.Domain.ActualProduction.Entity;
using FluentValidation;

namespace Ebtdaa.Application.ActualProduction.Validation
{
    public class ActualProductionValidator : AbstractValidator<ActualProductionAndCapacity>
    {
        public ActualProductionValidator() 
        {
            RuleFor(d => d.FactoryProductId)
              .NotEmpty()
              .WithMessage("Product -IsRequired-Field");

            RuleFor(d => d.ActualProductionUintId)
              .NotEmpty()
              .WithMessage("ActualProductionUnit Unit-IsRequired-Field");

            RuleFor(d => d.DesignedCapacity)
              .NotEmpty()
              .WithMessage("حقل الطاقة التصميمة مطلوب");

            RuleFor(d => d.DesignedCapacityUnitId)
              .NotEmpty()
              .WithMessage("DesignedCapacityUnit CapacityUnit-IsRequired-Field");

            RuleFor(d => d.ActualProduction)
              .NotEmpty()
              .WithMessage("حقل الإنتاج الفعلي مطلوب");


        }
    }
}
