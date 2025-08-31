using API.Accounts.Common.Features.Users.EmailExceptions;
using API.Accounts.Domain.Aggregates.UserAggregate.DomainEvents;
using API.Shared.Domain.Base;

namespace API.Accounts.Domain.Aggregates.UserAggregate
{
    public class User : AuditableSoftDeleteAggregateRoot
    {
        private readonly ICollection<UserEmail> _emails;

        private User(string username, string passwordHash)
        {
            _emails = new List<UserEmail>();
            Username = username;
            PasswordHash = passwordHash;

            RaiseDomainEvent(new UserCreatedDomainEvent(Id));
        }

        public string Username { get; internal set; }
        public string PasswordHash { get; set; }
        public bool LockedOut { get; set; }
        public bool SystemLock { get; set; }
        public bool Disabled { get; set; }
        public bool Suspended { get; set; }

        public IReadOnlyCollection<UserEmail> Emails => 
            _emails
            .Select(x => x.Clone())
            .ToList();

        public UserDetails? UserDetails { get; set; }

        public static User Create(string username, string passwordHash, string email)
        {
            var user = new User(username, passwordHash);
            user.AddEmail(UserEmail.Create(email));

            return user;
        }

        public void SetDisabled(bool disabled)
        {
            Disabled = disabled;
        }

        internal void AddEmail(UserEmail email)
        {
            if (_emails.Any(x => x.Email == email.Email))
            {
                throw new EmailAlreadyAddedException();
            }

            if (_emails.Count == 0)
            {
                email.IsPrimary = true;
            }

            _emails.Add(email);
        }

        public void RemoveEmail(string email)
        {

            if (_emails.Count == 1)
            {
                throw new CannotRemoveEmailException();
            }

            var userEmail = _emails.FirstOrDefault(e => e.Email == email);
            if (userEmail is not null)
            {
                _emails.Remove(userEmail);

                if (userEmail.IsPrimary)
                {
                    _emails.First().IsPrimary = true;
                }
            }
        }

        public void SetPrimaryEmail(string email)
        {
            var userEmail = _emails.FirstOrDefault(x => x.Email == email);

            if (userEmail is not null)
            {
                var oldPrimaryEmail = _emails.Where(x => x.IsPrimary == true).First();
                oldPrimaryEmail.IsPrimary = false;

                userEmail.IsPrimary = true;
            }
        }

        public void VerifyEmail(string email)
        {
            var userEmail = _emails.FirstOrDefault(x => x.Email == email);

            if (userEmail is not null)
            {
                userEmail.IsVerified = true;
            }
        }
    }
}
