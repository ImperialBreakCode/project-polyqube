using API.Accounts.Application.Features.Roles.Queries.GetAllRoles;
using API.Accounts.Application.Features.Roles.Queries.GetRoleByName;

namespace API.Accounts.Application.Features.Roles.Factories
{
    internal class RoleQueryFactory : IRoleQueryFactory
    {
        public GetAllRolesQuery CreateGetAllRolesQuery()
        {
            return new GetAllRolesQuery();
        }

        public GetRoleByNameQuery CreateGetRoleByNameQuery(string roleName)
        {
            return new GetRoleByNameQuery(roleName);
        }
    }
}
