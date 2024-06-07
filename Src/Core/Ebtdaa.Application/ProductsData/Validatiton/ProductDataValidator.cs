using Ebtdaa.Domain.ProductData.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Validatiton
{
    public class ProductDataValidator : AbstractValidator<FactoryProduct>
    {
        public ProductDataValidator() 
        {
            RuleFor(d => d.CommericalName)
             .NotEmpty()
             .WithMessage("اسم المنتج التجاري , هذا الحقل مطلوب");
            RuleFor(d => d.ProductId)
             .NotEmpty()
             .WithMessage("اسم المنتج (حسب البند الجمركي على مستوى 12) , هذا الحقل مطلوب");

        }
    }
}
