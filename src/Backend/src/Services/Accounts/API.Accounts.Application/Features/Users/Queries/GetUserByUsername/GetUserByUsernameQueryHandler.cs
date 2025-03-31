using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Domain;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Queries.GetUserByUsername
{
    internal class GetUserByUsernameQueryHandler : IQueryHandler<GetUserByUsernameQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByUsernameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = unitOfWork.UserRepository;
            _mapper = mapper;
        }

        public Task<UserViewModel> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetUserByUsername(request.Username);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return Task.FromResult(userViewModel);
        }
    }
}
