using API.Accounts.Application.Features.Roles.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Roles.Queries.GetRoleByName;

public record GetRoleByNameQuery(string RoleName) : IQuery<RoleQueryViewModel>;
