using Ebtdaa.Domain.ActualProduction.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ActualProduction.Validation
{
    public class ActualroductionAttachValidator : AbstractValidator<ActualProductionAttachment>
    {
        public ActualroductionAttachValidator() 
        {
            RuleFor(d => d.AttachmentId)
       .NotEmpty()
       .WithMessage("Attachment-IsRequired-Field");

            RuleFor(d => d.ActualProduvtionId)
                .NotEmpty()
                .WithMessage("Actual Production-IsRequired-Field");

            RuleFor(d => d.Type)
                .NotEmpty()
                .WithMessage("Type-IsRequired-Field");
        }
    }
}
