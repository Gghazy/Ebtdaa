using Ebtdaa.Domain.ActualRawMaterials.Entity;
using FluentValidation;

namespace Ebtdaa.Application.ActualRawMaterials.Validation
{
    public class ActualRawMaterialFileValidator : AbstractValidator<ActualRawMaterialFile>
    {
        public ActualRawMaterialFileValidator()
        {
            RuleFor(d => d.AttachmentId)
            .NotEmpty()
            .WithMessage("Attachment-IsRequired-Field");

            RuleFor(d => d.FactoryId)
                .NotEmpty()
                .WithMessage("Factory-IsRequired-Field");

            
        }
    }
}
