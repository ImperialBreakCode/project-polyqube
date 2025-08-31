using API.Shared.Infrastructure.Jobs;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace API.Shared.Infrastructure.Extensions
{
    public static class QuartzExtensions
    {
        public static void AddInternalOutboxProcessorJob<TDbContext>(this IServiceCollectionQuartzConfigurator configurator)
            where TDbContext : DbContext
        {
            var jobKey = JobKey.Create("ProccessInternalOutbox");

            configurator.AddJob<ProcessInternalOutboxJob<TDbContext>>(jobKey)
                .AddTrigger(trigger
                    => trigger
                        .ForJob(jobKey)
                        .StartAt(DateBuilder.FutureDate(25, IntervalUnit.Second))
                        .WithSimpleSchedule(s => s.WithIntervalInSeconds(10).RepeatForever()));
        }
    }
}
