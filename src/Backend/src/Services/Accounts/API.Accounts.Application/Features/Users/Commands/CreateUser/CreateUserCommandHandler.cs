using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Application.Features.Users.PasswordManager;
using API.Accounts.Common.Features.Roles.Exceptions;
using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Application.Interfaces;
using API.Shared.Common.Constants;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Commands.CreateUser
{
    internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, UserViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordManager _passwordManager;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IPasswordManager passwordManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _passwordManager = passwordManager;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _passwordManager.HashPassword(request.Password);
            var user = User.Create(request.Username, passwordHash, request.Email);

            Role? userRole = await _unitOfWork.RoleRepository.GetByNameAsync(AccountRoleNames.USER_ROLE, cancellationToken);

            if (userRole is null)
            {
                throw new RoleNotFoundException();
            }

            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.UserRepository.AddUserRole(user.Id, userRole.Id);
            _unitOfWork.Save();

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }
    }
}
