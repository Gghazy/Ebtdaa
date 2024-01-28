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

            RuleFor(d => d.ActualRawMaterialId)
                .NotEmpty()
                .WithMessage("ActualRawMaterial-IsRequired-Field");
            RuleFor(d => d.Name)
               .NotEmpty()
               .WithMessage("Name-IsRequired-Field");


        }
    }
}
