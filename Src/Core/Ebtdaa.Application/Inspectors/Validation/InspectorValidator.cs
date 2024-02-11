using Ebtdaa.Domain.Inspectors.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Inspectors.Validation
{
    public class InspectorValidator : AbstractValidator<Inspector>
    {
        public InspectorValidator() 
        {
            RuleFor(d => d.Name)
              .NotEmpty()
              .WithMessage("Name Name-IsRequired-Field");
            RuleFor(d => d.OwnerIdentity)
              .NotEmpty()
              .WithMessage("OwnerIdentity OwnerIdentity-IsRequired-Field");

        } 
    }
}
