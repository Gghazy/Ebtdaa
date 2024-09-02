using Ebtdaa.Domain.InspectorRawMaterials.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebtdaa.Domain.InspectorFactoryLocation.Entity;

namespace Ebtdaa.Persistence.Configuration.InspectorFactoryLocations
{
    public class InspectorFactoryLocationConfugration : IEntityTypeConfiguration<InspectFactoryLocation>
    {
        public void Configure(EntityTypeBuilder<InspectFactoryLocation> builder)
        {

            builder.HasOne(prm => prm.Period)
                .WithMany(p => p.InspectorFactoryLocations)
                .HasForeignKey(prm => prm.PeriodId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prm => prm.Factory)
                .WithMany(p => p.InspectorFactoryLocations)
                .HasForeignKey(prm => prm.FactoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prm => prm.City)
               .WithMany(p => p.InspectorFactoryLocations)
               .HasForeignKey(prm => prm.CityId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prm => prm.Area)
              .WithMany(p => p.InspectorFactoryLocations)
              .HasForeignKey(prm => prm.IndustrialAreaId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prm => prm.Entity)
              .WithMany(p => p.InspectorFactoryLocations)
              .HasForeignKey(prm => prm.FactoryEntityId)
              .OnDelete(DeleteBehavior.Restrict);

        }   
    }
}
