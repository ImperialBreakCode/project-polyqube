using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Application.Contracts.FileStorage.Requests;
using API.Shared.Application.Contracts.FileStorage.Results;
using API.Shared.Application.Interfaces;
using API.Shared.Common.Exceptions;
using AutoMapper;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Commands.SetProfilePicture
{
    internal class SetProfilePictureCommandHandler : ICommandHandler<SetProfilePictureCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageDataRepository _messageRepository;
        private readonly IRequestClient<SaveProfilePictureRequest> _requestClient;
        private readonly IMapper _mapper;

        public SetProfilePictureCommandHandler(
            IUnitOfWork unitOfWork,
            IMessageDataRepository messageRepository,
            IRequestClient<SaveProfilePictureRequest> requestClient,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _messageRepository = messageRepository;
            _requestClient = requestClient;
            _mapper = mapper;
        }

        public async Task Handle(SetProfilePictureCommand request, CancellationToken cancellationToken)
        {
            MessageData<Stream> messageDataStream;
            User user;

            using (request.Stream)
            {
                user = _unitOfWork.UserRepository.GetActiveEntityById(request.UserId) ?? throw new UserNotFoundException();
                if (user.UserDetails is null)
                {
                    throw new UserDetailsNotFoundException();
                }

                messageDataStream = await _messageRepository.PutStream(request.Stream, cancellationToken);
            }

            var saveProfilePicRequest = _mapper.Map<SaveProfilePictureRequest>((request, messageDataStream));
            var result = await _requestClient.GetResponse<FileSaveResult>(saveProfilePicRequest, cancellationToken);

            if (!result.Message.Success)
            {
                throw new InternalServerError();
            }

            user.UserDetails.ProfilePicturePath = result.Message.Path;
            _unitOfWork.Save();
        }
    }
}
