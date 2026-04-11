using API.Chats.Application.Features.UserProfiles.Models;
using API.Chats.Domain;
using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Chats.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    internal class CreateUserProfileCommandHandler : ICommandHandler<CreateUserProfileCommand, UserProfileViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserProfileCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<UserProfileViewModel> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            // check admin if user can create account

            _unitOfWork.UserProfileRepository.Insert(UserProfile.Create(request.UserId));

            return Task.FromResult(_mapper.Map<UserProfileViewModel>(UserProfile.Create(request.UserId)));
        }
    }
}
