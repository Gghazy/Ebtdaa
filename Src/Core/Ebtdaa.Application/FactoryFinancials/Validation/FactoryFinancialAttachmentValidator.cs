using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;


namespace Ebtdaa.Application.FactoryFinancials.Validation
{
    public class FactoryFinancialAttachmentValidator : AbstractValidator<FactoryFinancialAttachment>
    {
        public FactoryFinancialAttachmentValidator()
        {
            RuleFor(d => d.AttachmentId)
              .NotEmpty()
              .WithMessage("حقل المرفقات مطلوب");

            //RuleFor(d => d.FactoryFinancialId)
            //    .NotEmpty()
            //    .WithMessage("Factory Financial-IsRequired-Field");






        }
    }
}
