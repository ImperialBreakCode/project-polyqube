using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Domain;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Queries.GetUserById
{
    internal class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = unitOfWork.UserRepository;
            _mapper = mapper;
        }

        public Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetActiveEntityById(request.Id);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return Task.FromResult(userViewModel);
        }
    }
}
