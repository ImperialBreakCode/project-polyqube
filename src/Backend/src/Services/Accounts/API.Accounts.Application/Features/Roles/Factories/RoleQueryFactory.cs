using API.Accounts.Application.Features.Roles.Queries.GetAllRoles;

namespace API.Accounts.Application.Features.Roles.Factories
{
    internal class RoleQueryFactory : IRoleQueryFactory
    {
        public GetAllRolesQuery CreateGetAllRolesQuery()
        {
            return new GetAllRolesQuery();
        }
    }
}
