using API.FileStorage.Application.Features.MongoBusData.Jobs;
using API.FileStorage.Application.Features.ProfilePicture;
using API.FileStorage.Application.Helpers;
using API.Shared.Application.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace API.FileStorage.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddFilesApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var currentAssembly = typeof(Features.Accounts.Consumers.SaveProfilePictureConsumer).Assembly;

            services
                .AddMassTransitRabbitMq(configuration, currentAssembly)
                .AddQuartzCronJobs(cfg =>
                {
                    var jobKey = JobKey.Create("CleanMongoMessageData");

                    cfg.AddJob<MongoMessageDataCleanerJob>(jobKey)
                        .AddTrigger(trigger
                            => trigger
                                .ForJob(jobKey)
                                .StartAt(DateBuilder.FutureDate(20, IntervalUnit.Second))
                                .WithSimpleSchedule(s => s.WithIntervalInSeconds(30).RepeatForever()));
                });

            services.AddTransient<IObjectUrlGenerator, ObjectUrlGenerator>();
            services.AddTransient<IProfileImageResizer, ProfileImageResizer>();

            return services;
        }
    }
}
