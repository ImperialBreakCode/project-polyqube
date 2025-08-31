using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Domain;
using API.Shared.Application.Contracts.Base.Results;
using API.Shared.Application.Contracts.FileStorage.Requests;
using API.Shared.Application.Interfaces;
using API.Shared.Common.Exceptions;
using AutoMapper;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Commands.RemoveProfilePicture
{
    internal class RemoveProfilePictureCommandHandler : ICommandHandler<RemoveProfilePictureCommand>
    {
        private readonly IRequestClient<RemoveProfilePictureRequest> _requestClient;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProfilePictureCommandHandler(
            IRequestClient<RemoveProfilePictureRequest> requestClient, 
            IMapper mapper, 
            IUnitOfWork unitOfWork)
        {
            _requestClient = requestClient;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveProfilePictureCommand request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.UserRepository.GetActiveEntityById(request.UserId) ?? throw new UserNotFoundException();
            if (user.UserDetails is null)
            {
                throw new UserDetailsNotFoundException();
            }

            if (user.UserDetails.ProfilePicturePath is null)
            {
                return;
            }

            var busRequest = _mapper.Map<RemoveProfilePictureRequest>(user.UserDetails);
            var response = await _requestClient.GetResponse<BasicOperationResult>(busRequest, cancellationToken);

            if (!response.Message.Success)
            {
                throw new InternalServerError();
            }

            user.UserDetails.ProfilePicturePath = null;
            _unitOfWork.Save();
        }
    }
}
