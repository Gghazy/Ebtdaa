using Ebtdaa.Application.Common.Interfaces;
using Ebtdaa.Domain.Integration;
using Microsoft.EntityFrameworkCore;


namespace Ebtdaa.Infrastructure
{
    public class IntgrationDbContext : DbContext, IIntgrationDbContext
    {
        public IntgrationDbContext(DbContextOptions<IntgrationDbContext> options) : base(options)
        {
        }

        public DbSet<FactoryIntegration> FactoryIntegrations { get; set; }
        public DbSet<ProductIntegration> ProductIntegrations { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
