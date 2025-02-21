using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Accounts.Domain.Exceptions.EmailExceptions;
using API.Accounts.Domain.Exceptions.RoleExceptions;
using API.Accounts.Domain.Exceptions.UserExceptions;
using API.Accounts.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace API.Accounts.Infrastructure.Features.Users
{
    internal class UserRepository : SoftDeleteRepository<User>, IUserRepository
    {
        private readonly AccountsDbContext _context;

        public UserRepository(AccountsDbContext context) : base(context.Users)
        {
            _context = context;
        }

        public User? GetUserByEmail(string email, bool isDeleted = default)
        {
            if (isDeleted)
            {
                return DbSet.FirstOrDefault(x => x.Emails.Any(em => em.Email == email));
            }

            return DbSet.FirstOrDefault(x => x.Emails.Any(em => em.Email == email) && x.DeletedAt == null);
        }

        public User? GetUserByUsername(string username, bool isDeleted = default)
        {
            if (isDeleted)
            {
                return DbSet.FirstOrDefault(x => x.Username == username);
            }

            return DbSet.FirstOrDefault(x => x.Username == username && x.DeletedAt == null);
        }

        public override void Insert(User entity)
        {
            if (entity.Emails.Count == 0)
            {
                throw new LowEmailAmountException();
            }

            foreach (var email in entity.Emails)
            {
                if (DbSet.Any(u => u.Emails.Any(em => em.Email == email.Email)))
                {
                    throw new EmailAlreadyExists();
                }
            }

            if (GetUserByUsername(entity.Username, true) is not null)
            {
                throw new UsernameAlreadyExists();
            }

            base.Insert(entity);
        }

        public ICollection<UserRole> GetUserRoles(string userId)
        {
            return _context.UserRoles
                .Include(ur => ur.Role)
                .Where(ur => ur.UserId == userId)
                .AsNoTracking()
                .ToList();
        }

        public void RemoveUserRole(UserRole userRole)
        {
            if (DbSet.Any(x => x.Id == userRole.UserId && x.DeletedAt != null))
            {
                throw new CannotModifySoftDeletedUserException();
            }

            _context.UserRoles.Remove(userRole);
        }

        public void AddUserRole(string userId, string roleId)
        {
            if (DbSet.Any(x => x.Id == userId && x.DeletedAt != null))
            {
                throw new CannotModifySoftDeletedUserException();
            }

            if (_context.UserRoles.Any(x => x.RoleId == roleId && x.UserId == userId))
            {
                throw new RoleAlreadyAssignedException();
            }

            _context.UserRoles.Add(UserRole.Create(userId, roleId));
        }
    }
}
