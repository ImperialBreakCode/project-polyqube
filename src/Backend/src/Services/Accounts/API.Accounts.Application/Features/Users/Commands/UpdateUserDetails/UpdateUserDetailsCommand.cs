using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.UpdateUserDetails
{
    public record UpdateUserDetailsCommand(
        string UserId, 
        string FirstName, 
        string LastName,
        DateOnly BirthDate,
        GenderEnum Gender) : ICommand;
}
