﻿using API.Accounts.Common.Features.Roles.Exceptions;
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

        public async Task<Role?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await SetGetByNameQuery(name).FirstOrDefaultAsync(cancellationToken);
        }

        public Role? GetByName(string name)
        {
            return SetGetByNameQuery(name).FirstOrDefault();
        }

        public async Task<ICollection<UserRole>> GetUserRolesAsync(string roleId, int startPosition, int amount, CancellationToken cancellationToken = default)
        {
            return await _context.UserRoles
                .Where(ur => ur.RoleId == roleId)
                .Skip(startPosition)
                .Take(amount)
                .Include(ur => ur.User)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<ICollection<UserRole>> GetActiveUserRolesAsync(string roleId, int startPosition, int amount, CancellationToken cancellationToken = default)
        {
            return await _context.UserRoles
                .Where(ur => ur.RoleId == roleId && ur.User.DeletedAt == null)
                .Skip(startPosition)
                .Take(amount)
                .Include(ur => ur.User)
                .ToListAsync(cancellationToken);
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

        public async Task<ICollection<Role>> GetAllRolesAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        private IQueryable<Role> SetGetByNameQuery(string name)
        {
            return DbSet
                .Where(x => x.RoleName == name)
                .AsNoTracking();
        }
    }
}
