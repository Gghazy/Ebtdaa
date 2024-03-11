using Ebtdaa.Application.Attachments.Handler;
using Ebtdaa.Application.Attachments.Interfaces;
using Ebtdaa.Application.Attachments.Validation;
using Ebtdaa.Application.Factories.Handlers;
using Ebtdaa.Application.Factories.Interfaces;
using Ebtdaa.Application.Factories.Validation;
using Ebtdaa.Application.FactoryContacts.Handlers;
using Ebtdaa.Application.FactoryContacts.Interfaces;
using Ebtdaa.Application.FactoryContacts.Validation;
using Ebtdaa.Application.FactoryFinancials.Handlers;
using Ebtdaa.Application.FactoryFinancials.Interfaces;
using Ebtdaa.Application.FactoryFinancials.Validation;
using Ebtdaa.Application.FactoryLocations.Handlers;
using Ebtdaa.Application.FactoryLocations.Interfaces;
using Ebtdaa.Application.FactoryLocations.Validation;
using Quartz;

namespace Ebtdaa.WebApi.Jobs
{
    public static class JobsConfiguration
    {
        public static void AddJobsConfiguration(this IServiceCollection services)
        {
            #region Quartz Jobs

            services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();

                var factoryJobKey = JobKey.Create(nameof(FactoryBackgroundJob));

                options.AddJob<FactoryBackgroundJob>(factoryJobKey)
                        .AddTrigger(trigger =>
                        trigger.ForJob(factoryJobKey)
                               .WithSimpleSchedule(schedule => schedule.WithIntervalInHours(6).RepeatForever()));
            });

            services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
            #endregion
        }
    }
}
