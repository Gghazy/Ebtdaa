using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryLocations.Validation
{
    public class FactoryLocationValidator : AbstractValidator<FactoryLocation>
    {
        public FactoryLocationValidator()
        {
            RuleFor(d => d.FactoryEntityId)
              .NotEmpty()
              .WithMessage("Factory Entity-IsRequired-Field");

            RuleFor(d => d.CityId)
              .NotEmpty()
              .WithMessage("City-IsRequired-Field");
            
            RuleFor(d => d.IndustrialAreaId)
              .NotEmpty()
              .WithMessage("Industrial Area-IsRequired-Field");

            RuleFor(d => d.WebSite)
              .NotEmpty()
              .WithMessage("WebSite-IsRequired-Field");

            RuleFor(d => d.FactoryId)
              .NotEmpty()
              .WithMessage("Factory-IsRequired-Field");

        }
    }
}
