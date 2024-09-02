using Ebtdaa.Domain.RawMaterials.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebtdaa.Domain.ActualRawMaterials.Entity;

namespace Ebtdaa.Persistence.Configuration.ActualRawMaterials
{
    public class ActualRawMaterialConfugration :IEntityTypeConfiguration<ActualRawMaterial>
    {
        public void Configure(EntityTypeBuilder<ActualRawMaterial> builder)
        {

            builder.HasOne(prm => prm.RawMaterial)
                .WithMany(p => p.ActualRawMaterials)
                .HasForeignKey(prm => prm.RawMaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prm => prm.Period)
                .WithMany(p => p.ActualRawMaterials)
                .HasForeignKey(prm => prm.PeriodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
