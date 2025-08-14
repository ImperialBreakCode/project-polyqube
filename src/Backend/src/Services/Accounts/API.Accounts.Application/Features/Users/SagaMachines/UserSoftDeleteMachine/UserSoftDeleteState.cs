using MassTransit;

namespace API.Accounts.Application.Features.Users.SagaMachines.UserSoftDeleteMachine
{
    public class UserSoftDeleteState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
