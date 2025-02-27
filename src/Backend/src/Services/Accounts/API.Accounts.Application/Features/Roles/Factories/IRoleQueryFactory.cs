using API.Accounts.Application.Features.Roles.Queries.GetAllRoles;

namespace API.Accounts.Application.Features.Roles.Factories
{
    public interface IRoleQueryFactory
    {
        GetAllRolesQuery CreateGetAllRolesQuery();
    }
}
