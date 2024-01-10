using Ebtdaa.Domain.ProductData.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.ProductsData.Validatiton
{
    public class ProductAttachmentValidatorcs : AbstractValidator<ProductAttachment>
    {
        public ProductAttachmentValidatorcs() 
        {
            RuleFor(d => d.AttachmentId)
              .NotEmpty()
              .WithMessage("Attachment-IsRequired-Field");

            RuleFor(d => d.ProductId)
                .NotEmpty()
                .WithMessage("Factory Financial-IsRequired-Field");

            RuleFor(d => d.Type)
                .NotEmpty()
                .WithMessage("Type-IsRequired-Field");
        }   
    }
}
