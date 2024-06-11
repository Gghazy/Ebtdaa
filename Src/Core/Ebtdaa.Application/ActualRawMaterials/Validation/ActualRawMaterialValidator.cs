using Ebtdaa.Domain.ActualRawMaterials.Entity;
using FluentValidation;

namespace Ebtdaa.Application.ActualRawMaterials.Validation
{
    public class ActualRawMaterialValidator : AbstractValidator<ActualRawMaterial>
    {
        public ActualRawMaterialValidator()
        {
            RuleFor(d => d.UsedQuantity)
              .NotEmpty()
              .WithMessage("حقل الكمية المستخدمة مطلوب");

            RuleFor(d => d.CurrentStockQuantity)
              .NotEmpty()
              .WithMessage("حقل الكمية المخزون الحالي مطلوب");
            RuleFor(d => d.CurrentStockQuantity_KG)
              .NotEmpty()
              .WithMessage("حقل كمية المخزون الحالي بالكيلو جرام مطلوب");
            RuleFor(d => d.UsedQuantity_KG)
              .NotEmpty()
              .WithMessage("حقل المكية المستخدمة بالكيلو جرام مطلوب");
            
        }
    }
}
