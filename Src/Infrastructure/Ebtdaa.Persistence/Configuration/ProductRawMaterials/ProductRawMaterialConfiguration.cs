using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Ebtdaa.Domain.RawMaterials.Entity;

namespace Ebtdaa.Persistence.Configuration.ProductRawMaterials
{
    public class ProductRawMaterialConfiguration : IEntityTypeConfiguration<ProductRawMaterial>
    {
        public void Configure(EntityTypeBuilder<ProductRawMaterial> builder)
        {
            builder.HasKey(prm => new { prm.FactoryProductId, prm.rawMaterialId });

            builder.HasOne(prm => prm.FactoryProduct)
                .WithMany(p => p.ProductRawMaterials)
                .HasForeignKey(prm => prm.FactoryProductId);

            builder.HasOne(prm => prm.RawMaterial)
                .WithMany(r => r.ProductRawMaterials)
                .HasForeignKey(prm => prm.rawMaterialId);


        }
    }
}
