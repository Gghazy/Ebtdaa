using FluentValidation;
using Ebtdaa.Domain.General;

namespace Ebtdaa.Application.Attachments.Validation
{
    public class AttachmentValidator : AbstractValidator<Attachment>
    {
        public AttachmentValidator()
        {

            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("Name-IsRequired-Field");

            RuleFor(d => d.Path)
              .NotEmpty()
              .WithMessage("Path-IsRequired-Field");

        }
    }
}
