using Ebtdaa.Domain.InspectorRawMaterials.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Persistence.Configuration.InspectorRawMaterials
{
    public class InspectorRawMaterialConfugration : IEntityTypeConfiguration<InspectorRawMaterial>
    {
        public void Configure(EntityTypeBuilder<InspectorRawMaterial> builder)
        {

            builder.HasOne(prm => prm.RawMaterial)
                .WithMany(p => p.InspectorRawMaterials)
                .HasForeignKey(prm => prm.RawMaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prm => prm.Factory)
                .WithMany(p => p.InspectorRawMaterials)
                .HasForeignKey(prm => prm.FactoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prm => prm.Period)
             .WithMany(p => p.InspectorRawMaterials)
             .HasForeignKey(prm => prm.PeriodId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }          
}
