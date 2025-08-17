using MassTransit;

namespace API.Accounts.Domain.SagaMachineDatas.UserSoftDelete
{
    public class UserSoftDeleteSagaData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
    }
}
