using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Accounts.Domain.Exceptions.EmailExceptions;
using API.Accounts.Domain.Exceptions.UserExceptions;
using API.Accounts.Domain.Repositories;

namespace API.Accounts.Domain.DomainServices
{
    public class UserDomainService
    {
        public void ChangeUsername(string newUsername, User user, IUserRepository userRepository)
        {
            if (userRepository.GetUserByUsername(newUsername) is not null)
            {
                throw new UsernameAlreadyExists();
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
