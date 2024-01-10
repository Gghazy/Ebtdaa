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

        }
    }
}
