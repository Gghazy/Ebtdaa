using Ebtdaa.Domain.Integration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.Common.Interfaces
{
    public interface IIntgrationDbContext
    {

        public DbSet<FactoryIntegration> FactoryIntegrations { get; set; }
        public DbSet<ProductIntegration> ProductIntegrations { get; set; }

        Task<int> SaveChangesAsync();
    }
}
