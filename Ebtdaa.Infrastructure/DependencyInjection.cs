using Ebtdaa.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ebtdaa.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IntgrationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("IntgrationConnection"),
                                        b => b.MigrationsAssembly(typeof(IntgrationDbContext).Assembly.FullName));
            });
            services.AddScoped<IIntgrationDbContext>(provider => provider.GetService<IntgrationDbContext>());

        }
    }
}
