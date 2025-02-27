using API.Accounts.Common.Features.Roles.Exceptions;
using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Accounts.Infrastructure.Features.Roles
{
    internal class RoleRepository : InsertReadRepository<Role>, IRoleRepository
    {
        private readonly AccountsDbContext _context;

        public RoleRepository(AccountsDbContext context) : base(context.Roles)
        {
            _context = context;
        }

        public Role? GetByName(string name)
        {
            return DbSet.Where(x => x.RoleName == name).AsNoTracking().FirstOrDefault();
        }

        public ICollection<UserRole> GetUserRoles(string roleId, int startPosition, int amount)
        {
            return SetUserRoleQuery(startPosition, amount)
                .AsNoTracking()
                .Where(ur => ur.RoleId == roleId)
                .ToList();
        }

        public ICollection<UserRole> GetActiveUserRoles(string roleId, int startPosition, int amount)
        {
            return SetUserRoleQuery(startPosition, amount)
                .Where(ur => ur.RoleId == roleId && ur.User.DeletedAt == null)
                .ToList();
        }

        public override Role? GetById(string id)
        {
            return DbSet.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
        }

        public override void Insert(Role entity)
        {
            if (GetByName(entity.RoleName) is not null)
            {
                throw new RoleAlreadyExistsException();
            }

            base.Insert(entity);
        }


        private IQueryable<UserRole> SetUserRoleQuery(int startPosition, int amount)
        {
            return _context.UserRoles
                .Include(ur => ur.User)
                .Skip(startPosition)
                .Take(amount);
        }

        public async Task<ICollection<Role>> GetAllRolesAsync()
        {
            return await DbSet
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
