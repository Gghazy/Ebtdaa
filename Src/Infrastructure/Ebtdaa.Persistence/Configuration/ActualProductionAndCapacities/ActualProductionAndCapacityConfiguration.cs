using Ebtdaa.Domain.Factories.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.General;

namespace Ebtdaa.Persistence.Configuration.ActualProductionAndCapacities
{
    public class ActualProductionAndCapacityConfiguration : IEntityTypeConfiguration<ActualProductionAndCapacity>
    {
        public void Configure(EntityTypeBuilder<ActualProductionAndCapacity> builder)
        {
            builder.HasOne<Unit>(s => s.DesignedCapacityUnit)
                .WithMany(g => g.DesignedCapacityUnits)
                .HasForeignKey(s => s.DesignedCapacityUnitId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Unit>(s => s.ActualProductionUint)
               .WithMany(g => g.ActualProductionUints)
               .HasForeignKey(s => s.ActualProductionUintId)
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
