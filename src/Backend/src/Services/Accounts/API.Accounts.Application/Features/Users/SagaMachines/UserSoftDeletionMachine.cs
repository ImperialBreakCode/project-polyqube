using API.Accounts.Domain.SagaMachineDatas;
using API.Shared.Application.Contracts.Accounts.Commands;
using API.Shared.Application.Contracts.Accounts.Events;
using API.Shared.Application.Contracts.Accounts.Requests;
using API.Shared.Application.Contracts.Accounts.Responses;
using MassTransit;

namespace API.Accounts.Application.Features.Users.SagaMachines.UserSoftDeleteMachine
{
    public class UserSoftDeletionMachine : MassTransitStateMachine<UserSoftDeleteSagaData>
    {
        // states
        public State MarkingUserForDeletion { get; private set; }
        public State Completed { get; private set; }
        public State Failed { get; private set; }

        // requests
        public Request<UserSoftDeleteSagaData, SystemLockUserRequest, UserSystemLockedResponse> SystemLockRequest { get; private set; } = null!;
        public Request<UserSoftDeleteSagaData, RevokeUserSessionsRequest, UserSessionsRevokedResponse> RevokeSessions { get; private set; } = null!;
        public Request<UserSoftDeleteSagaData, ReleaseUserSystemLockRequest, UserSystemLockReleasedResponse> UnlockSystemUser { get; private set; } = null!;


        // events
        public Event<UserSoftDeletionInitiatedEvent> SoftDeletionInitiated { get; private set; }
        public Event<UserMarkedForDeletionEvent> MarkedForDeletion { get; private set; }

        public UserSoftDeletionMachine()
        {
            SetCompletedWhenFinalized();

            InstanceState(x => x.CurrentState);

            #region Requests

            Request(() => SystemLockRequest, x =>
            {
                x.Timeout = TimeSpan.Zero;
            });

            Request(() => RevokeSessions, x =>
            {
                x.Timeout = TimeSpan.Zero;
            });

            Request(() => UnlockSystemUser, x =>
            {
                x.Timeout = TimeSpan.Zero;
            });

            #endregion

            #region Events

            Event(() => SoftDeletionInitiated, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.UserId);
                x.SelectId(x => Guid.NewGuid());
            });

            Event(() => MarkedForDeletion, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.UserId);
            });

            #endregion

            Initially(
                When(SoftDeletionInitiated)
                    .Then(x =>
                    {
                        x.Saga.UserId = x.Message.UserId;
                        x.Saga.Email = x.Message.Email;
                    })
                    .Request(SystemLockRequest, x => SystemLockUserRequest.Create(x.Saga.UserId))
                    .TransitionTo(SystemLockRequest.Pending));

            During(SystemLockRequest.Pending,
                When(SystemLockRequest.Completed)
                    .Request(RevokeSessions, x => RevokeUserSessionsRequest.Create(x.Saga.UserId))
                    .TransitionTo(RevokeSessions.Pending),
                When(SystemLockRequest.Faulted)
                    .TransitionTo(Failed)
                    .Publish(x => new UserSoftDeletionFailedEvent(x.Saga.UserId, x.Saga.Email))
                    .Finalize());

            During(RevokeSessions.Pending,
                When(RevokeSessions.Completed)
                    .TransitionTo(MarkingUserForDeletion)
                    .Publish(x => new MarkUserForDeletion(x.Saga.UserId)));

            During(MarkingUserForDeletion,
                When(MarkedForDeletion)
                    .Request(UnlockSystemUser, x => ReleaseUserSystemLockRequest.Create(x.Saga.UserId))
                    .TransitionTo(UnlockSystemUser.Pending));

            During(UnlockSystemUser.Pending, 
                When(UnlockSystemUser.Completed)
                    .TransitionTo(Completed)
                    .Publish(x => new UserSoftDeletedEvent(x.Saga.UserId, x.Saga.Email))
                    .Finalize());
        }
    }
}
