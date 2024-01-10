using Ebtdaa.Application.FactoryJobs.Interfaces;
using Ebtdaa.Application.ProductJobs.Interfaces;
using Quartz;

namespace Ebtdaa.WebApi.Jobs
{
    [DisallowConcurrentExecution]
    public class ProductBackgroundJob : IJob
    {
        private readonly IProductJobServie _productJobServie;
        public ProductBackgroundJob(IProductJobServie productJobServie)
        {
            _productJobServie = productJobServie;
        }
        public async Task Execute(IJobExecutionContext context)
        {

            await _productJobServie.ProductIntegrat();
        }
    }
}
