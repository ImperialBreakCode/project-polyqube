using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Commands.UpdateUserDetails
{
    internal class UpdateUserDetailsCommandHandler : ICommandHandler<UpdateUserDetailsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserDetailsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.UserRepository.GetById(request.UserId);
            if (user is null || user.DeletedAt is not null)
            {
                throw new UserNotFoundException();
            }

            user.UserDetails = _mapper.Map<UserDetails>(request);

            _unitOfWork.Save();

            return Task.CompletedTask;
        }
    }
}
