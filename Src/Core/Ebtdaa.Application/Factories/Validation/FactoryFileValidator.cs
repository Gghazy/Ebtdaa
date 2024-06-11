using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Factories.Validation
{
    public class FactoryFileValidator : AbstractValidator<FactoryFile>
    {
        public FactoryFileValidator()
        {
            RuleFor(d => d.AttachmentId)
              .NotEmpty()
              .WithMessage("صورة واجهة المصنع , هذا الحقل مطلوب");

            //RuleFor(d => d.FactoryId)
            //    .NotEmpty()
            //    .WithMessage("Factory-IsRequired-Field");

            //RuleFor(d => d.Type)
            //   .NotEmpty()
            //   .WithMessage("نوع المستند , هذا الحقل مطلوب");




        }
    }
}
