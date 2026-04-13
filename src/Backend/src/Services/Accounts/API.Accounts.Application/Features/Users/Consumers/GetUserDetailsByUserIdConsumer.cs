using API.Accounts.Domain;
using API.Shared.Application.Contracts.Accounts.Requests;
using API.Shared.Application.Contracts.Accounts.Results;
using AutoMapper;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Consumers
{
    public class GetUserDetailsByUserIdConsumer : IConsumer<GetUserDetailsByUserIdRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserDetailsByUserIdConsumer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<GetUserDetailsByUserIdRequest> context)
        {
            var user = _unitOfWork.UserRepository.GetById(context.Message.UserId);
            if (user == null)
            {
                await context.RespondAsync(UserDetailsResult.FailResult);
                return;
            }

            var userDetailsData = _mapper.Map<UserDetailsResultData>(user.UserDetails);
            await context.RespondAsync(UserDetailsResult.SuccessResult(userDetailsData));
        }
    }
}
