using Ebtdaa.Application.FactoryJobs.Handlers;
using Ebtdaa.Application.FactoryJobs.Interfaces;
using Ebtdaa.Application.ProductJobs.Interfaces;
using Ebtdaa.Application.UnitJobs.Handlers;
using Ebtdaa.Application.UnitJobs.Interfaces;
using Quartz;

namespace Ebtdaa.WebApi.Jobs
{
    [DisallowConcurrentExecution]
    public class FactoryBackgroundJob : IJob
    {
        private readonly IFactoryJobService _factoryJobService;
        private readonly IProductJobServie _productJobServie;
        private readonly IUnitJobService _unitJobService;
        public FactoryBackgroundJob(IFactoryJobService factoryJobService, IProductJobServie productJobServie , IUnitJobService unitJobService)
        {
            _factoryJobService = factoryJobService;
            _productJobServie = productJobServie;
            _unitJobService = unitJobService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                await _factoryJobService.FactoryIntegrat();
                await _unitJobService.UnitIntegrat();
                await _productJobServie.ProductIntegrat();
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }
    }
}
