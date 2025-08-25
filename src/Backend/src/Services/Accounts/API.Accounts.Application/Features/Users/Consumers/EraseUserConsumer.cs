using API.Accounts.Domain;
using API.Shared.Application.Contracts.Accounts.Commands;
using API.Shared.Application.Contracts.Accounts.Events;
using API.Shared.Application.Contracts.Base.Results;
using API.Shared.Application.Contracts.FileStorage.Requests;
using AutoMapper;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers
{
    public class EraseUserConsumer : IConsumer<EraseUser>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRequestClient<RemoveProfilePictureRequest> _requestClient;
        private readonly IMapper _mapper;

        public EraseUserConsumer(IUnitOfWork unitOfWork, IRequestClient<RemoveProfilePictureRequest> requestClient, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _requestClient = requestClient;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<EraseUser> context)
        {
            var user = _unitOfWork.UserRepository.GetById(context.Message.UserId)!;

            if (user.UserDetails?.ProfilePicturePath is not null)
            {
                var fileDeletionResult = await _requestClient
                    .GetResponse<BasicOperationResult>(_mapper.Map<RemoveProfilePictureRequest>(user.UserDetails));

                if (!fileDeletionResult.Message.Success)
                {
                    throw new Exception();
                }
            }

            var email = user.Emails.First(x => x.IsPrimary).Email;
            _unitOfWork.UserRepository.Delete(user);
            _unitOfWork.Save();

            await context.Publish<UserErasedEvent>(new(context.Message.UserId, email));
        }
    }
}
