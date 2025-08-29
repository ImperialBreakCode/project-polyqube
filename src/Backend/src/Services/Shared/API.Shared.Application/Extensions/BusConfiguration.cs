using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace API.Shared.Application.Extensions
{
    public static class BusConfiguration
    {
        public static void ConfigureSagaStateMachine<TMachine, TMachineData, TDbContext>(this IBusRegistrationConfigurator cfg)
            where TMachineData : class, SagaStateMachineInstance
            where TMachine : MassTransitStateMachine<TMachineData>
            where TDbContext : DbContext
        {
            cfg.AddSagaStateMachine<TMachine, TMachineData>()
                .EntityFrameworkRepository(r =>
                {
                    r.ConcurrencyMode = ConcurrencyMode.Pessimistic;

                    r.ExistingDbContext<TDbContext>();
                    r.UseSqlServer();
                });
        }

        public static void AddTransactionalOutbox<TDbContext>(this IBusRegistrationConfigurator cfg)
            where TDbContext : DbContext
        {
            cfg.AddEntityFrameworkOutbox<TDbContext>(outbox =>
            {
                outbox.QueryDelay = TimeSpan.FromSeconds(5);

                outbox.UseBusOutbox();
                outbox.UseSqlServer();

                outbox.DuplicateDetectionWindow = TimeSpan.FromMinutes(10);
            });

            cfg.AddConfigureEndpointsCallback((context, name, config) =>
            {
                config.UseEntityFrameworkOutbox<TDbContext>(context);
            });
        }
    }
}
