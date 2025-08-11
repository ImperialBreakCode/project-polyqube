using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Application.Features.Users.PasswordManager;
using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Common.Features.Users.Exceptions.LoginExceptions;
using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates;
using API.Shared.Application.Contracts.Base.Results;
using API.Shared.Application.Contracts.Emails.Requests;
using API.Shared.Application.Interfaces;
using AutoMapper;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Commands.RequestUserDeletion
{
    internal class RequestUserDeletionCommandHandler : ICommandHandler<RequestUserDeletionCommand, UserEmailViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRequestClient<SendUserDeletionEmailRequest> _requestClient;
        private readonly IPasswordManager _passwordManager;

        public RequestUserDeletionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRequestClient<SendUserDeletionEmailRequest> requestClient,
            IPasswordManager passwordManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _requestClient = requestClient;
            _passwordManager = passwordManager;
        }

        public async Task<UserEmailViewModel> Handle(RequestUserDeletionCommand request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.UserRepository.GetActiveEntityById(request.UserId);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            if (!_passwordManager.VerifyPassword(request.Password, user.PasswordHash))
            {
                throw new InvalidPasswordException();
            }

            var deletionToken = UserDeletionToken.Create(user);
            _unitOfWork.Save();

            var primaryEmail = user.Emails.First(x => x.IsPrimary);

            var result = await _requestClient.GetResponse<BasicOperationResult>(
                SendUserDeletionEmailRequest.Create(
                    primaryEmail.Email, 
                    deletionToken.Token));

            if (!result.Message.Success)
            {
                throw new Exception();
            }

            return _mapper.Map<UserEmailViewModel>(primaryEmail);
        }
    }
}