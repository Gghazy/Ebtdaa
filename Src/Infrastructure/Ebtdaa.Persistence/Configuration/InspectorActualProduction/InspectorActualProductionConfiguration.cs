using Ebtdaa.Domain.InspectorFactoryLocation.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebtdaa.Domain.InspectorActualProduction.Entity;

namespace Ebtdaa.Persistence.Configuration.InspectorActualProduction
{
    public class InspectorActualProductionConfiguration : IEntityTypeConfiguration<InspectActualProduction>
    {
        public void Configure(EntityTypeBuilder<InspectActualProduction> builder)
        {

            builder.HasOne(prm => prm.DesignedCapacityUnit)
                .WithMany(p => p.InspectorDesignedCapacityUnits)
                .HasForeignKey(prm => prm.DesignedCapacityUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prm => prm.ActualProductionUint)
                .WithMany(p => p.InspectorActualProductionUnits)
                .HasForeignKey(prm => prm.ActualProductionUintId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(prm => prm.FactoryProduct)
               .WithMany(p => p.InspectorActualProduction)
               .HasForeignKey(prm => prm.FactoryProductId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
