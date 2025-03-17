using API.Accounts.Common.Features.Users.EmailExceptions;
using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Accounts.Domain.Repositories;

namespace API.Accounts.Domain.DomainServices
{
    public class UserDomainService
    {
        public void ChangeUsername(string newUsername, User user, IUserRepository userRepository)
        {
            if (userRepository.GetUserByUsername(newUsername) is not null)
            {
                throw new UsernameAlreadyExistsException();
            }

            user.Username = newUsername;
        }

        public void AddEmailToUser(string email, User user, IUserRepository userRepository)
        {
            if (userRepository.GetUserByEmail(email) is not null)
            {
                throw new EmailAlreadyExists();
            }

            user.AddEmail(UserEmail.Create(email));
        }
    }
}
