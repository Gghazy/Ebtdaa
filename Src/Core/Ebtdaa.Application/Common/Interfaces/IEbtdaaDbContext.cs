﻿using Ebtdaa.Domain.ActualProduction.Entity;
using Ebtdaa.Domain.CustomsItem.CustomsItemLevel.Entity;
using Ebtdaa.Domain.CustomsItemUpdateData.Entity;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.Integration;
using Ebtdaa.Domain.ProductData.Entity;
using Ebtdaa.Domain.RawMaterials.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<CustomsItemLevel> CustomsItemLevels { get; set; }
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
        public DbSet<FactoryProduct> FactoryProducts { get; set; }
        public DbSet<Period> Periods { get; set; }
    }
}
