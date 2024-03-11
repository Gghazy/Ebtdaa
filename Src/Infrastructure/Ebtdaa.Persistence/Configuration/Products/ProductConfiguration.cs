using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.ProductData.Entity;
using Microsoft.EntityFrameworkCore;


namespace Ebtdaa.Persistence.Configuration.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<FactoryProduct>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<FactoryProduct> builder)
        {
            builder.HasOne<Attachment>(s => s.Peper)
               .WithMany(g => g.Perpers)
               .HasForeignKey(s => s.PeperId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Attachment>(s => s.Photot)
              .WithMany(g => g.Photos)
              .HasForeignKey(s => s.PhototId)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
