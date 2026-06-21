using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Application.Contracts.Accounts.Results;
using API.Shared.Application.Contracts.FileStorage.Requests;
using AutoMapper;

namespace API.Accounts.Application.Features.Users.Mappings
{
    internal class ContractUserMappings : Profile
    {
        public ContractUserMappings()
        {
            CreateMap<UserDetails, RemoveProfilePictureRequest>()
                .ConstructUsing(x => new(x.ProfilePicturePath));

            CreateMap<UserDetails, UserDetailsResultData>();
        }
    }
}
