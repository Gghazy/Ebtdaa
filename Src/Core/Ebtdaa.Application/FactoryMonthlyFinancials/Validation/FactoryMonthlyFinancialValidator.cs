using Ebtdaa.Domain.Factories.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryMonthlyFinancials.Validation
{
    public class FactoryMonthlyFinancialValidator : AbstractValidator<FactoryMonthlyFinancial>
    {
        public FactoryMonthlyFinancialValidator()
        {

           
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


            //RuleFor(d => d.FactoryId)
            //  .NotEmpty()
            //  .WithMessage("Factory-IsRequired-Field");

            //RuleFor(d => d.PeriodId)
            // .NotEmpty()
            // .WithMessage("Period-IsRequired-Field");

        }
    }
}
