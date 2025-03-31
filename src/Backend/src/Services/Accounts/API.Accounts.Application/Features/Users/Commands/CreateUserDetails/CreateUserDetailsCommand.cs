using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.CreateUserDetails
{
    public record CreateUserDetailsCommand(
        string UserId,
        string FirstName, 
        string LastName, 
        DateOnly BirthDate, 
        GenderEnum Gender) : ICommand<UserViewModel>;
}
