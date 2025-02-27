using API.Accounts.Application.Features.Roles.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Roles.Queries.GetAllRoles
{
    public record GetAllRolesQuery() : IQuery<ICollection<RoleQueryViewModel>>;
}
