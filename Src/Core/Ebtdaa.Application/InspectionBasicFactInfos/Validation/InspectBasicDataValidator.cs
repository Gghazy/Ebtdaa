using Ebtdaa.Domain.InspectorBasicFactoryInfo.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.InspectionBasicFactInfos.Validation
{
    public class InspectBasicDataValidator : AbstractValidator<InspectBasicFactoryInfo>
    {
        public InspectBasicDataValidator() 
        {
            RuleFor(d => d.IsFactNameCorrect)
            .NotEmpty()
            .WithMessage("IsFactNameCorrect Entity-IsRequired-Field");

            RuleFor(d => d.IsFactStatusCorrect)
            .NotEmpty()
            .WithMessage("IsFactStatusCorrect Entity-IsRequired-Field");


        }
    }
}
