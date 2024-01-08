using Ebtdaa.Domain.CustomsItemUpdateData.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.CustomsItemUpdateData.Validation
{
    public class CustomItemUpdateDataValidator : AbstractValidator<CustomsItemUpdate>
    {
        public CustomItemUpdateDataValidator() 
        {
            RuleFor(d => d.ActiveProductsCount)
              .NotEmpty()
              .WithMessage("ActiveProductsCount ProductCount-IsRequired-Field");

            RuleFor(d => d.IsActiveProduct)
              .NotEmpty()
              .WithMessage("ActiveProduct IsActiveProduct-IsRequired-Field");

            RuleFor(d => d.CustomsItem12_Id)
              .NotEmpty()
              .WithMessage("CustomItem CustomsItem12_Id-IsRequired-Field");
        }
    }
}
