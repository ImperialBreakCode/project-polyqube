using API.Accounts.Application.Features.Roles.Queries.GetAllRoles;
using API.Accounts.Application.Features.Roles.Queries.GetRoleByName;

namespace API.Accounts.Application.Features.Roles.Factories
{
    public interface IRoleQueryFactory
    {
        GetAllRolesQuery CreateGetAllRolesQuery();
        GetRoleByNameQuery CreateGetRoleByNameQuery(string roleName);
    }
}
