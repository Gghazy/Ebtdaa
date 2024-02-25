using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.CustomsItemUpdateData.Entity;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.ProductData.Entity;
using Ebtdaa.Domain.RawMaterials.Entity;
using Microsoft.EntityFrameworkCore;
using Ebtdaa.Domain.Inspectors.Entity;
using Ebtdaa.Domain.InspectorRawMaterials.Entity;
using Ebtdaa.Domain.Periods;

namespace Ebtdaa.Application.Common.Interfaces
{
    public interface IEbtdaaDbContext
    {
        Task<int> SaveChangesAsync();

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
        public DbSet<CustomsItemUpdate> CustomsItemUpdates { get; set; }
        public DbSet<ActualProductionAndCapacity> ActualProductionAndCapacities { get; set; }
        public DbSet<ReasonIncreasCapacity> ReasonIncreasCapacities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<ActualProductionAttachment> ActualProductionAttachments { get; set; }
        public DbSet<ProductAttachment> ProductAttachments { get; set; }
        public DbSet<ActualRawMaterial> ActualRawMaterials { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<RawMaterialAttachment> RawMaterialAttachments { get; set; }
        public DbSet<ActualRawMaterialFile> ActualRawMaterialFiles { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<IncreaseActualProduction> IncreaseActualProductions { get; set; }
        public DbSet<Reason> Reasons { get; set; }
        public DbSet<Inspector> Inspectors { get; set; }
        public DbSet<InspectorFactory> InspectorFactories { get; set; }
        public DbSet<ProductRawMaterial> ProductRawMaterials { get; set; }
        public DbSet<InspectorRawMaterial> InspectorRawMaterials { get; set; }
        public DbSet<BaiscFactoryInfo> BasicFactoryInfos {  get; set; } 
    }
}
