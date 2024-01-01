using Ebtdaa.Common.Enums;
using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryLocations.Validation
{
    public class FactoryLocationAttachmentValidator : AbstractValidator<FactoryLocationAttachment>
    {
        public FactoryLocationAttachmentValidator()
        {
            RuleFor(d => d.AttachmentId)
              .NotEmpty()
              .WithMessage("Attachment-IsRequired-Field");

            RuleFor(d => d.FactoryLocationId)
                .NotEmpty()
                .WithMessage("Factory Location-IsRequired-Field");

            RuleFor(d => d.Type)
                .NotEmpty()
                .WithMessage("Type-IsRequired-Field");


        }
    }
}
