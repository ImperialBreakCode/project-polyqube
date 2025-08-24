using API.Accounts.Domain.SagaMachineDatas;
using API.Shared.Application.Contracts.Accounts.Requests;
using API.Shared.Application.Contracts.Accounts.Responses;
using MassTransit;

namespace API.Accounts.Application.Features.Users.SagaMachines
{
    internal class EraseUserStateMachine : MassTransitStateMachine<EraseUserSagaData>
    {
        // states
        public State DeletingUser { get; private set; }
        public State Failed { get; private set; }
        public State Completed { get; private set; }

        // requests
        public Request<EraseUserSagaData, SystemLockUserRequest, UserSystemLockedResponse> SystemLockRequest { get; private set; } = null!;
        public Request<EraseUserSagaData, RevokeUserSessionsRequest, UserSessionsRevokedResponse> RevokeSessions { get; private set; } = null!;
    }
}
