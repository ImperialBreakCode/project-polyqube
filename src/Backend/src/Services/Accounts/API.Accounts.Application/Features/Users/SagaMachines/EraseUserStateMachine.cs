using API.Accounts.Domain.SagaMachineDatas;
using API.Shared.Application.Contracts.Accounts.Commands;
using API.Shared.Application.Contracts.Accounts.Events;
using API.Shared.Application.Contracts.Accounts.Requests;
using API.Shared.Application.Contracts.Accounts.Responses;
using API.Shared.Application.Contracts.FeatureInfos.Commands;
using API.Shared.Application.Contracts.FeatureInfos.Events;
using MassTransit;

namespace API.Accounts.Application.Features.Users.SagaMachines
{
    internal class EraseUserStateMachine : MassTransitStateMachine<EraseUserSagaData>
    {
        // states
        public State DeletingUser { get; private set; }
        public State RemovingUserFormFeatureInfos { get; private set; }
        public State Failed { get; private set; }
        public State Completed { get; private set; }

        // requests
        public Request<EraseUserSagaData, SystemLockUserRequest, UserSystemLockedResponse> SystemLockRequest { get; private set; } = null!;
        public Request<EraseUserSagaData, RevokeUserSessionsRequest, UserSessionsRevokedResponse> RevokeSessions { get; private set; } = null!;

        // events
        public Event<UserDeletionInitiatedEvent> DeletionInitiated { get; private set; }
        public Event<UserRemovedFromFeatureInfosEvent> RemovedFromFeatureInfos { get; private set; }
        public Event<UserErasedEvent> UserErased { get; private set; }

        public EraseUserStateMachine()
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

            #endregion

            #region Events

            Event(() => DeletionInitiated, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.UserId);
                x.SelectId(x => Guid.NewGuid());
            });

            Event(() => RemovedFromFeatureInfos, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.UserId);
            });

            Event(() => UserErased, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.UserId);
            });

            #endregion

            Initially(
                When(DeletionInitiated)
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
                    .Finalize());

            During(RevokeSessions.Pending,
                When(RevokeSessions.Completed)
                    .TransitionTo(RemovingUserFormFeatureInfos)
                    .Publish(x => new RemoveUserFromFeatureInfos(x.Saga.UserId)));

            During(RemovingUserFormFeatureInfos,
                When(RemovedFromFeatureInfos)
                    .TransitionTo(DeletingUser)
                    .Publish(x => new EraseUser(x.Saga.UserId)));

            During(DeletingUser,
                When(UserErased)
                    .TransitionTo(Completed)
                    .Publish(x => new UserDeletionCompletedEvent(x.Saga.Email))
                    .Finalize());
        }
    }
}
