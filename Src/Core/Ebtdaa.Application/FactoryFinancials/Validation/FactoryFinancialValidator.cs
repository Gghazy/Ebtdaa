using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryFinancials.Validation
{
    public class FactoryFinancialValidator : AbstractValidator<FactoryFinancial>
    {
        public FactoryFinancialValidator()
        {
            RuleFor(d => d.Revenues)
              .NotEmpty()
              .WithMessage("حقل الإيرادات مطلوب");

            RuleFor(d => d.WaterExpenses)
              .NotEmpty()
              .WithMessage("حقل نفقات المياه مطلوب ");

            RuleFor(d => d.ElectricityExpenses)
              .NotEmpty()
              .WithMessage("حقل نفقات الكهرباء مطلوب");

            RuleFor(d => d.FuelExpenses)
              .NotEmpty()
              .WithMessage("حقل نفقات الوقود مطلوب");

            RuleFor(d => d.RawMterialExpenses)
              .NotEmpty()
              .WithMessage("حقل نفقات المواد الخام ");

            RuleFor(d => d.EmploymentExpenses)
              .NotEmpty()
              .WithMessage("حقل نفقات العمالة مطلوب");

            //RuleFor(d => d.OtherOperatingExpenses)
            //  .NotEmpty()
            //  .WithMessage("Other Operating Expenses-IsRequired-Field");

            //RuleFor(d => d.TotalExpenses)
            //  .NotEmpty()
            //  .WithMessage("Total Expenses-IsRequired-Field");

            RuleFor(d => d.Assets)
              .NotEmpty()
              .WithMessage("حقل الأصول المتداولة مطلوب");

            RuleFor(d => d.NonCurrentAssets)
              .NotEmpty()
              .WithMessage("حقل الأصول الغير متداولة مطلوب");

            RuleFor(d => d.CurrentLiabilities)
              .NotEmpty()
              .WithMessage("حقل الخصوم المتداولة مطلوب");

            RuleFor(d => d.NonCurrentLiabilities)
              .NotEmpty()
              .WithMessage("حقل الخصوم الغير متداولة مطلوب");

            //RuleFor(d => d.FactoryId)
            //  .NotEmpty()
            //  .WithMessage("Factory-IsRequired-Field");

        }
         
    }
}
