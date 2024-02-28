using Ebtdaa.Domain.RawMaterials.Entity;
using FluentValidation;

namespace Ebtdaa.Application.RawMaterials.Validation
{
    public class ItemAttachmentValidator : AbstractValidator<RawMaterialAttachment>
    {
        public ItemAttachmentValidator()
        {
            RuleFor(d => d.AttachmentId)
              .NotEmpty()
              .WithMessage("Attachment-IsRequired-Field");

            RuleFor(d => d.RawMaterialId)
                .NotEmpty()
                .WithMessage("RawMaterial-IsRequired-Field");

        }
    }
}
