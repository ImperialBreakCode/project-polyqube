using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Commands.CreateUserDetails
{
    internal class CreateUserDetailsCommandHandler : ICommandHandler<CreateUserDetailsCommand, UserViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserDetailsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<UserViewModel> Handle(CreateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.UserRepository.GetById(request.UserId);
            if (user is null || user.DeletedAt is not null)
            {
                throw new UserNotFoundException();
            }

            if (user.UserDetails is not null)
            {
                throw new UserDetailsAlreadyExistException();
            }

            user.UserDetails = UserDetails.Create(request.FirstName, request.LastName, request.BirthDate, request.Gender);

            _unitOfWork.Save();

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return Task.FromResult(userViewModel);
        }
    }
}
