using Ebtdaa.Application.FactoryJobs.Handlers;
using Ebtdaa.Application.FactoryJobs.Interfaces;
using Quartz;

namespace Ebtdaa.WebApi.Jobs
{
    [DisallowConcurrentExecution]
    public class FactoryBackgroundJob : IJob
    {
        private readonly IFactoryJobService _factoryJobService;
        public FactoryBackgroundJob(IFactoryJobService factoryJobService)
        {
            _factoryJobService = factoryJobService;
        }
        public async Task Execute(IJobExecutionContext context)
        {

          await  _factoryJobService.FactoryIntegrat();
        }
    }
}
