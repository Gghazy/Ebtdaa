using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.CustomsItemUpdateData.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.RawMaterials.Entity;
using Ebtdaa.Domain.ProductData.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ebtdaa.Persistence.Configuration.Factory;
using Ebtdaa.Persistence.Configuration.Products;
using Ebtdaa.Persistence.Configuration.ActualProductionAndCapacities;
using Ebtdaa.Domain.Inspectors.Entity;
using System.Reflection.Emit;
using Ebtdaa.Persistence.Configuration.ProductRawMaterials;
using Ebtdaa.Domain.InspectorRawMaterials.Entity;
using Ebtdaa.Domain.Periods;

namespace Ebtdaa.Persistence
{
    public class EbtdaaDbContext:DbContext, IEbtdaaDbContext
    {
        public EbtdaaDbContext(DbContextOptions<EbtdaaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new FactoryContactConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ActualProductionAndCapacityConfiguration());
            builder.ApplyConfiguration(new ProductRawMaterialConfiguration());


           
            base.OnModelCreating(builder);

        }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<FactoryFile> FactoryFiles { get; set; }
        public DbSet<FactoryFinancial> FactoryFinancials { get; set; }
        public DbSet<FactoryFinancialAttachment> FactoryFinancialAttachments { get; set; }
        public DbSet<FactoryEntity> FactoryEntities { get; set; }
        public DbSet<FactoryLocation> FactoryLocations { get; set; }
        public DbSet<FactoryLocationAttachment> FactoryLocationAttachments { get; set; }
        public DbSet<IndustrialArea> IndustrialAreas { get; set; }
        public DbSet<FactoryContact> FactoryContacts { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<RawMaterialAttachment> RawMaterialAttachments { get; set; }
        public DbSet<ActualRawMaterial> ActualRawMaterials { get; set; }
        public DbSet<ActualRawMaterialFile> ActualRawMaterialFiles { get; set; }
        public DbSet<CustomsItemUpdate> CustomsItemUpdates { get; set; }
        public DbSet<ActualProductionAndCapacity> ActualProductionAndCapacities { get; set; }
        public DbSet<ReasonIncreasCapacity> ReasonIncreasCapacities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ActualProductionAttachment> ActualProductionAttachments { get; set; }
        public DbSet<ProductAttachment> ProductAttachments { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<IncreaseActualProduction> IncreaseActualProductions { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Inspector> Inspectors { get; set; }
        public DbSet<InspectorFactory> InspectorFactories { get; set; }
        public DbSet<ProductRawMaterial> ProductRawMaterials { get; set; }
        public DbSet<InspectorRawMaterial> InspectorRawMaterials { get; set; }
        public DbSet<BaiscFactoryInfo> BasicFactoryInfos { get; set; }

        public Task<int> SaveChangesAsync()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }
            return  base.SaveChangesAsync();
        }

    }
}
