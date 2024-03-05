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
              .WithMessage("Water Expenses-IsRequired-Field");

            RuleFor(d => d.ElectricityExpenses)
              .NotEmpty()
              .WithMessage("Electricity Expenses-IsRequired-Field");

            RuleFor(d => d.FuelExpenses)
              .NotEmpty()
              .WithMessage("Fuel Expenses-IsRequired-Field");

            RuleFor(d => d.RawMterialExpenses)
              .NotEmpty()
              .WithMessage("RawMterial Expenses-IsRequired-Field");

            RuleFor(d => d.EmploymentExpenses)
              .NotEmpty()
              .WithMessage("Employment Expenses-IsRequired-Field");

            RuleFor(d => d.OtherOperatingExpenses)
              .NotEmpty()
              .WithMessage("Other Operating Expenses-IsRequired-Field");

            RuleFor(d => d.TotalExpenses)
              .NotEmpty()
              .WithMessage("Total Expenses-IsRequired-Field");


            RuleFor(d => d.FactoryId)
              .NotEmpty()
              .WithMessage("Factory-IsRequired-Field");

            RuleFor(d => d.PeriodId)
             .NotEmpty()
             .WithMessage("Period-IsRequired-Field");

        }
    }
}
