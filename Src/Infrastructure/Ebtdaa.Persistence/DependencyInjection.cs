using Ebtdaa.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<EbtdaaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                        b => b.MigrationsAssembly(typeof(EbtdaaDbContext).Assembly.FullName));
            });
            services.AddScoped<IEbtdaaDbContext>(provider => provider.GetService<EbtdaaDbContext>());
        }
    }
}
