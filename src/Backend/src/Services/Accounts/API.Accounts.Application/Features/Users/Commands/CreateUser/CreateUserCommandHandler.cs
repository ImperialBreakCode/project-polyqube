using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Application.Features.Users.PasswordManager;
using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Application.Interfaces;
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

        public Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _passwordManager.HashPassword(request.Password);
            var user = User.Create(request.Username, passwordHash, request.Email);

            _unitOfWork.UserRepository.Insert(user);

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return Task.FromResult(userViewModel);
        }
    }
}
