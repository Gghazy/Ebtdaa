using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;


namespace Ebtdaa.Application.FactoryContacts.Validation
{
    public class FactoryContactValidator : AbstractValidator<FactoryContact>
    {
        public FactoryContactValidator()
        {
            RuleFor(d => d.OfficerPhone)
              .NotEmpty()
              .WithMessage("حقل رقم جوال ضابط الاتصال مطلوب");

            RuleFor(d => d.OfficerEmail)
                .NotEmpty()
                .WithMessage("حقل البريد الإلكتروني لضابط الاتصال مطلوب");


            RuleFor(d => d.ProductionManagerPhone)
              .NotEmpty()
              .WithMessage("حقل رقم جوال مدير الإنتاج مطلوب");

            RuleFor(d => d.ProductionManagerEmail)
              .NotEmpty()
              .WithMessage("حقل البريد الإلكتروني لمدير الإنتاج مطلوب");

            RuleFor(d => d.FinanceManagerPhone)
              .NotEmpty()
              .WithMessage("حقل رقم جوال مدير المالية مطلوب");

            RuleFor(d => d.FinanceManagerEmail)
              .NotEmpty()
              .WithMessage("حقل البريد الإلكتروني لمدير المالية مطلوب");

            RuleFor(d => d.FactoryId)
             .NotEmpty()
             .WithMessage("Factory-IsRequired-Field");


        }
    }
}
