﻿using Ebtdaa.Domain.ActualProduction.Entity;
using FluentValidation;

namespace Ebtdaa.Application.ActualProduction.Validation
{
    public class ActualProductionValidator : AbstractValidator<ActualProductionAndCapacity>
    {
        public ActualProductionValidator() 
        {
            RuleFor(d => d.ProductId)
              .NotEmpty()
              .WithMessage("CustomItem 12-IsRequired-Field");


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

            RuleFor(d => d.MonthId)
             .NotEmpty()
             .WithMessage("Month Month-IsRequired-Field");

        }
    }
}
