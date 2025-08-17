using API.Accounts.Domain.SagaMachineDatas.UserSoftDelete;
using API.Shared.Application.Contracts.Accounts.Commands;
using API.Shared.Application.Contracts.Accounts.Events;
using MassTransit;

namespace API.Accounts.Application.Features.Users.SagaMachines.UserSoftDeleteMachine
{
    public class UserSoftDeletionMachine : MassTransitStateMachine<UserSoftDeleteSagaData>
    {
        // states
        public State LockingUser { get; private set; }
        public State RevokingSessions { get; private set; }
        public State MarkingUserForDeletion { get; private set; }
        public State UnlockingUser { get; private set; }
        public State Completed { get; private set; }

        // events
        public Event<UserSoftDeletionInitiatedEvent> SoftDeletionInitiated { get; private set; }
        public Event<UserSystemLockedEvent> SystemLocked { get; private set; }
        public Event<UserSessionsRevokedEvent> SessionsRevoked { get; private set; }
        public Event<UserMarkedForDeletionEvent> MarkedForDeletion { get; private set; }
        public Event<UserSystemLockReleasedEvent> SystemUnlocked { get; private set; }
        public Event<UserSoftDeletedEvent> SoftDeleted { get; private set; }

        public UserSoftDeletionMachine()
        {
            SetCompletedWhenFinalized();

            InstanceState(x => x.CurrentState);

            #region Events

            Event(() => SoftDeletionInitiated, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.UserId);
                x.SelectId(x => Guid.NewGuid());
            });

            Event(() => SystemLocked, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.UserId);
            });

            Event(() => SessionsRevoked, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.UserId);
            });

            Event(() => MarkedForDeletion, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.UserId);
            });

            Event(() => SystemUnlocked, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.UserId);
            });

            Event(() => SoftDeleted, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.UserId);
            });

            #endregion

            Initially(
                When(SoftDeletionInitiated)
                    .TransitionTo(LockingUser)
                    .Then(x =>
                    {
                        x.Send<SystemLockUser>(new(x.Saga.UserId));
                    }));


            During(LockingUser,
                When(SystemLocked)
                    .TransitionTo(RevokingSessions)
                    .Then(x =>
                    {
                        x.Send<RevokeUserSessions>(new(x.Saga.UserId));
                    }));

            During(RevokingSessions,
                When(SessionsRevoked)
                    .TransitionTo(MarkingUserForDeletion)
                    .Then(x =>
                    {
                        x.Send<MarkUserForDeletion>(new(x.Saga.UserId));
                    }));

            During(MarkingUserForDeletion,
                When(MarkedForDeletion)
                    .TransitionTo(UnlockingUser)
                    .Then(x =>
                    {
                        x.Send<ReleaseUserSystemLock>(new(x.Saga.UserId));
                    }));

            During(UnlockingUser, 
                When(SystemUnlocked)
                    .Then(x =>
                    {
                        x.Publish<UserSoftDeletedEvent>(new(x.Saga.UserId, x.Saga.Email));
                    })
                    .TransitionTo(Completed)
                    .Finalize());
        }
    }
}
