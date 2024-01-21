using Ebtdaa.Domain.Factories.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Persistence.Configuration.Factory
{
    public class FactoryContactConfiguration : IEntityTypeConfiguration<FactoryContact>
    {
        public void Configure(EntityTypeBuilder<FactoryContact> builder)
        {
            builder.HasOne<Phone>(s => s.OfficerPhone)
                .WithMany(g => g.OfficerPhones)
                .HasForeignKey(s => s.OfficerPhoneId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Phone>(s => s.FinanceManagerPhone)
              .WithMany(g => g.FinanceManagerPhones)
              .HasForeignKey(s => s.FinanceManagerPhoneId)
            .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne<Phone>(s => s.ProductionManagerPhone)
              .WithMany(g => g.ProductionManagerPhones)
              .HasForeignKey(s => s.ProductionManagerPhoneId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
