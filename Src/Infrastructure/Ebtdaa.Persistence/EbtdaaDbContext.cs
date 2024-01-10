using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Domain.ActualRawMaterials.Entity;
using Ebtdaa.Domain.Factories.Entity;
using Ebtdaa.Domain.General;
using Ebtdaa.Domain.RawMaterials.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Persistence
{
    public class EbtdaaDbContext:DbContext, IEbtdaaDbContext
    {
        public EbtdaaDbContext(DbContextOptions<EbtdaaDbContext> options) : base(options)
        {
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
        public DbSet<ActualRawMaterial> ActualRawMaterials { get; set; }
        public Task<int> SaveChangesAsync()
        {
          return  base.SaveChangesAsync();
        }

    }
}
