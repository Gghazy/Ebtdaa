using Ebtdaa.Domain.ActualProduction.Entity;
using FluentValidation;

namespace Ebtdaa.Application.ActualProduction.Validation
{
    public class ActualProductionValidator : AbstractValidator<ActualProductionAndCapacity>
    {
        public ActualProductionValidator() 
        {
            RuleFor(d => d.CustomItemId_12)
              .NotEmpty()
              .WithMessage("CustomItem 12-IsRequired-Field");

            RuleFor(d => d.ActualProductionWeight)
              .NotEmpty()
              .WithMessage("ActualProductionWeight Weight-IsRequired-Field");

            RuleFor(d => d.ActualProductionUintId)
              .NotEmpty()
              .WithMessage("ActualProductionUnit Unit-IsRequired-Field");

            RuleFor(d => d.DesignedCapacity)
              .NotEmpty()
              .WithMessage("DesignedCapacity DesignedCapacity-IsRequired-Field");

            RuleFor(d => d.DesignedCapacityUnitId)
              .NotEmpty()
              .WithMessage("DesignedCapacityUnit CapacityUnit-IsRequired-Field");

            RuleFor(d => d.ActualProduction)
              .NotEmpty()
              .WithMessage("ActualProduction ActualProduction-IsRequired-Field");

            RuleFor(d => d.Month)
             .NotEmpty()
             .WithMessage("Month Month-IsRequired-Field");

            RuleFor(d => d.ReasoneForIncreaseCapacity)
             .NotEmpty()
             .WithMessage("Reason ReasoneForIncreaseCapacity-IsRequired-Field");
        }
    }
}
