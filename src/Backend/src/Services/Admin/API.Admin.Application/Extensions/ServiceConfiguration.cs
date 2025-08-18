using API.Admin.Application.DatabaseInit;
using API.Admin.Application.Features.Emails.EmailMessageGenerator;
using API.Admin.Application.Features.Emails.EmailSenders;
using API.Admin.Application.Features.Emails.Options;
using API.Admin.Application.Features.FeatureInfos.Factories;
using API.Admin.Application.Features.FeatureInfos.Seeders;
using API.Admin.Application.Options;
using API.Admin.Infrastructure;
using API.Shared.Application.Extensions;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Admin.Application.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAdminApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddOptions<FrontendLinksOptions>()
                .BindConfiguration(nameof(FrontendLinksOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services
                .AddDatabaseSeeder<DatabaseSeeder>()
                .AddMapper()
                .AddMassTransitRabbitMq(configuration, typeof(ServiceConfiguration).Assembly, x =>
                {
                    x.AddTransactionalOutbox<AdminDbContext>();
                });

            services
                .AddFeatureInfos()
                .AddEmailService();

            return services;
        }

        private static IServiceCollection AddFeatureInfos(this IServiceCollection services)
        {
            services.AddTransient<IFeatureInfoSeeder, FeatureInfoSeeder>();
            services.AddTransient<IFeatureInfoQueryFactory, FeatureInfoQueryFactory>();

            return services;
        }

        private static IServiceCollection AddEmailService(this IServiceCollection services)
        {
            services
                .AddOptions<EmailSenderOptions>()
                .BindConfiguration(nameof(EmailSenderOptions))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IMailMessageGenerator, MailMessageGenerator>();

            return services;
        }
    }
}
