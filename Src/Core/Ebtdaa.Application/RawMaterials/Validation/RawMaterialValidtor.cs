using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.RawMaterials.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.RawMaterials.Validation
{
    public class RawMaterialValidtor : AbstractValidator<RawMaterial>
    {
        public RawMaterialValidtor()
        {
            RuleFor(d => d.AverageWeightKG)
                .NotEmpty()
                .WithMessage("حقل الوزن المقابل بالكيلو جرام مطلوب");
            RuleFor(d => d.MaximumMonthlyConsumption)
                .NotEmpty()
                .WithMessage("حقل أقصى استهلاك شهري مطلوب");
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("اسم المادة الأولية(الخام) التجاري مطلوب");
            RuleFor(d => d.CustomItemName)
               .NotEmpty()
               .WithMessage("اسم البند المركي على مستوى 12 مطلوب");
        }
    }
}
