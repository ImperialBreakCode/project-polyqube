using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Common.Features.Users.EmailExceptions;
using API.Accounts.Domain;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Commands.VerifyEmail
{
    internal class VerifyEmailCommandHandler : ICommandHandler<VerifyEmailCommand, UserEmailViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VerifyEmailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserEmailViewModel> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var token = await _unitOfWork.EmailVerificationToken.GetTokenByTokenValueAsync(request.EmailVerificationToken);

            if (token is null || DateTime.UtcNow >= token.Expiry)
            {
                throw new CannotVerifyEmailExeption();
            }

            var email = token.User.Emails.First(x => x.Email == token.Email);
            email.IsVerified = true;
            _unitOfWork.Save();

            return _mapper.Map<UserEmailViewModel>(email);
        }
    }
}
