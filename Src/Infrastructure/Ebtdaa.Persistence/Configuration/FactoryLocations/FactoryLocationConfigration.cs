using Ebtdaa.Domain.Factories.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebtdaa.Domain.General;

namespace Ebtdaa.Persistence.Configuration.FactoryLocations
{
    public class FactoryLocationConfigration : IEntityTypeConfiguration<FactoryLocation>
    {
        public void Configure(EntityTypeBuilder<FactoryLocation> builder)
        {
            builder.HasOne<FactoryEntity>(s => s.FactoryEntity)
                .WithMany(g => g.FactoryLocations)
                .HasForeignKey(s => s.FactoryEntityId)
              .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne<IndustrialArea>(s => s.IndustrialArea)
                .WithMany(g => g.FactoryLocations)
                .HasForeignKey(s => s.IndustrialAreaId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<City>(s => s.City)
               .WithMany(g => g.FactoryLocations)
               .HasForeignKey(s => s.CityId)
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
