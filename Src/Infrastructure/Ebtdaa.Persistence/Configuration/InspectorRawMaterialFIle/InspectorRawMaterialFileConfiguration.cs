using Ebtdaa.Domain.RawMaterials.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebtdaa.Domain.InspectorRawMaterials.Entity;

namespace Ebtdaa.Persistence.Configuration.InspectorRawMaterialFIle
{
    public class InspectorRawMaterialFileConfiguration : IEntityTypeConfiguration<InspectorRawMaterialFile>
    {
        public void Configure(EntityTypeBuilder<InspectorRawMaterialFile> builder)
        {

            builder.HasOne(prm => prm.RawMaterial)
                .WithMany(p => p.InspectorRawMaterialFiles)
                .HasForeignKey(prm => prm.RawMaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prm => prm.Factory)
                .WithMany(p => p.InspectorRawMaterialFiles)
                .HasForeignKey(prm => prm.FactoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prm => prm.Attachment)
               .WithMany(p => p.InspectorRawMaterialFiles)
               .HasForeignKey(prm => prm.AttachmentId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
