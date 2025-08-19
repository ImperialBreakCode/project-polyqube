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
        
        public Event<Fault<SystemLockUser>> UserSoftDeletionFailed { get; private set; }

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

            Event(() => UserSoftDeletionFailed, x =>
            {
                x.CorrelateBy((saga, context) => saga.UserId == context.Message.Message.UserId);
            });

            #endregion

            Initially(
                When(SoftDeletionInitiated)
                    .Then(x =>
                    {
                        x.Saga.UserId = x.Message.UserId;
                        x.Saga.Email = x.Message.Email;
                    })
                    .TransitionTo(LockingUser)
                    .Publish(x => new SystemLockUser(x.Saga.UserId)));

            During(LockingUser,
                When(SystemLocked)
                    .TransitionTo(RevokingSessions)
                    .Publish(x => new RevokeUserSessions(x.Saga.UserId)),
                When(UserSoftDeletionFailed)
                    .TransitionTo(Completed)
                    .Publish(x => new UserSoftDeletionFailedEvent(x.Saga.UserId, x.Saga.Email))
                    .Finalize());

            During(RevokingSessions,
                When(SessionsRevoked)
                    .TransitionTo(MarkingUserForDeletion)
                    .Publish(x => new MarkUserForDeletion(x.Saga.UserId)));

            During(MarkingUserForDeletion,
                When(MarkedForDeletion)
                    .TransitionTo(UnlockingUser)
                    .Publish(x => new ReleaseUserSystemLock(x.Saga.UserId)));

            During(UnlockingUser, 
                When(SystemUnlocked)
                    .TransitionTo(Completed)
                    .Publish(x => new UserSoftDeletedEvent(x.Saga.UserId, x.Saga.Email))
                    .Finalize());
        }
    }
}
