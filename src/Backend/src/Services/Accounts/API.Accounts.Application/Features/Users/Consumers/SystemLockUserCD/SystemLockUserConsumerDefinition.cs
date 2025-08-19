using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers.SystemLockUserCD
{
    public class SystemLockUserConsumerDefinition : ConsumerDefinition<SystemLockUserConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<SystemLockUserConsumer> consumerConfigurator, IRegistrationContext context)
        {
            endpointConfigurator.UseMessageRetry(r => r.Interval(3, 2000));
        }
    }
}
